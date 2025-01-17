using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PartirMusic : MonoBehaviour
{

    Scene scene;
    public static EventInstance menu;
    public static EventInstance jeu;
    public static EventInstance deliberation;
    public static EventInstance victoire;
    public static EventInstance defaite;

    // Start is called before the first frame update
    void Start()
    {
        /* On pogne les musiques */



        /* On recupere la scene active */
        scene = SceneManager.GetActiveScene();

        if (scene == null)
        {
            return;
        }
        else if (scene.name == "MenuPrincipal")
        {
            menu = RuntimeManager.CreateInstance(AllMusic.menu);
            menu.start();
        }
        else if (scene.name == "Atelier")
        {
            jeu = RuntimeManager.CreateInstance(AllMusic.jeu);
            jeu.start();
        }
        else if (scene.name == "MuseeGLubert")
        {
            victoire = RuntimeManager.CreateInstance(AllMusic.victoire);
            victoire.start();
        }
        else if (scene.name == "TaxManOffice")
        {
            defaite = RuntimeManager.CreateInstance(AllMusic.defaite);
            defaite.start();
        }
    }
}
