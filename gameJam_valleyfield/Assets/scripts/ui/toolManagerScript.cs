using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class toolManagerScript : MonoBehaviour
{
    public static GameObject[] toutesCases = new GameObject[6];
    public static string selectedToolName;
    public static int selectedToolIndex;

    public static GameObject[] allColorTabs = new GameObject[9];
    public static Color selectedColor;
    public static int selectedColorIndex;

    public TextMeshProUGUI moneyText;
    public float money;

    private void Start()
    {
        updateMoney();
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
}
