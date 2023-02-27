using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] float speed;
     GameObject player;

    private void Awake()
    {
        player = GameObject.Find("player");
    }

    private void Update()
    {
       float distance = Vector2.Distance(transform.position, player.transform.position);
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

}
