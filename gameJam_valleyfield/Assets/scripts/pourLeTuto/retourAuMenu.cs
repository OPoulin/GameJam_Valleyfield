using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class retourAuMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeLaScene()
    {
        PartirMusic.menu.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        SceneManager.LoadScene("MenuPrincipal");
    }


    public void vasAuTuto()
    {
        SceneManager.LoadScene("leReelTUTO");
    }

}
