using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareTextures : MonoBehaviour
{
    [SerializeField] private Material materialA;
    [SerializeField] private Material materialB;

    private void Start()
    {
        if (materialA != null && materialB != null)
        {
            Texture2D albedoA = materialA.mainTexture as Texture2D;
            Texture2D albedoB = materialB.mainTexture as Texture2D;

            if (albedoA != null && albedoB != null)
            {
                float similarity = CompareTexturePercentage(albedoA, albedoB);
                Debug.Log($"Les albedos sont similaires à {similarity}%.");
            }
            else
            {
                Debug.LogError("Une ou plusieurs textures albedo sont nulles ou ne sont pas des Texture2D.");
            }
        }
        else
        {
            Debug.LogError("Une ou plusieurs matériaux sont nuls.");
        }
    }

    private float CompareTexturePercentage(Texture2D first, Texture2D second)
    {
        if (first.width != second.width || first.height != second.height)
        {
            Debug.LogError("Les dimensions des textures albedo ne correspondent pas.");
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
