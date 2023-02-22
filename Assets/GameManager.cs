using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<EnemySpawner> enemySpawnerList=new List<EnemySpawner>();
    [SerializeField] bool isActive = true; 
    [SerializeField] SceneData sceneData;


    public static GameManager Instance { get; private set; }


    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;

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

        if(!isActive)
        {
            if (sceneData)
                SceneManager.LoadScene(sceneData.name);
            else Debug.Log("win");
        }

    }
}
