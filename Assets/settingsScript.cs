using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsScript : MonoBehaviour
{
    //[SerializeField] GameObject settingsPanel;
    GameObject menuPanel;


    private void Awake()
    {
        menuPanel = GameObject.Find("Menu_Panel");
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HideSettings()
    {

        this.gameObject.SetActive(false);

        if (menuPanel != null)
            menuPanel.SetActive(true);
    }
}
