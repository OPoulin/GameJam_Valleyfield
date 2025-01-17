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
    public GameObject objetpriceText;

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
        //OGposition = 0;

        objetpriceText.GetComponent<TextMeshProUGUI>().text = "$" + price;


        lockUnlock();
        //select charpy by default
        if(order == 0)
        {
            selectTool();
        }
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
                //print("gay");
            }
        }
    }


    //select and unlock
    public void selectTool()
    {
        if (!isLocked)
        {
            if(durability > 0)
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
                toolManagerScript.selectedToolIndex = order;
            }
            else
            {
                buy();
            }
        }
    }





    public void lockUnlock()
    {
        if (isLocked)
        {
            objetOpacity.SetActive(true);
            objetpriceText.SetActive(false);
            
        }
        else
        {
            objetOpacity.SetActive(false);
            objetpriceText.SetActive(true);
            objetpriceText.GetComponent<TextMeshProUGUI>().text = "$" + price;
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
                if(durability <= 0)
                {
                    objetDurabilityBar.SetActive(false);
                    objetpriceText.SetActive(true);
                }
                else
                {
                    objetDurabilityBar.SetActive(true);
                    objetpriceText.SetActive(false);
                }
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

    void buy()
    {
        toolManagerScript manager = GameObject.Find("toolManager").GetComponent<toolManagerScript>();
        if (manager.money > price)
        {
            manager.money -= price;
            manager.updateMoney();

            //isLocked = false;
            //lockUnlock();
            durability = 100;
        }



        ///////////////////
        manageDurability();
    }
}
