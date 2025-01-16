using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class cinematiqueChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("fini", 36f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void fini()
    {
        SceneManager.LoadScene("Atelier");
    }

}
