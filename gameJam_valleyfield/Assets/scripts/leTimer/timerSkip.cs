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
    // Start is called before the first frame update
    void Start()
    {
        FINI = false;
        seconde = 0;
        minute = 1;
        // faire rouler le temps
        InvokeRepeating("leTemps", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
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

            if(seconde == 0)
            {
                if (aDejaFaitSonTour = true)
                {
                    FINI = true;

                }
                if (aDejaFaitSonTour = false)
                {
                    seconde = 59;
                    aDejaFaitSonTour = true;
                }
               

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



}
