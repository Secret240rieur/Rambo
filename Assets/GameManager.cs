using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<EnemySpawner> enemySpawnerList=new List<EnemySpawner>();
    [SerializeField] bool isActive = true;
    
    // Start is called before the first frame update
    void Start()
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

    }
}
