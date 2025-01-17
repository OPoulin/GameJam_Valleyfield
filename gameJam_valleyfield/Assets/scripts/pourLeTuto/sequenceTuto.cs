using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sequenceTuto : MonoBehaviour
{

    public GameObject slide1;
    public GameObject slide2;
    public GameObject slide3;
    public GameObject slide4;
    public GameObject slide5;
    public GameObject slide6;
    public GameObject slide7;
    public GameObject slide8;

    public GameObject luiMeme;

    public float numero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Mouse0))
        {

            if (numero == 7f)
            {
                slide8.SetActive(false);
                luiMeme.SetActive(false);
            }

            if (numero == 6f)
            {
                slide7.SetActive(false);
                slide8.SetActive(true);
            }


            if (numero == 5f)
            {
                slide6.SetActive(false);
                slide7.SetActive(true);
            }

            if (numero == 4f)
            {
                slide5.SetActive(false);
                slide6.SetActive(true);
            }

            if (numero == 3f)
            {
                slide4.SetActive(false);
                slide5.SetActive(true);
            }


            if (numero == 2f)
            {
                slide3.SetActive(false);
                slide4.SetActive(true);
            }


            if (numero == 1f)
            {
                slide2.SetActive(false);
                slide3.SetActive(true);
            }

            if (numero == 0f)
            {
                slide1.SetActive(false);
                slide2.SetActive(true);
            }


            numero = numero + 1f;



        }
    }


    public void avanceTuto()
    {
      




    }



}
