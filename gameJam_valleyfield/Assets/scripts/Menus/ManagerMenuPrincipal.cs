using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMenuPrincipal : MonoBehaviour
{

    public GameObject membres;

    
    public void ActiverMembres()
    {
        if (membres.activeSelf == true)
        {
            membres.SetActive(false);
        }
        else
        {
            membres.SetActive(true);
        }
    }

    public void Jouer()
    {
        PartirMusic.menu.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        SceneManager.LoadScene("laCinematique");
    }

    public void Quitter()
    {
        Application.Quit();
    }
    
}
