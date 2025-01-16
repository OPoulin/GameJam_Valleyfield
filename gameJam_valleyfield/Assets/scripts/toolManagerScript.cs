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
        moneyText.text = "fonds: $" + money;
        Invoke("updateMoney", 1);
    }
}
