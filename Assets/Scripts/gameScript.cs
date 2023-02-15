using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameScript : MonoBehaviour
{

    [SerializeField] GameObject settingsPanel;


    private void Awake()
    {
        settingsPanel.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (settingsPanel.activeInHierarchy)
             settingsPanel.SetActive(false);            
            else settingsPanel.SetActive(true);
        }
    }
}
