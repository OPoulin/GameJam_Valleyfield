using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoireRetour : MonoBehaviour
{
    bool retour = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("boolUP", 52f);
    }

    // Update is called once per frame
    void Update()
    {
        if (retour)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                PartirMusic.victoire.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                SceneManager.LoadScene("MenuPrincipal");
            }
        }
    }

    void boolUP()
    {
            retour = true;
    }
}
