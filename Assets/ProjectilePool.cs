using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] List<GameObject> Projectilelist = new List<GameObject>();

    int poolIndex;


    public static ProjectilePool Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public GameObject GetPoolObject()
    {
        if (poolIndex == Projectilelist.Count)
            poolIndex = 0;

        return Projectilelist[poolIndex++];

    }
}
