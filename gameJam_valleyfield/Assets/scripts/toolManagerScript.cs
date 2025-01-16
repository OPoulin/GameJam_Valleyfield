using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolManagerScript : MonoBehaviour
{
    public static GameObject[] toutesCases = new GameObject[6];
    public static string selectedToolName;
    public static int selectedToolIndex;

    //new class
    public tool[] allTools = new tool[9];
    

    void Start()
    {
        defineTools();
    }

    public void defineTools()
    {
        allTools[0] = new tool();
            allTools[0].name = "charpy";
            allTools[0].isLocked = false;
    }

    public class tool
    {
        public string name;
        public bool isLocked = true;
        public float price = 0;
        public bool hasDurability = false;
        public float durability = 0;
        public string dimension = "both";
    }

}
