using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyEnemy : EnemySpawner
{
    EnemySpawner enemySpawner;
    [SerializeField] int countPoints=1;
    [SerializeField] int hp=5;
    [SerializeField] GameObject collectablePrefab;
    [SerializeField] float collectableSpawnChance = .1f;

    public int Hp { get => hp; set => hp = value; }

    // Start is called before the first frame update
    void Start()
    {
        GameObject spawner = transform.parent.gameObject;
        enemySpawner = spawner.GetComponent<EnemySpawner>();
    }


    public override void DamageSpawner()
    {
        if (Hp <= 0)
        {
            for (int i = 0; i < countPoints; i++)
            {
                enemySpawner.DamageSpawner();
            }
            gameObject.SetActive(false);
           SpawnCollectable();
        }
    }


    public void SpawnCollectable()
    {
        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber <= collectableSpawnChance)
        {
            GameObject collectable = Instantiate(collectablePrefab, transform.position, Quaternion.identity);
            collectable.SetActive(true);
        }
    }
}
