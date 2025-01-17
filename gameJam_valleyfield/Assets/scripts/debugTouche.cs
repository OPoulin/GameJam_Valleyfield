using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugTouche : MonoBehaviour
{
    public GameObject monaLisa;

    void Update()
    {
        //debug tool
        if (Input.GetKeyDown(KeyCode.A))
        {
            toolManagerScript.selectedToolName = "charpy";
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            toolManagerScript.selectedToolName = "paintRoller";
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            toolManagerScript.selectedToolName = "pinceau";
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            toolManagerScript.selectedToolName = "tape";
        }


        //debug peinture
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            monaLisa.SetActive(true);
        }
    }
}
