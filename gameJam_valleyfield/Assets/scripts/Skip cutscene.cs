using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Skipcutscene : MonoBehaviour
{
    public TextMeshProUGUI passer;
    bool abc = false;


    // Start is called before the first frame update
    void Start()
    {
        passer.color = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            passer.color = Color.white;
            Invoke("Countdown", 2f);
            abc = true;
        }

        if (abc == true && Input.GetKeyDown(KeyCode.Return))
        {
            sonCinematique.cinematique.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            SceneManager.LoadScene(1);
        }
    }

    void Countdown()
    {
        passer.color = Color.clear;
        abc = false;
    }
}
