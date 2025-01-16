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

        }
        else if (scene.name == "Fin")
        {
            /*Si on a le cash, on joue la musique de victoire, sinon on joue celle de defaite*/
        }
    }
}
