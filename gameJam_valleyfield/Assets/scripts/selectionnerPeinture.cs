using System.Collections.Generic;
using UnityEngine;

public class selectionnerPeinture : MonoBehaviour
{
    public GameObject posPeinture;
    public GameObject gestionPeinture;
    public GameObject gestionTape;

    public GameObject cene; //0
    public GameObject david; //1
    public GameObject monaLisa; //2
    public GameObject salvator; //3
    public GameObject venus; //4

    public List<int> largeur;
    public List<int> hauteur;
    public List<GameObject> posHautGauche;
    public List<GameObject> posBasDroite;
    public List<GameObject> points;
    public List<Material> lesMateriaux;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            ChangerPeinture(0);
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            ChangerPeinture(1);
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            ChangerPeinture(2);
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            ChangerPeinture(3);
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            ChangerPeinture(4);
        }
    }

    public void ChangerPeinture(int peinture)
    {
        cene.SetActive(false);
        david.SetActive(false);
        monaLisa.SetActive(false);
        salvator.SetActive(false);
        venus.SetActive(false);

        if (peinture == 0)
        {
            cene.SetActive(true);
            cene.transform.position = posPeinture.transform.position;
            gestionTape.GetComponent<createurScotch>().parentTableau = cene;
        }
        if (peinture == 1)
        {
            david.SetActive(true);
            david.transform.position = posPeinture.transform.position;
            gestionTape.GetComponent<createurScotch>().parentTableau = david;
        }
        if (peinture == 2)
        {
            monaLisa.SetActive(true);
            monaLisa.transform.position = posPeinture.transform.position;
            gestionTape.GetComponent<createurScotch>().parentTableau = monaLisa;
        }
        if (peinture == 3)
        {
            salvator.SetActive(true);
            salvator.transform.position = posPeinture.transform.position;
            gestionTape.GetComponent<createurScotch>().parentTableau = salvator;
        }
        if (peinture == 4)
        {
            venus.SetActive(true);
            venus.transform.position = posPeinture.transform.position;
            gestionTape.GetComponent<createurScotch>().parentTableau = venus;
        }
        gestionPeinture.GetComponent<Draw>().totalXPixels = largeur[peinture];
        gestionPeinture.GetComponent<Draw>().totalYPixels = hauteur[peinture];
        gestionPeinture.GetComponent<Draw>().topLeftCorner = posHautGauche[peinture].transform;
        gestionPeinture.GetComponent<Draw>().bottomRightCorner = posBasDroite[peinture].transform;
        gestionPeinture.GetComponent<Draw>().point = points[peinture].transform;
        gestionPeinture.GetComponent<Draw>().material = lesMateriaux[peinture];
        gestionPeinture.GetComponent<Draw>().setupStartPeinture();
        gestionTape.GetComponent<createurScotch>().point = points[peinture].transform;
    }
}
