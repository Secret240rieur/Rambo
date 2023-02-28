using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<EnemySpawner> enemySpawnerList = new List<EnemySpawner>();
    [SerializeField] bool isActive = true;
    [SerializeField] SceneData sceneData;
    [SerializeField] GameObject settingsPanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;


    [Inject]
    PlayerStateManager stateManager;

    public static GameManager Instance { get; private set; }


    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        settingsPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemySpawnerList.Count; i++)
        {


            if (!enemySpawnerList[i].gameObject.activeInHierarchy)
            {
                isActive = false;
            }
            else
            {
                isActive = true;
                break;
            }
        }

        if (!isActive)
        {
            if (sceneData)
                SceneManager.LoadScene(sceneData.name);
            else winPanel.SetActive(true);

        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (settingsPanel.activeInHierarchy)
            { settingsPanel.SetActive(false); Time.timeScale = 1; }
            else { settingsPanel.SetActive(true); Time.timeScale = 0; }
        }

        if (stateManager.HP <= 0)
        {
            settingsPanel.SetActive(true);
            losePanel.SetActive(true);
        }

    }
}
