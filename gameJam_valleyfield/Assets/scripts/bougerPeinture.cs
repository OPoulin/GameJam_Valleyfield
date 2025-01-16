using UnityEngine;

public class bougerPeinture : MonoBehaviour
{
    public float vitesse = 1f;
    public float vitesseDeplace = 1f;
    public bool caPart;
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
        }
    }
}
