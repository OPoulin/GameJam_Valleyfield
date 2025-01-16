using FMOD.Studio;
using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonCinematique : MonoBehaviour
{

    public static EventInstance cinematique;

    private void Start()
    {
        cinematique = RuntimeManager.CreateInstance(AllSFX.cinematique);
        cinematique.start();
    }
}
