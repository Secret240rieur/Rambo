using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] SetVol setVol;
    [SerializeField] SceneData sceneData;

    private void Awake()
    {
        setVol.Init();
    }


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showSettings()
    {
        menuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

   public void startGame()
    {
        SceneManager.LoadScene(sceneData.name);
    }

    public void quit()
    {
        Application.Quit();
    }
}
