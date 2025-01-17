using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class debugTouche : MonoBehaviour
{
    public GameObject gestionPeinture;
    public GameObject gestionSculpture;

    public GameObject cene;
    public GameObject david;
    public GameObject monaLisa;
    public GameObject salvator;
    public GameObject venus;

    void Update()
    {
        //debug tool
        if (Input.GetKeyDown(KeyCode.A))
        {
            toolManagerScript.selectedToolName = "charpy";
            SetPeinture();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            toolManagerScript.selectedToolName = "paintRoller";
            SetPeinture();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            toolManagerScript.selectedToolName = "pinceau";
            SetPeinture();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            toolManagerScript.selectedToolName = "tape";
            SetPeinture();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            toolManagerScript.selectedToolName = "postIt";
            SetSculpture();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            toolManagerScript.selectedToolName = "essuiTout";
            SetSculpture();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            toolManagerScript.selectedToolName = "gomette";
            SetSculpture();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            toolManagerScript.selectedToolName = "playdoh";
            SetSculpture();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            toolManagerScript.selectedToolName = "marbre";
            SetSculpture();
        }


        //debug peinture
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetCene();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetDavid();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetMonaLisa();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetSalvator();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetVenus();
        }
    }

    public void SetCene()
    {
        cene.SetActive(true);
    }

    public void SetDavid()
    {
        david.SetActive(true);
    }

    public void SetMonaLisa()
    {
        monaLisa.SetActive(true);
    }

    public void SetSalvator()
    {
        salvator.SetActive(true);
    }

    public void SetVenus()
    {
        venus.SetActive(true);
    }

    public void SetSculpture()
    {
        gestionPeinture.SetActive(false);
        gestionSculpture.SetActive(true);
    }

    public void SetPeinture()
    {
        gestionSculpture.SetActive(false);
        gestionPeinture.SetActive(true);
    }
}
