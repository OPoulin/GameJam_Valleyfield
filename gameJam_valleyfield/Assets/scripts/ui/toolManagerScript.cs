using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class toolManagerScript : MonoBehaviour
{
    public static GameObject[] toutesCases = new GameObject[9];
    public static string selectedToolName;
    public static int selectedToolIndex;

    public static GameObject[] allColorTabs = new GameObject[9];
    public static Color selectedColor;
    public static int selectedColorIndex;

    public TextMeshProUGUI moneyText;
    public float money;

    //shit pour changer mode
    string mode = "peinture";
    public GameObject outilsPeinture;
    public GameObject outilsStatue;



    private void Start()
    {
        updateMoney();
        //switchTools("peinture");
    }

    void Update()
    {
        ///*
        //les couleurs apparaissent seulement si on a un outil qui change de couleure
        if(selectedToolIndex == 1 || selectedToolIndex == 2)
        {
            foreach(GameObject tab in allColorTabs)
            {
                tab.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject tab in allColorTabs)
            {
                tab.SetActive(false);
            }
        }
        //*/
        print(
            selectedToolName + selectedToolIndex + " - " + selectedColor + " " + selectedColorIndex
        );
    }

    public void unlockTool()
    {
        //called in toolPickUI script

    }

    public void updateMoney()
    {
        moneyText.text = "Fonds: $" + money;
        Invoke("updateMoney", 1);
    }

    public void switchTools(string switchTo = null)
    {
        if(switchTo == "peinture")
        {
            mode = "peinture";

            outilsStatue.SetActive(false);
            outilsPeinture.SetActive(true);
        }
        else if(switchTo == "statue")
        {
            mode = "statue";

            outilsPeinture.SetActive(false);
            outilsStatue.SetActive(true);
            print(mode);
        }
    }
}
