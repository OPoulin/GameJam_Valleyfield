using UnityEngine;

public class selectionnerPeinture : MonoBehaviour
{
    static public GameObject Cene;
    static public GameObject David;
    static public GameObject Joconde;
    static public GameObject Salvator;
    static public GameObject Venus;

    static void ChangerPeinture(string peinture)
    {
        if(peinture == "Cene")
        {
            Instantiate(Cene);
        }
    }
}
