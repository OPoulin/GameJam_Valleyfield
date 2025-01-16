using UnityEngine;

public class selectionnerPeinture : MonoBehaviour
{
    static public GameObject posPeinture;

    static void ChangerPeinture(GameObject peinture)
    {
        GameObject nouvellePeint = Instantiate(peinture);
        nouvellePeint.transform.position = posPeinture.transform.position;
    }
}
