using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revealOrigniel : MonoBehaviour
{

    public GameObject laPeinture0;
    public GameObject originel0;

    public GameObject laPeinture1;
    public GameObject originel1;

    public GameObject laPeinture2;
    public GameObject originel2;

    public GameObject laPeinture3;
    public GameObject originel3;

    public GameObject laPeinture4;
    public GameObject originel4;

    public bool leBoutonEstActive;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lOriginel()
    {

        if (leBoutonEstActive == false)
        {
            if (timerSkip.laPeinture == 0f)
            {
                laPeinture0.SetActive(false);
                originel0.SetActive(true);
            }
            if (timerSkip.laPeinture == 1f)
            {
                laPeinture1.SetActive(false);
                originel1.SetActive(true);
            }
            if (timerSkip.laPeinture == 2f)
            {
                laPeinture2.SetActive(false);
                originel2.SetActive(true);
            }
            if (timerSkip.laPeinture == 3f)
            {
                laPeinture3.SetActive(false);
                originel3.SetActive(true);
            }
            if (timerSkip.laPeinture == 4f)
            {
                laPeinture4.SetActive(false);
                originel4.SetActive(true);
            }
        }


        if (leBoutonEstActive == true)
        {
            if (timerSkip.laPeinture == 0f)
            {
                laPeinture0.SetActive(true);
                originel0.SetActive(false);
            }
            if (timerSkip.laPeinture == 1f)
            {
                laPeinture1.SetActive(true);
                originel1.SetActive(false);
            }
            if (timerSkip.laPeinture == 2f)
            {
                laPeinture2.SetActive(true);
                originel2.SetActive(false);
            }
            if (timerSkip.laPeinture == 3f)
            {
                laPeinture3.SetActive(true);
                originel3.SetActive(false);
            }
            if (timerSkip.laPeinture == 4f)
            {
                laPeinture4.SetActive(true);
                originel4.SetActive(false);
            }

        }


        leBoutonEstActive = !leBoutonEstActive;


    }









}
