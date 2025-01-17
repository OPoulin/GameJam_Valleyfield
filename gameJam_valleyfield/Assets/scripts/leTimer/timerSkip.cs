using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    // Gestion du skip
    public bool skip;

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
            ResetTimer();
            DesactiverToutesLesOriginels();
            PrendreUnePeinture();
        }

        if (skip)
        {
            skip = false;
            ResetTimer();
            DesactiverToutesLesOriginels();
            PrendreUnePeinture();
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
                peinturesUtilisees[laPeinture] = true;
                oeuvres[laPeinture].SetActive(true);
                break;
            }
        }
    }

    void ResetTimer()
    {
        fini = false;
        aDejaFaitSonTour = false;
        minute = 1;
    }

    void DesactiverToutesLesOriginels()
    {
        foreach (GameObject originel in originels)
        {
            originel.SetActive(false);
        }
    }
}
