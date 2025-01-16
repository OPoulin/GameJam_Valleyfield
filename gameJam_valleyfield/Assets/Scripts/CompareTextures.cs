using UnityEngine;

public class CompareTextures : MonoBehaviour
{
    [SerializeField] private GameObject objectA; // Objet contenant le matériau A
    [SerializeField] private GameObject objectBBase; // Objet contenant le matériau BBase
    [SerializeField] private GameObject objectBTransparent; // Objet contenant le matériau BTransparent
    [SerializeField] private Material test; // Objet contenant le matériau BTransparent

    private Texture2D currentCombinedTexture; // Stocke la dernière texture combinée

    private void Update()
    {
        // Vérifie si la touche "Enter" est pressée
        if (Input.GetKeyDown(KeyCode.Return))
        {
            CompareMaterials();
        }
    }

    private void CompareMaterials()
    {
        if (objectA != null && objectBBase != null && objectBTransparent != null)
        {
            // Récupérer les MeshRenderer des objets pour accéder aux textures des matériaux
            MeshRenderer rendererA = objectA.GetComponent<MeshRenderer>();
            MeshRenderer rendererBBase = objectBBase.GetComponent<MeshRenderer>();
            MeshRenderer rendererBTransparent = objectBTransparent.GetComponent<MeshRenderer>();

            if (rendererA != null && rendererBBase != null && rendererBTransparent != null)
            {
                // Extraire les textures albedo de chaque objet
                Texture2D albedoA = rendererA.material.mainTexture as Texture2D;
                Texture2D albedoBBase = rendererBBase.material.mainTexture as Texture2D;
                Texture2D albedoBTransparent = rendererBTransparent.material.mainTexture as Texture2D;

                if (albedoA != null && albedoBBase != null && albedoBTransparent != null)
                {
                    // Combiner les textures BBase et BTransparent
                    currentCombinedTexture = CombineTextures(albedoBBase, albedoBTransparent);

                    test.mainTexture = currentCombinedTexture;

                    // Comparer la nouvelle texture combinée avec l’albedo de A
                    float similarity = CompareTexturePercentage(albedoA, currentCombinedTexture);
                    Debug.Log($"Les albedos sont similaires à {similarity}%.");
                }
                else
                {
                    Debug.LogError("Une ou plusieurs textures albedo sont nulles ou ne sont pas des Texture2D.");
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

    // Combine les textures BBase et BTransparent
    private Texture2D CombineTextures(Texture2D baseTexture, Texture2D overlayTexture)
    {
        if (baseTexture.width != overlayTexture.width || baseTexture.height != overlayTexture.height)
        {
            Debug.LogError("Les dimensions des textures ne correspondent pas.");
            return baseTexture;
        }

        Texture2D resultTexture = new Texture2D(baseTexture.width, baseTexture.height);

        for (int y = 0; y < baseTexture.height; y++)
        {
            for (int x = 0; x < baseTexture.width; x++)
            {
                Color baseColor = baseTexture.GetPixel(x, y);
                Color overlayColor = overlayTexture.GetPixel(x, y);

                // Mélanger les couleurs en fonction de l'alpha
                float alpha = overlayColor.a;
                Color finalColor = Color.Lerp(baseColor, overlayColor, alpha);
                resultTexture.SetPixel(x, y, finalColor);
            }
        }

        resultTexture.Apply();
        return resultTexture;
    }

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
        print(matchingPixels);

        return (float)matchingPixels / firstPix.Length * 100f;
    }

    private bool ColorsAreClose(Color a, Color b, float tolerance)
    {
        return Mathf.Abs(a.r - b.r) < tolerance &&
               Mathf.Abs(a.g - b.g) < tolerance &&
               Mathf.Abs(a.b - b.b) < tolerance &&
               Mathf.Abs(a.a - b.a) < tolerance;
    }
}
