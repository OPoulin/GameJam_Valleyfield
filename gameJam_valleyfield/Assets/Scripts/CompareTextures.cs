using UnityEngine;

public class CompareTextures : MonoBehaviour
{
    [SerializeField] public GameObject objectA; // Objet contenant le mat�riau A
    [SerializeField] public GameObject objectBBase; // Objet contenant le mat�riau BBase
    [SerializeField] public GameObject objectBTransparent; // Objet contenant le mat�riau BTransparent
    [SerializeField] private GameObject resultat; // Objet contenant le script Valeur
    [SerializeField] private Material test; // Mat�riau pour afficher la texture combin�e

    private Texture2D currentCombinedTexture; // Stocke la derni�re texture combin�e
    private float basePercent = -1; // Stocke le pourcentage initial
    private bool isFirstRun = true; // Indique si c'est la premi�re ex�cution

    private void Start()
    {
        //print(objectA);
        //print(objectBBase);
        // Comparaison initiale d�s le lancement
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
                //Debug.Log($"Les albedos sont similaires � {similarity}%.");

                // Stocker le pourcentage initial
                basePercent = similarity;
                isFirstRun = false;
                //print(basePercent);

            }
            else
            {
                Debug.LogError("Un ou plusieurs objets n'ont pas de MeshRenderer attach�.");
            }
        }
        else
        {
            Debug.LogError("Une ou plusieurs r�f�rences d'objets sont nulles.");
        }
    }

    /// <summary>
    /// Effectue la comparaison entre les mat�riaux et ajuste les pourcentages.
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
                    //Debug.Log($"Les albedos sont similaires � {similarity}%.");

                    // Utiliser le pourcentage de base pour calculer le compl�ment
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
                Debug.LogError("Un ou plusieurs objets n'ont pas de MeshRenderer attach�.");

            }
        }
        else
        {
            Debug.LogError("Une ou plusieurs r�f�rences d'objets sont nulles.");

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
    /// V�rifie si deux couleurs sont similaires en fonction d'une tol�rance.
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
