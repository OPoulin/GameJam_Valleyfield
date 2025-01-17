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
    public GameObject retourMenu;

    //Les Canvas
    public GameObject canvasAtelier;
    public GameObject canvasMusee;
    public List<GameObject> oeuvreExpose;

    //positions des arts finis
    public Transform posCene;
    public Transform posDavid;
    public Transform posMonaLisa;
    public Transform posSalvator;
    public Transform posVenus;
    public Transform posBuste;
    public Transform posPenseur;
    public Transform posStatue;

    private int phaseActuelle = 0;

    public bool empecherSkip = false;


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
        if(!empecherSkip)
        {
            skip = true;
        }
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
        //print("prendreUnePeinture");
        if (oeuvreFini != null)
        {
            GameObject oeuvreMusee = Instantiate(oeuvreFini);
            //print(oeuvreMusee.name);
            if (oeuvreMusee.name == "Cene(Clone)")
            {
                print("OK");
                oeuvreMusee.transform.position = posCene.position;
                oeuvreMusee.transform.rotation = posCene.rotation;
                oeuvreExpose.Add(oeuvreMusee);
                oeuvreMusee.SetActive(false);
            }
            else if (oeuvreMusee.name == "David(Clone)")
            {
                print("OK");
                oeuvreMusee.transform.position = posDavid.position;
                oeuvreMusee.transform.rotation = posDavid.rotation;
                oeuvreExpose.Add(oeuvreMusee);
                oeuvreMusee.SetActive(false);
            }
            else if (oeuvreMusee.name == "MonaLisa(Clone)")
            {
                print("OK");
                oeuvreMusee.transform.position = posMonaLisa.position;
                oeuvreMusee.transform.rotation = posMonaLisa.rotation;
                oeuvreExpose.Add(oeuvreMusee);
                oeuvreMusee.SetActive(false);
            }
            else if (oeuvreMusee.name == "Salvator(Clone)")
            {
                print("OK");
                oeuvreMusee.transform.position = posSalvator.position;
                oeuvreMusee.transform.rotation = posSalvator.rotation;
                oeuvreExpose.Add(oeuvreMusee);
                oeuvreMusee.SetActive(false);
            }
            else if (oeuvreMusee.name == "Venus(Clone)")
            {
                print("OK");
                oeuvreMusee.transform.position = posVenus.position;
                oeuvreMusee.transform.rotation = posVenus.rotation;
                oeuvreExpose.Add(oeuvreMusee);
                oeuvreMusee.SetActive(false);
            }
            else if (oeuvreMusee.name == "Statue1(Clone)")
            {
                print("OK");
                oeuvreMusee.transform.position = posStatue.position;
                oeuvreMusee.transform.rotation = posStatue.rotation;
                oeuvreExpose.Add(oeuvreMusee);
                oeuvreMusee.SetActive(false);
            }
            else if (oeuvreMusee.name == "Buste(Clone)")
            {
                print("OK");
                oeuvreMusee.transform.position = posBuste.position;
                oeuvreMusee.transform.rotation = posBuste.rotation;
                oeuvreExpose.Add(oeuvreMusee);
                oeuvreMusee.SetActive(false);
            }
            else if (oeuvreMusee.name == "Penseur(Clone)")
            {
                print("OK");
                oeuvreMusee.transform.position = posPenseur.position;
                oeuvreMusee.transform.rotation = posPenseur.rotation;
                oeuvreExpose.Add(oeuvreMusee);
                oeuvreMusee.SetActive(false);
            }
            GameObject verif = oeuvreFini.transform.GetChild(0).gameObject;
            //float pourcent = verif.GetComponent<CompareTextures>().PerformComparison(verif.GetComponent<CompareTextures>().objectA, verif.GetComponent<CompareTextures>().objectBBase, verif.GetComponent<CompareTextures>().objectBTransparent);
            verif.GetComponent<CompareTextures>().PerformComparison(verif.GetComponent<CompareTextures>().objectA, verif.GetComponent<CompareTextures>().objectBBase, verif.GetComponent<CompareTextures>().objectBTransparent);

            if (verif.GetComponent<TrouManager>())
            {
                verif.GetComponent<TrouManager>().VerifierTrou();
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
                Invoke("CheckStatue", 0.1f);
                break;
            }
        }
    }

    public void CalculFin(float pourcent)
    {
        print(pourcent + "% final");
        if (oeuvreFini.tag == "statue")
        {
            float moneyAlert = (500 * pourcent / 100) + seconde / 3;
            toolGester.GetComponent<toolManagerScript>().money += Mathf.Round(moneyAlert);
            if (moneyAlert < 200)
            {
                RuntimeManager.PlayOneShot(AllSFX.huement);
            }
        }
        else if (oeuvreFini.tag == "peinture")
        {
            float moneyAlert = (400 * pourcent / 100) + seconde / 3;
            toolGester.GetComponent<toolManagerScript>().money += Mathf.Round(moneyAlert);
            if (moneyAlert < 200)
            {
                RuntimeManager.PlayOneShot(AllSFX.huement);
            }
        }
    }


    public void CheckStatue()
    {
        toolGester.GetComponent<toolManagerScript>().switchTools("peinture");
        if (oeuvres[laPeinture].gameObject.tag == "statue")
        {
            toolGester.GetComponent<toolManagerScript>().switchTools("statue");
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

    public void Delai()
    {
        empecherSkip = true;
        Invoke("DelaiTrue", 2f);
    }

    public void DelaiTrue()
    {
        empecherSkip = false;
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
                if (toolGester.GetComponent<toolManagerScript>().money > 1000)
                {
                    retourMenu.SetActive(true);
                    cameraMusee.SetActive(true);
                    cameraJeu.SetActive(false);
                    canvasAtelier.SetActive(false);
                    canvasMusee.SetActive(true);

                    foreach(GameObject obj in oeuvreExpose)
                    {
                        obj.SetActive(true);
                    }

                    PartirMusic.jeu.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    PartirMusic.victoire = RuntimeManager.CreateInstance(AllMusic.victoire);
                    PartirMusic.victoire.start();
                }
                else
                {
                    PartirMusic.jeu.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    SceneManager.LoadScene(3);
                }
                break;
        }
    }
}
