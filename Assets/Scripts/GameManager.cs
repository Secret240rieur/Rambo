using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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
    [SerializeField] GameObject sliderHp;
    [SerializeField] int portionHp = 0;


    [Inject]
    PlayerStateManager stateManager;

    public static GameManager Instance { get; private set; }
    public int PortionHp { get => portionHp; set => portionHp = value; }

    BinaryFormatter binaryFormatter = new BinaryFormatter();



    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        settingsPanel.SetActive(false);
        losePanel.SetActive(false);

        LoadPortionData();



    }


    private void Start()
    {

        
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
            else
            {
                winPanel.SetActive(true);
                sliderHp.SetActive(false);
            }

        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (settingsPanel.activeInHierarchy)
            { settingsPanel.SetActive(false); Time.timeScale = 1; sliderHp.SetActive(true); }
            else { settingsPanel.SetActive(true); Time.timeScale = 0; sliderHp.SetActive(false); }
        }

        if (stateManager.HP <= 0)
        {
            settingsPanel.SetActive(true);
            losePanel.SetActive(true);
            sliderHp.SetActive(false);
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            if (portionHp > 0 && !settingsPanel.activeInHierarchy&&!losePanel.activeInHierarchy)
            {
                stateManager.HP++;
                portionHp--;
                SavePortionData();
            }
        }



    }


    public void SavePortionData()
    {
        GameData gameData = new GameData();

        gameData.HpPortion = PortionHp;


        FileStream fileStream = new FileStream(Application.persistentDataPath + "/gameData.dat", FileMode.Create);

        binaryFormatter.Serialize(fileStream, gameData);
        fileStream.Close();
    }


    public void LoadPortionData()
    {
        GameData loadedGameData;

        if (File.Exists(Application.persistentDataPath + "/gameData.dat"))
        {
            FileStream fileStream = new FileStream(Application.persistentDataPath + "/gameData.dat", FileMode.Open);
            loadedGameData = (GameData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            portionHp = loadedGameData.HpPortion;
            Debug.Log("Loaded score: " + loadedGameData.HpPortion);
        }
        else
        {
            Debug.Log("No saved game data found.");
        }
    }
}


    
