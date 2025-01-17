using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class cinematiqueChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("fini", 36f);
    }

    public void fini()
    {
        sonCinematique.cinematique.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        SceneManager.LoadScene("DomMeurt2");
    }

}
