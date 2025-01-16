using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;



public class timerEnBarre : MonoBehaviour
{

    public float durability;

    public GameObject objetDurabilityBar;

    public bool dejaActif;

    // Start is called before the first frame update
    void Start()
    {
        durability = 0f;
        InvokeRepeating("leTemps", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        objetDurabilityBar.GetComponent<Image>().fillAmount = durability / 60;
    }
    void leTemps()
    {

        durability = durability + 1f;
       
    }

}
