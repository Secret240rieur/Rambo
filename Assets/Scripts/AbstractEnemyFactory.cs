using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemyFactory : MonoBehaviour
{
    public abstract GameObject CreateWeakEnemy(Transform parent);
    public abstract GameObject CreateStrongEnemy(Transform parent);
}
