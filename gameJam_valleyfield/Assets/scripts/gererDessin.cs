using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class gererDessin : MonoBehaviour
{
    public Camera cam;
    public int totalPixelsX;
    public int totalPixelsY;
    public int tailleBrush;
    public Color couleurBrush;

    public Transform coinGaucheHaut;
    public Transform coinDroitBas;
    public Transform point;

    public Material material;

    public Texture2D texturePeinture;

    Color[] colorMap;

    int xPixel = 0;
    int yPixel = 0;

    float xMult;
    float yMult;


    EventInstance dessiner;

    private void Start()
    {
        colorMap = new Color[totalPixelsX * totalPixelsY];
        texturePeinture = new Texture2D(totalPixelsY, totalPixelsX, TextureFormat.RGBA32, false);
        texturePeinture.filterMode = FilterMode.Point;
        material.SetTexture("_BaseMap", texturePeinture);

        ResetCouleur();

        xMult = totalPixelsX / (coinDroitBas.localPosition.x - coinGaucheHaut.localPosition.x);
        yMult = totalPixelsY / (coinDroitBas.localPosition.y - coinGaucheHaut.localPosition.y);

        
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            CalculerPixel();

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetCouleur();
        }
    }

    void CalculerPixel()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10f))
        {
            point.position = hit.point;
            xPixel = (int)((point.localPosition.x - coinGaucheHaut.localPosition.x) * xMult);
            yPixel = (int)((point.localPosition.y - coinGaucheHaut.localPosition.y) * yMult);
            ChangerPixelsAutour();
        }
    }

    void ChangerPixelsAutour()
    {
        Dessiner(xPixel, yPixel);
        SetTexture();
    }

    void Dessiner(int xPix, int yPix)
    {
        int i = xPix - tailleBrush + 1, j = yPix - tailleBrush + 1, maxi = xPix + tailleBrush - 1, maxj = yPix + tailleBrush - 1;
        if (i < 0)
        {
            i = 0;
        }
        if (j < 0)
        {
            j = 0;
        }
        if(maxi >= totalPixelsX)
        {
            maxi = totalPixelsX - 1;
        }
        if(maxj >= totalPixelsY)
        {
            maxj = totalPixelsY - 1;
        }
        for (int x = i; x <= maxi; x++)
        {
            for (int y = j; y <= maxj; y++)
            {
                if((x - xPix) * (x - xPix) + (y - yPix) * (y - yPix) <= tailleBrush * tailleBrush)
                {
                    colorMap[x * totalPixelsY + y] = couleurBrush;
                }
            }
        }
    }   

    void SetTexture()
    {
        texturePeinture.SetPixels(colorMap);
        texturePeinture.Apply();
    }

    void ResetCouleur()
    {
        for(int i = 0; i < colorMap.Length; i++)
        {
            colorMap[i] = Color.black;
        }
        SetTexture();  
    }
}
