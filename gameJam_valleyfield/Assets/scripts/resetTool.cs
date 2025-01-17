using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetTool : MonoBehaviour
{
    public List<GameObject> ctnTool;

    public void remettreCharpy()
    {
        foreach (GameObject obj in ctnTool)
        {
            obj.GetComponent<toolPickUI>().isSelected = false;
        }
        toolManagerScript.selectedToolName = "charpy";
        ctnTool[0].GetComponent<toolPickUI>().selectTool();
    }
}
