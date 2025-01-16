using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomiser : MonoBehaviour
{
    public int laPeinture;
    public GameObject gestionPeinture;

    public List<int> listeRandom;
 

    // Start is called before the first frame update
    void Start()
    {
       laPeinture = Random.Range(0, 5);
        print(laPeinture);
        gestionPeinture.GetComponent<selectionnerPeinture>().ChangerPeinture(laPeinture);
       
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
