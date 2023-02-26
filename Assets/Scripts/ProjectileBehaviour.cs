using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] GameObject player;

    [Inject]
    PlayerStateManager stateManager;

   

    private void Awake()
    {
        player = GameObject.Find("player");
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Strong Enemy" || collision.tag == "Weak Enemy")
        {
            if (--collision.GetComponent<ProxyEnemy>().Hp >= 0)
            {
                collision.GetComponent<EnemySpawner>().DamageSpawner();

                if (stateManager.IsSuper)
                    stateManager.Counter--;
                else
                    stateManager.Counter++;

                gameObject.SetActive(false);
            }
        }
    }

    public class Factory : PlaceholderFactory<ProjectileBehaviour> { }


    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * speed * Time.deltaTime;
    }
}
