using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleInit : MonoBehaviour
{
    [SerializeField] GameObject menuPanel;
    [SerializeField] GameObject settingsPanel;


    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(true);
        settingsPanel.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
