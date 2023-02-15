using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    void Start() => StartCoroutine(SpawnCoroutine());

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                EnemyFactory.Instance.CreateWeakEnemy().transform.position = RandomPosition();
            }
            EnemyFactory.Instance.CreateStrongEnemy().transform.position = RandomPosition();
            yield return new WaitForSeconds(5);
        }
    }

    Vector3 RandomPosition() => transform.position + Random.insideUnitSphere;
}
