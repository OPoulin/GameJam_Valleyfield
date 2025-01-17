using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using FMODUnity;

public class TimerSkip : MonoBehaviour
{
    // Gestion du temps
    public float minute;
    public TMP_Text temps;
    public float seconde;
    public bool aDejaFaitSonTour;
    public bool fini;

    public static int laPeinture;

    // Gestion des peintures
    private bool[] peinturesUtilisees = new bool[8];
    public GameObject[] originels;
    public GameObject[] oeuvres;
    public GameObject oeuvreFini;

    // Gestion du skip
    public bool skip;

    public GameObject toolGester;

    // Événements pour chaque phase
    public UnityEvent OnPhase1Complete;
    public UnityEvent OnPhase2Complete;
    public UnityEvent OnPhase3Complete;
    public UnityEvent OnPhase4Complete;

    //les cameras dans la scene atelier
    public GameObject cameraJeu;
    public GameObject cameraMusee;

    private int phaseActuelle = 0;

    void Start()
    {
        fini = false;
        seconde = 0;
        minute = 1;

        // Démarrer le temps
        InvokeRepeating("MettreAJourTemps", 0, 1f);

        // Choisir une peinture initiale
        PrendreUnePeinture();
    }

    public void ActiverLeSkip()
    {
        skip = true;
    }

    void Update()
    {
        if (fini)
        {
            PhaseComplete();
        }

        if (skip)
        {
            skip = false;
            PhaseComplete();
        }
    }

    void MettreAJourTemps()
    {
        if (!fini)
        {
            if (minute == 1)
            {
                minute = 0;
                seconde = 59;
            }

            if (seconde > 0)
            {
                seconde--;
            }

            if (seconde == 0 && minute == 0)
            {
                fini = true;
            }
        }

        AfficherTemps();
    }

    void AfficherTemps()
    {
        temps.text = $"{minute.ToString().PadLeft(2, '0')}:{seconde.ToString().PadLeft(2, '0')}";
    }

    void PrendreUnePeinture()
    {
        if(oeuvreFini != null)
        {
            GameObject verif = oeuvreFini.transform.GetChild(0).gameObject;
            float pourcent = verif.GetComponent<CompareTextures>().PerformComparison(verif.GetComponent<CompareTextures>().objectA, verif.GetComponent<CompareTextures>().objectBBase, verif.GetComponent<CompareTextures>().objectBTransparent);
            if(oeuvreFini.tag == "statue")
            {
                float moneyAlert = (200 * pourcent / 100) + seconde;
                toolGester.GetComponent<toolManagerScript>().money += Mathf.Round(moneyAlert);
            }
            else if(oeuvreFini.tag == "peinture")
            {
                float moneyAlert = (500 * pourcent / 100) + seconde;
                toolGester.GetComponent<toolManagerScript>().money += Mathf.Round(moneyAlert);
            }
        }
        // Désactiver toutes les œuvres
        foreach (GameObject oeuvre in oeuvres)
        {
            oeuvre.SetActive(false);
        }

        while (true)
        {
            laPeinture = Random.Range(0, oeuvres.Length);

            if (!peinturesUtilisees[laPeinture])
            {
                oeuvreFini = oeuvres[laPeinture];
                peinturesUtilisees[laPeinture] = true;
                oeuvres[laPeinture].SetActive(true);
                if (oeuvres[laPeinture].gameObject.tag=="peinture")
                {
                    toolGester.GetComponent<toolManagerScript>().switchTools("peinture");
                } else
                {
                    toolGester.GetComponent<toolManagerScript>().switchTools("statue");
                }
                break;
            }
        }
    }

    void ResetTimer()
    {
        fini = false;
        aDejaFaitSonTour = false;
        minute = 1;
        RuntimeManager.PlayOneShot(AllSFX.ding);
        dessein3D.dessiner.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    void DesactiverToutesLesOriginels()
    {
        foreach (GameObject originel in originels)
        {
            originel.SetActive(false);
        }
    }

    void PhaseComplete()
    {
        fini = false;
        ResetTimer();
        DesactiverToutesLesOriginels();
        PrendreUnePeinture();

        phaseActuelle++;
        switch (phaseActuelle)
        {
            case 1:
                OnPhase1Complete?.Invoke();
                break;
            case 2:
                OnPhase2Complete?.Invoke();
                break;
            case 3:
                OnPhase3Complete?.Invoke();
                break;
            case 4:
                OnPhase4Complete?.Invoke();
                phaseActuelle = 0; // Réinitialise après la quatrième phase
                if(toolGester.GetComponent<toolManagerScript>().money > 1000)
                {
                    cameraMusee.SetActive(true);
                    cameraJeu.SetActive(false);
                }
                else
                {
                    SceneManager.LoadScene(3);
                }
                break;
        }
    }
}
