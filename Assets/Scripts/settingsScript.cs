using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingsScript : MonoBehaviour
{
    //[SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject menuPanel;
    [SerializeField] SceneData sceneData;
    [SerializeField] SceneData GameScene1;


    private void Awake()
    {
    }

    public void HideSettings()
    {


        if (menuPanel)
            menuPanel.SetActive(true);
        else
        { 
            this.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void TitleScreen ()
    {
        SceneManager.LoadScene(sceneData.name);
    }


    public void Retry()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
        Time.timeScale = 1;
    }

    public void NewGame()
    {
        SceneManager.LoadScene(GameScene1.name);
    }

}
