using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] int pointsLeft = 10;

    void Start() => StartCoroutine(SpawnCoroutine());

    public virtual void DamageSpawner()
    {
        if(gameObject.activeSelf)
        if (--pointsLeft <= 0)
            gameObject.SetActive(false);
    }


    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                EnemyFactory.Instance.CreateWeakEnemy(this.gameObject.transform).transform.position = RandomPosition();
            }
            EnemyFactory.Instance.CreateStrongEnemy(this.gameObject.transform).transform.position = RandomPosition();
            yield return new WaitForSeconds(5);
        }
    }

    Vector3 RandomPosition() => transform.position + Random.insideUnitSphere;
}