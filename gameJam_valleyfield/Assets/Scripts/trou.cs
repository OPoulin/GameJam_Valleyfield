using UnityEngine;

public class trou : MonoBehaviour
{
    public bool is2D = true; // Coche si c'est 2D ou 3D
    public float postItRequired = 3f;
    public float essuiToutRequired = 2f;
    public float tapeRequiredLength = 5f; // Longueur nécessaire de scotch pour boucher le trou
    public float gometteRequired = 3f;
    public float marbreRequired = 4f;
    public float modelerRequired = 2f;

    private float postItCount = 0f;
    private float essuiToutCount = 0f;
    private float tapeUsedLength = 0f; // Longueur totale du scotch utilisée
    private float gometteCount = 0f;
    private float marbreCount = 0f;
    private float modelerCount = 0f;

    void OnTriggerEnter(Collider other)
    {
        if (!is2D)
        {
            Check3DCollision(other);
        }
        else
        {
            Check2DCollision(other);
        }
    }

    void Check2DCollision(Collider other)
    {
        if (other.CompareTag("postIt"))
        {
            postItCount++;
            if (postItCount >= postItRequired)
            {
                Debug.Log("Le trou est bouché avec des post-its !");
            }
        }
        else if (other.CompareTag("essuiTout"))
        {
            essuiToutCount++;
            if (essuiToutCount >= essuiToutRequired)
            {
                Debug.Log("Le trou est bouché avec des essuie-touts !");
            }
        }
        else if (other.CompareTag("tape"))
        {
            // Utilise la longueur du MeshRenderer pour calculer la longueur du scotch utilisé
            float tapeLength = other.GetComponent<Renderer>().bounds.size.y; // Longueur du scotch selon son mesh
            tapeUsedLength += tapeLength;

            if (tapeUsedLength >= tapeRequiredLength)
            {
                Debug.Log("Le trou est bouché avec du scotch !");
            }
        }
    }

    void Check3DCollision(Collider other)
    {
        if (other.CompareTag("gomette"))
        {
            gometteCount++;
            if (gometteCount >= gometteRequired)
            {
                Debug.Log("Le trou est bouché avec des gommettes !");
            }
        }
        else if (other.CompareTag("marbre"))
        {
            marbreCount++;
            if (marbreCount >= marbreRequired)
            {
                Debug.Log("Le trou est bouché avec des marbres !");
            }
        }
        else if (other.CompareTag("modeler"))
        {
            modelerCount++;
            if (modelerCount >= modelerRequired)
            {
                Debug.Log("Le trou est bouché avec du modeler !");
            }
        }
    }
}
