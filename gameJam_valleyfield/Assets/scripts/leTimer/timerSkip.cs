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


    public static int laPeinture;
    //public GameObject gestionPeinture;

    public List<int> listeRandom;

    public bool peinture0;
    public bool peinture1;
    public bool peinture2;
    public bool peinture3;
    public bool peinture4;
    public bool peinture5;
    public bool peinture6;
    public bool peinture7;



    public GameObject originel0;
    public GameObject originel1;
    public GameObject originel2;
    public GameObject originel3;
    public GameObject originel4;
    public GameObject originel5;
    public GameObject originel6;
    public GameObject originel7;

    public GameObject oeuvre0;
    public GameObject oeuvre1;
    public GameObject oeuvre2;
    public GameObject oeuvre3;
    public GameObject oeuvre4;
    public GameObject oeuvre5;
    public GameObject oeuvre6;
    public GameObject oeuvre7;


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

            originel0.SetActive(false);
            originel1.SetActive(false);
            originel2.SetActive(false);
            originel3.SetActive(false);
            originel4.SetActive(false);
            originel5.SetActive(false);
            originel6.SetActive(false);
            originel7.SetActive(false);

            prendUnePeinture();
            

        }

        if(skip == true)
        {
            minute = 1;
            seconde = 1;
            prendUnePeinture();

            originel0.SetActive(false);
            originel1.SetActive(false);
            originel2.SetActive(false);
            originel3.SetActive(false);
            originel4.SetActive(false);
            originel5.SetActive(false);
            originel6.SetActive(false);
            originel7.SetActive(false);


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
        oeuvre0.SetActive(false);
        oeuvre1.SetActive(false);
        oeuvre2.SetActive(false);
        oeuvre3.SetActive(false);
        oeuvre4.SetActive(false);
        oeuvre5.SetActive(false);
        oeuvre6.SetActive(false);
        oeuvre7.SetActive(false);
  

        laPeinture = Random.Range(0, 9);

        // ///////////// la première peinture ////////////////////////////////////////////////
        if (laPeinture == 0 && peinture0 == true)
        {
            prendUnePeinture();
            return;
        }
        if (laPeinture == 0 && peinture0 == false)
        {
            peinture0 = true;

            oeuvre0.SetActive(true);

           // gestionPeinture.GetComponent<selectionnerPeinture>().ChangerPeinture(laPeinture);
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
            oeuvre1.SetActive(true);
            //gestionPeinture.GetComponent<selectionnerPeinture>().ChangerPeinture(laPeinture);
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
            oeuvre2.SetActive(true);
            //gestionPeinture.GetComponent<selectionnerPeinture>().ChangerPeinture(laPeinture);
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
            oeuvre3.SetActive(true);
            // gestionPeinture.GetComponent<selectionnerPeinture>().ChangerPeinture(laPeinture);
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
            oeuvre4.SetActive(true);
            //gestionPeinture.GetComponent<selectionnerPeinture>().ChangerPeinture(laPeinture);
            //Invoke("prendUnePeinture", 5f);
        }


        // ///////////// la sixième peinture ////////////////////////////////////////////////
        if (laPeinture == 5 && peinture5 == true)
        {
            //laPeinture = Random.Range(0, 5);
            prendUnePeinture();
            return;
        }
        if (laPeinture == 5 && peinture5 == false)
        {
            peinture5 = true;
            oeuvre5.SetActive(true);
            //gestionPeinture.GetComponent<selectionnerPeinture>().ChangerPeinture(laPeinture);
            //Invoke("prendUnePeinture", 5f);
        }

        // ///////////// la septième peinture ////////////////////////////////////////////////
        if (laPeinture == 6 && peinture6 == true)
        {
            //laPeinture = Random.Range(0, 5);
            prendUnePeinture();
            return;
        }
        if (laPeinture == 6 && peinture6 == false)
        {
            peinture6 = true;
            oeuvre6.SetActive(true);
            //gestionPeinture.GetComponent<selectionnerPeinture>().ChangerPeinture(laPeinture);
            //Invoke("prendUnePeinture", 5f);
        }


        // ///////////// la huitième peinture ////////////////////////////////////////////////
        if (laPeinture == 7 && peinture7 == true)
        {
            //laPeinture = Random.Range(0, 5);
            prendUnePeinture();
            return;
        }
        if (laPeinture == 7 && peinture7 == false)
        {
            peinture7 = true;
            oeuvre7.SetActive(true);
            //gestionPeinture.GetComponent<selectionnerPeinture>().ChangerPeinture(laPeinture);
            //Invoke("prendUnePeinture", 5f);
        }

















    }


}
