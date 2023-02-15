using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingsScript : MonoBehaviour
{
    //[SerializeField] GameObject settingsPanel;
    GameObject menuPanel;
    [SerializeField] SceneData sceneData;

    private void Awake()
    {
        menuPanel = GameObject.Find("Menu_Panel");
    }

    public void HideSettings()
    {

        this.gameObject.SetActive(false);

        if (menuPanel != null)
            menuPanel.SetActive(true);
    }

    public void TitleScreen ()
    {
        SceneManager.LoadScene(sceneData.name);
    }

}
