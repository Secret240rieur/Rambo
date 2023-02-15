using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
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
            GameObject gameObject = Instantiate(weakEnemy);
            weakEnemies.Add(gameObject);
            gameObject.SetActive(false);
        }

        for (int i = 0; i < poolSize; i++)
        {
            GameObject gameObject = Instantiate(strongEnemy);
            strongEnemies.Add(gameObject);
            gameObject.SetActive(false);
        }


    }

    public GameObject CreateWeakEnemy()
    {

        for (int i = 0; i < weakEnemies.Count; i++)
        {
            if (!weakEnemies[i].activeInHierarchy)
            {
                weakEnemies[i].SetActive(true);
                return weakEnemies[i];
            }
        }

        return null;

    }

    public GameObject CreateStrongEnemy()
    {

        for (int i = 0; i < strongEnemies.Count; i++)
        {
            if (!strongEnemies[i].activeInHierarchy)
            {
                strongEnemies[i].SetActive(true);
                return strongEnemies[i];
            }
        }

        return null;

    }
}
