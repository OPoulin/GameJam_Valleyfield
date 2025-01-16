using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class toolPickUI : MonoBehaviour
{
    public string outil;
    public Texture fichierImage;
    public int order;

    public GameObject objetImage;
    public GameObject objetOpacity;
    public GameObject objetDurabilityBar;

    public bool isLocked;
    public float price = 2;

    public bool hasDurability;
    public float durability = 100; 

    public bool isSelected;

    float OGposition;
    public float movement;
    public float movementSpeed;

    void Start()
    {

        objetImage.GetComponent<RawImage>().texture = fichierImage;

        /*
        RawImage image = objetOpacity.GetComponent<RawImage>();
        image.color = new Color(0, 0, 0, .2f);
        */

        toolManagerScript.toutesCases[order] = gameObject;
        //print(toolManagerScript.toutesCases[0]);

        OGposition = transform.position.x;

        lockUnlock();
    }

    private void Update()
    {
        if (isSelected)
        {
            if(transform.position.x < OGposition + movement)
            {
                transform.Translate(movementSpeed, 0, 0);
            }
        }
        else
        {
            if (transform.position.x > OGposition)
            {
                transform.Translate(-movementSpeed, 0, 0);
            }
        }
    }


    //select and unlock
    public void selectTool()
    {
        if (!isLocked)
        {
            foreach (GameObject uneCase in toolManagerScript.toutesCases)
            {
                if (uneCase != null)
                {
                    uneCase.GetComponent<toolPickUI>().isSelected = false;
                    /*
                    RawImage image1 = uneCase.GetComponent<toolPickUI>().objetOpacity.GetComponent<RawImage>();
                    image1.color = new Color(0, 0, 0, .2f);
                    */
                }
            }

            isSelected = true;
            /*
            RawImage image = objetOpacity.GetComponent<RawImage>();
            image.color = new Color(0, 0, 0, .7f);
            */

            toolManagerScript.selectedToolName = outil;
            toolManagerScript.selectedToolIndex = order - 1;

            //print(toolManagerScript.selectedToolName);
        }
        else
        {
            toolManagerScript manager = GameObject.Find("toolManager").GetComponent<toolManagerScript>();
            if(manager.money > price)
            {
                manager.money -= price;

                isLocked = false;
                lockUnlock();
            }
        }
    }

    public void lockUnlock()
    {
        if (isLocked)
        {
            objetOpacity.SetActive(true);
        }
        else
        {
            objetOpacity.SetActive(false);
        }
            manageDurability();
    }

    void manageDurability()
    {
        if (!isLocked)
        {
            //on start and unlock
            if (hasDurability)
            {
                objetDurabilityBar.SetActive(true);
                //print("hasDurability");
            }
            else
            {
                objetDurabilityBar.SetActive(false);
                //print("noDurability");
            }
        }
        else
        {
            objetDurabilityBar.SetActive(false);
            //print("isLock");
        }

        //update durability
        objetDurabilityBar.GetComponent<Image>().fillAmount = durability / 100;
    }
}
