using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMenuPause : MonoBehaviour
{

    public GameObject menu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menu.activeSelf == false)
        {
            menu.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menu.activeSelf == true)
        {
            menu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void Continuer()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RetourMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
