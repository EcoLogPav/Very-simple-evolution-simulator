using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Interface : MonoBehaviour
{
    public GameObject UI;
    public bool isVisible=false;
    public bool isPaused = false;
    public TMP_Text PauseTag;
  public void Quit()
    {
        Application.Quit();
    }
    public void InterfaceIsVisible()
    {
        isVisible = !isVisible;
        if (isVisible)
        {
            UI.SetActive(true);
        }
        else
        {
            UI.SetActive(false);
        }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
   public void PauseCheck()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            PauseTag.text = "//isPaused";
            Time.timeScale = 0;

        }
        else
        {
            PauseTag.text = "";
            Time.timeScale = 1;
        }
    }
}
