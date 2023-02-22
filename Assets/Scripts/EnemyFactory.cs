using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : AbstractEnemyFactory
{
    public static EnemyFactory instance;

    [SerializeField] private GameObject weakEnemy;
    [SerializeField] private GameObject strongEnemy;

    private List<GameObject> weakEnemies = new List<GameObject>();
    private List<GameObject> strongEnemies = new List<GameObject>();
    private int poolSize = 100;

    public static EnemyFactory Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            GameObject gameObject = Instantiate(weakEnemy,this.gameObject.transform);
            weakEnemies.Add(gameObject);
            gameObject.SetActive(false);
            gameObject.tag = "Enemy";
        }

        for (int i = 0; i < poolSize; i++)
        {
            GameObject gameObject = Instantiate(strongEnemy, this.gameObject.transform);
            strongEnemies.Add(gameObject);
            gameObject.tag = "Enemy";
            gameObject.SetActive(false);
        }


    }

    public override GameObject CreateWeakEnemy(Transform parent)
    {

        for (int i = 0; i < weakEnemies.Count; i++)
        {
            if (!weakEnemies[i].activeInHierarchy)
            {
                weakEnemies[i].transform.SetParent(parent);
                weakEnemies[i].SetActive(true);
                return weakEnemies[i];
            }
        }

        return null;

    }

    public override GameObject CreateStrongEnemy(Transform parent)
    {

        for (int i = 0; i < strongEnemies.Count; i++)
        {
            if (!strongEnemies[i].activeInHierarchy)
            {
                strongEnemies[i].transform.SetParent(parent);
                strongEnemies[i].SetActive(true);
                return strongEnemies[i];
            }
        }

        return null;

    }
}
