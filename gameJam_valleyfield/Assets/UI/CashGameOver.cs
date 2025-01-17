using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CashGameOver : MonoBehaviour
{

    public TextMeshProUGUI textScore;

    // Start is called before the first frame update
    void Start()
    {
        textScore.text = "Argent total : " + toolManagerScript.staticMoney + "$";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
