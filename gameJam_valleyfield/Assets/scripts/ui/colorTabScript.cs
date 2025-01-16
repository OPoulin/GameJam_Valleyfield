using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorTabScript : MonoBehaviour
{
    public Color laColor;
    public GameObject imageCouleur;

    public int order;

    public bool isSelected;

    float ogPos;
    public float movement;
    public float movementSpeed;



    // Start is called before the first frame update
    void Start()
    {
        toolManagerScript.allColorTabs[order] = gameObject;
        //print(toolManagerScript.allColorTabs[order]);

        imageCouleur.GetComponent<Image>().color = laColor;

        ogPos = transform.position.x;

        //select black by default
        if(order == 8)
        {
            selectColor();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            if(transform.position.x < ogPos + movement)
            {
                transform.Translate(movementSpeed, 0, 0);
            }
        }
        else
        {
            if(transform.position.x > ogPos)
            {
                transform.Translate(-movementSpeed, 0, 0);
            }
        }
    }

    public void selectColor()
    {
        foreach(GameObject couleur in toolManagerScript.allColorTabs)
        {
            if(couleur != null)
            {
                couleur.GetComponent<colorTabScript>().isSelected = false;
            }
        }

        isSelected = true;

        toolManagerScript.selectedColor = laColor;
        toolManagerScript.selectedColorIndex = order;
    }
}
