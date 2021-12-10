using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHide : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuButton;
    [SerializeField] private GameObject quitButton;
    [SerializeField] private GameObject backdrop;
    //[SerializeField] private GameObject clockObject;

    private bool isMenuActive = false;

    // Update is called once per frame
    void Update()
    {
        Menu();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuActive = !isMenuActive;
        }
    }

    public void Menu()
    {
        if(isMenuActive == true)
        {
            mainMenuButton.SetActive(true);
            quitButton.SetActive(true);
            backdrop.SetActive(true);
            //clockObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if(isMenuActive == false)
        {
            mainMenuButton.SetActive(false);
            quitButton.SetActive(false);
            backdrop.SetActive(false);
            //clockObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
