using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    [SerializeField] bool isSuper = false;
    [SerializeField] int counter = 0;
    PlayerBaseState currentState;
    public PlayerNormalState normalState = new PlayerNormalState();
    public PlayerSuperState superState = new PlayerSuperState();
    [SerializeField] int hp = 100;


    Transform launchOffset;
    bool isLeft;

    private float elapsedTime = 0f;
    private float interval = .5f;


    public int Counter { get => counter; set => counter = value; }
    public bool IsSuper { get => isSuper; set => isSuper = value; }
    public int HP { get => hp; set => hp = value; }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weak Enemy") HP -= 10;
        if (collision.gameObject.tag == "Strong Enemy") HP -= 40;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HP"))
            HP += 5;
    }


    // Start is called before the first frame update
    void Start()
    {
        currentState = normalState;
        launchOffset = GetComponent<PlayerControl>().LaunchOffset;
        isLeft = GetComponent<PlayerControl>().IsLeft;
        currentState.EnterState(this, launchOffset, isLeft);
    }

    // Update is called once per frame
    void Update()
    {
        launchOffset = GetComponent<PlayerControl>().LaunchOffset;
        isLeft = GetComponent<PlayerControl>().IsLeft;

        elapsedTime += Time.deltaTime;
        if (counter == 20)
        {
            IsSuper = true;
        }
        else if (counter == 0) { IsSuper = false; }

        if (elapsedTime >= interval)
        {

            if (isSuper)
            {
                currentState = superState;
                superState.EnterState(this, launchOffset, isLeft);
                if (HP < 80) HP = 80;
            }
            else
            {
                currentState = normalState;
                normalState.EnterState(this, launchOffset, isLeft);
            }
            elapsedTime = 0f;
        }
    }
}
