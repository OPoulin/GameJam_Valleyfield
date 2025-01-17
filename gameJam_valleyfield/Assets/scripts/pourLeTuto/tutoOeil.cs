using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoOeil : MonoBehaviour
{

    public GameObject peintureDeBase;
    public GameObject lOriginel;

    public bool surLaPeinture;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void activeLeTrucOriginel()
    {
        if (surLaPeinture == false)
        {
            peintureDeBase.SetActive(true);
            lOriginel.SetActive(false);
        }


        if (surLaPeinture == true)
        {
            peintureDeBase.SetActive(false);
            lOriginel.SetActive(true);
        }

        surLaPeinture = !surLaPeinture;
    }


}
