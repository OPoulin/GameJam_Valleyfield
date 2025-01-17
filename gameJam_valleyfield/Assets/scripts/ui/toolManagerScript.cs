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
    public static float staticMoney;

    //shit pour changer mode
    string mode = "peinture";
    public GameObject outilsPeinture;
    public GameObject outilsStatue;

    int unlockedWaves;



    private void Start()
    {
        mode = "peinture";
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
       // print(selectedToolName + selectedToolIndex + " - " + selectedColor + " " + selectedColorIndex);

        //cash
        staticMoney = money;
    }


    public void unlockWave1()
    {
        if (unlockedWaves < 1)
        {
            unlockedWaves = 1;
        }
        unlockTool(1);
        unlockTool(4);
        unlockTool(7);
    }
    public void unlockWave2()
    {
        if (unlockedWaves < 2)
        {
            unlockedWaves = 2;
        }
        unlockTool(2);
        unlockTool(5);
        unlockTool(8);
    }
    public void unlockTool(int index)
    {
        toutesCases[index].GetComponent<toolPickUI>().isLocked = false;
        toutesCases[index].GetComponent<toolPickUI>().lockUnlock();
    }

    public void updateMoney()
    {
        moneyText.text = "Fonds: $" + money;
        Invoke("updateMoney", 1);
    }

    public void switchTools(string switchTo)
    {
        if(switchTo == "peinture" && mode != "peinture")
        {
            mode = "peinture";

            outilsStatue.SetActive(false);
            outilsPeinture.SetActive(true);
        }
        else if(switchTo == "statue" && mode != "statue")
        {
            mode = "statue";

            outilsPeinture.SetActive(false);
            outilsStatue.SetActive(true);
        }

        //print("unlockedWaves: "+ unlockedWaves);

        //make sure everything unlocked
        Invoke("switchUnlockForInvoke", .2f);
    }
    void switchUnlockForInvoke()
    {
        if (unlockedWaves == 1)
        {
            unlockWave1();
        }
        else if (unlockedWaves == 2)
        {
            unlockWave1();
            unlockWave2();
        }
    }
}
