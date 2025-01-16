using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timerSkip : MonoBehaviour
{

    // fonction dans le menu
    public float minute;
    public TMP_Text temps;
    public float seconde;
    public bool aDejaFaitSonTour;
    public bool FINI;


    public int laPeinture;
    public GameObject gestionPeinture;

    public List<int> listeRandom;

    public bool peinture0;
    public bool peinture1;
    public bool peinture2;
    public bool peinture3;
    public bool peinture4;



    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public bool skip;
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        FINI = false;
        seconde = 0;
        minute = 1;
        // faire rouler le temps
        InvokeRepeating("leTemps", 0, 1f);


        prendUnePeinture();

    }

    public void ActiveLeSkip()
    {
        skip = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (FINI == true)
        {
            FINI = false;
            aDejaFaitSonTour = false;
            minute = 1;
            prendUnePeinture();
            

        }

        if(skip == true)
        {
            minute = 1;
            seconde = 1;
            prendUnePeinture();
            skip = false;
        }

    }

    //calcul du temps
    void leTemps()
    {
        if (FINI == false)
        {
            if(minute == 1)
            {
                minute = 0;
                seconde = 59;
            }

            if (seconde > 0)
            {
                seconde = seconde - 1;
            }

            if(seconde == 0 && minute == 0)
            {             
                    FINI = true;
            }
           
           
/*
          
*/
          
        }
     

        afficherLeTemps();
    }
    //afficher le temps
    void afficherLeTemps()
    {

        temps.text = $"{minute.ToString().PadLeft(2, '0')}:{seconde.ToString().PadLeft(2, '0')}";
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
            //  Invoke("prendUnePeinture", 5f);
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
            //  Invoke("prendUnePeinture", 5f);
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
            //   Invoke("prendUnePeinture", 5f);
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
            //  Invoke("prendUnePeinture", 5f);
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
            //Invoke("prendUnePeinture", 5f);
        }


    }


}
