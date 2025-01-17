using UnityEngine;

public class CompareTextures : MonoBehaviour
{
    [SerializeField] public GameObject objectA; // Objet contenant le matériau A
    [SerializeField] public GameObject objectBBase; // Objet contenant le matériau BBase
    [SerializeField] public GameObject objectBTransparent; // Objet contenant le matériau BTransparent
    [SerializeField] private GameObject resultat; // Objet contenant le script Valeur
    [SerializeField] private Material test; // Matériau pour afficher la texture combinée

    private Texture2D currentCombinedTexture; // Stocke la dernière texture combinée
    private float basePercent = -1; // Stocke le pourcentage initial
    private bool isFirstRun = true; // Indique si c'est la première exécution

    private void Start()
    {
        //print(objectA);
        //print(objectBBase);
        // Comparaison initiale dès le lancement
        PerformComparisonPremiereFois(objectA, objectBBase);
    }

    private void Update()
    {
        // Optionnel : Relancer la comparaison manuellement avec la touche "Enter"
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PerformComparison(objectA, objectBBase, objectBTransparent);
        }
    }

    public void PerformComparisonPremiereFois(GameObject objA, GameObject objBBase)
    {
        if (objA != null && objBBase != null)
        {
            MeshRenderer rendererA = objA.GetComponent<MeshRenderer>();
            MeshRenderer rendererBBase = objBBase.GetComponent<MeshRenderer>();

            if (rendererA != null && rendererBBase != null)
            {
                Texture2D albedoA = rendererA.material.mainTexture as Texture2D;
                Texture2D albedoBBase = rendererBBase.material.mainTexture as Texture2D;

                float similarity = CompareTexturePercentage(albedoA, albedoBBase);
                //Debug.Log($"Les albedos sont similaires à {similarity}%.");

                // Stocker le pourcentage initial
                basePercent = similarity;
                isFirstRun = false;
                //print(basePercent);

            }
            else
            {
                Debug.LogError("Un ou plusieurs objets n'ont pas de MeshRenderer attaché.");
            }
        }
        else
        {
            Debug.LogError("Une ou plusieurs références d'objets sont nulles.");
        }
    }

    /// <summary>
    /// Effectue la comparaison entre les matériaux et ajuste les pourcentages.
    /// </summary>
    public void PerformComparison(GameObject objA, GameObject objBBase, GameObject objBTransparent)
    {
        if (objA != null && objBBase != null && objBTransparent != null)
        {
            MeshRenderer rendererA = objA.GetComponent<MeshRenderer>();
            MeshRenderer rendererBBase = objBBase.GetComponent<MeshRenderer>();
            MeshRenderer rendererBTransparent = objBTransparent.GetComponent<MeshRenderer>();

            if (rendererA != null && rendererBBase != null && rendererBTransparent != null)
            {
                Texture2D albedoA = rendererA.material.mainTexture as Texture2D;
                Texture2D albedoBBase = rendererBBase.material.mainTexture as Texture2D;
                Texture2D albedoBTransparent = rendererBTransparent.material.mainTexture as Texture2D;

                if (albedoA != null && albedoBBase != null && albedoBTransparent != null)
                {

                    currentCombinedTexture = CombineTextures(albedoBBase, albedoBTransparent);

                    test.mainTexture = albedoBTransparent;

                    float similarity = CompareTexturePercentage(albedoA, currentCombinedTexture);
                    //Debug.Log($"Les albedos sont similaires à {similarity}%.");

                    // Utiliser le pourcentage de base pour calculer le complément
                    //print(basePercent);
                    float remainingPercent = 100f - basePercent;
                    float adjustedPercent;
                    if (similarity < basePercent)
                    {
                        adjustedPercent = 0;
                    }
                    else
                    {
                        adjustedPercent = Mathf.Abs((similarity - basePercent) / remainingPercent * 100);
                    }
                    print(similarity + "-" + basePercent + "/" + remainingPercent + "=" + adjustedPercent);
                    //print(adjustedPercent / 2 + "+" + similarity / 2);
                    resultat.GetComponent<Valeur>().SetPercentPaint(adjustedPercent / 2 + similarity / 2);
                    print("paint" + adjustedPercent / 2 + "+" + similarity / 2);

                    /*
                    if (similarity > basePercent)
                    {
                    }
                    else
                    {
                        resultat.GetComponent<Valeur>().SetPercentPaint((adjustedPercent / 3) + (similarity / 3*2));
                    }*/
                    //print(adjustedPercent);

                }
                else
                {
                    Debug.LogError("Une ou plusieurs textures albedo sont nulles ou ne sont pas des Texture2D.A" + albedoA + "B" + albedoBBase + "BT" + albedoBTransparent);

                }
            }
            else
            {
                Debug.LogError("Un ou plusieurs objets n'ont pas de MeshRenderer attaché.");

            }
        }
        else
        {
            Debug.LogError("Une ou plusieurs références d'objets sont nulles.");

        }
    }

    /// <summary>
    /// Combine deux textures en appliquant la transparence de l'overlay.
    /// </summary>
    private Texture2D CombineTextures(Texture2D baseTexture, Texture2D overlayTexture)
    {
        if (baseTexture.width != overlayTexture.width || baseTexture.height != overlayTexture.height)
        {
            Debug.LogError("Les dimensions des textures ne correspondent pas. BW" + baseTexture.width + " + OW" + overlayTexture.width); ;
            return baseTexture;
        }

        Texture2D resultTexture = new Texture2D(baseTexture.width, baseTexture.height);

        for (int y = 0; y < baseTexture.height; y++)
        {
            for (int x = 0; x < baseTexture.width; x++)
            {
                Color baseColor = baseTexture.GetPixel(x, y);
                Color overlayColor = overlayTexture.GetPixel(x, y);

                float alpha = overlayColor.a;
                Color finalColor = Color.Lerp(baseColor, overlayColor, alpha);
                resultTexture.SetPixel(x, y, finalColor);
            }
        }

        resultTexture.Apply();
        return resultTexture;
    }

    /// <summary>
    /// Compare deux textures et retourne un pourcentage de similitude.
    /// </summary>
    private float CompareTexturePercentage(Texture2D first, Texture2D second)
    {
        if (first.width != second.width || first.height != second.height)
        {
            Debug.LogError("Les dimensions des textures ne correspondent pas.");
            return 0f;
        }

        Color[] firstPix = first.GetPixels();
        Color[] secondPix = second.GetPixels();

        int matchingPixels = 0;

        for (int i = 0; i < firstPix.Length; i++)
        {
            if (ColorsAreClose(firstPix[i], secondPix[i], 0.01f))
            {
                matchingPixels++;
            }
        }

        return (float)matchingPixels / firstPix.Length * 100f;
    }

    /// <summary>
    /// Vérifie si deux couleurs sont similaires en fonction d'une tolérance.
    /// </summary>
    private bool ColorsAreClose(Color a, Color b, float tolerance)
    {
        return Mathf.Abs(a.r - b.r) < tolerance &&
               Mathf.Abs(a.g - b.g) < tolerance &&
               Mathf.Abs(a.b - b.b) < tolerance &&
               Mathf.Abs(a.a - b.a) < tolerance;
    }

    public float CalcPourcentage(float pourcent)
    {
        return pourcent;
    }
}
