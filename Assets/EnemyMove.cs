using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float speed;
    public GameObject player;


    private void Update()
    {
       float distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 dir = player.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

}
