using UnityEngine;

public class CompareTextures : MonoBehaviour
{
    [SerializeField] private GameObject objectA; // Objet contenant le mat�riau A
    [SerializeField] private GameObject objectBBase; // Objet contenant le mat�riau BBase
    [SerializeField] private GameObject objectBTransparent; // Objet contenant le mat�riau BTransparent
    [SerializeField] private Material test; // Mat�riau pour afficher la texture combin�e

    private Texture2D currentCombinedTexture; // Stocke la derni�re texture combin�e

    private void Update()
    {
        // V�rifie si la touche "Enter" est press�e
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PerformComparison(objectA, objectBBase, objectBTransparent);
        }
    }

    // Fonction appelable pour comparer les mat�riaux
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

                    test.mainTexture = currentCombinedTexture;

                    float similarity = CompareTexturePercentage(albedoA, currentCombinedTexture);
                    Debug.Log($"Les albedos sont similaires � {similarity}%.");
                }
                else
                {
                    Debug.LogError("Une ou plusieurs textures albedo sont nulles ou ne sont pas des Texture2D.");
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
