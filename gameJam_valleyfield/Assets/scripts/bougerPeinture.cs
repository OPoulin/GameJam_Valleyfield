using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class bougerPeinture : MonoBehaviour
{
    public float vitesse = 1f;
    public float vitesseDeplace = 1f;
    public bool caPart;
    public bool cestParti;

    public GameObject dessin;
    public GameObject check;
    public GameObject OG;
    public GameObject placeholder;

    public Material test;

    void Update()
    {
        float l = -vitesse * Input.GetAxis("Mouse Y");
        float h = vitesse * Input.GetAxis("Mouse X");
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(l, h, 0);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if(transform.position.y < 0)
        {
            transform.Translate(new Vector3(0f, vitesseDeplace, 0f));
        }
        if(caPart && transform.position.x < 30)
        {
            transform.Translate(new Vector3(vitesseDeplace * 1.2f, 0f, 0f));
            if (!cestParti)
            {
                ResizeDessin();
            }
            cestParti = true;
        }
    }

    public void ResizeDessin()
    {
        Texture2D texture = dessin.GetComponent<MeshRenderer>().material.mainTexture as Texture2D;
        //Texture2D nouveauAlbedo = ResizeTextureTo(texture, 1024, 1024);
        test.mainTexture = texture;
        gameObject.GetComponent<CompareTextures>().PerformComparison(check, OG, placeholder);
    }

    Texture2D ResizeTextureTo(Texture2D texture, int width, int height)
    {
        // Crée une nouvelle texture de la taille souhaitée
        Texture2D resized = new Texture2D(width, height, texture.format, texture.mipmapCount > 1);

        // Utiliser un filtre de redimensionnement bilinéaire (plus de détails préservés)
        //Color[] resizedPixels = texture.GetPixels(
        //    Mathf.FloorToInt(texture.width * 0.5f),
        //    Mathf.FloorToInt(texture.height * 0.5f),
        //    texture.width,
        //    texture.height);

        //resized.SetPixels(resizedPixels);
        resized.Apply();

        return resized;
    }
}
