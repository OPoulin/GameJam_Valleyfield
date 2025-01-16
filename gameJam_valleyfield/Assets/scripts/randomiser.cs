using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomiser : MonoBehaviour
{
    public int laPeinture;
    public GameObject gestionPeinture;

    public List<int> listeRandom;

    public bool peinture0;
    public bool peinture1;
    public bool peinture2;
    public bool peinture3;
    public bool peinture4;


    // Start is called before the first frame update
    void Start()
    {
       
        print(laPeinture);
       
        prendUnePeinture();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

   void prendUnePeinture()
    {
        laPeinture = Random.Range(0, 5);

        // ///////////// la première peinture ////////////////////////////////////////////////
        if (laPeinture == 0 && peinture0 == true)
        {      
            prendUnePeinture();
            return;
        }
        if (laPeinture == 0 && peinture0 == false)
        {
            peinture0 = true;
            gestionPeinture.GetComponent<selectionnerPeinture>().ChangerPeinture(laPeinture);
            Invoke("prendUnePeinture", 5f);
        }

        // ///////////// la deuxième peinture ////////////////////////////////////////////////
        if (laPeinture == 1 && peinture1 == true)
        {
            //laPeinture = Random.Range(0, 5);
            prendUnePeinture();
            return;
        }
        if (laPeinture == 1 && peinture1 == false)
        {
            peinture1 = true;
            gestionPeinture.GetComponent<selectionnerPeinture>().ChangerPeinture(laPeinture);
            Invoke("prendUnePeinture", 5f);
        }


        // ///////////// la troisième peinture ////////////////////////////////////////////////
        if (laPeinture == 2 && peinture2 == true)
        {
            //laPeinture = Random.Range(0, 5);
            prendUnePeinture();
            return;
        }
        if (laPeinture == 2 && peinture2 == false)
        {
            peinture2 = true;
            gestionPeinture.GetComponent<selectionnerPeinture>().ChangerPeinture(laPeinture);
            Invoke("prendUnePeinture", 5f);
        }

        // ///////////// la quatrième peinture ////////////////////////////////////////////////
        if (laPeinture == 3 && peinture3 == true)
        {
            //laPeinture = Random.Range(0, 5);
            prendUnePeinture();
            return;
        }
        if (laPeinture == 3 && peinture3 == false)
        {
            peinture3 = true;
            gestionPeinture.GetComponent<selectionnerPeinture>().ChangerPeinture(laPeinture);
            Invoke("prendUnePeinture", 5f);
        }

        // ///////////// la cinquième peinture ////////////////////////////////////////////////
        if (laPeinture == 4 && peinture4 == true)
        {
            //laPeinture = Random.Range(0, 5);
            prendUnePeinture();
            return;
        }
        if (laPeinture == 4 && peinture4 == false)
        {
            peinture4 = true;
            gestionPeinture.GetComponent<selectionnerPeinture>().ChangerPeinture(laPeinture);
            Invoke("prendUnePeinture", 5f);
        }

       
    }

}
