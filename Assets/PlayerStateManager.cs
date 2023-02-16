using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{

    PlayerBaseState currentState;
    public PlayerNormalState normalState = new PlayerNormalState();
    public PlayerSuperState superState = new PlayerSuperState();

    Transform launchOffset;
    bool isLeft;

    private float elapsedTime = 0f;
    private float interval = .5f;

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

        if (elapsedTime >= interval)
        {

            if (gameObject.GetComponent<PlayerControl>().SuperState)
            {
                currentState = superState;
                superState.EnterState(this, launchOffset, isLeft);
            }
            else
            {
                currentState = normalState;
                normalState.EnterState(this, launchOffset, isLeft);
            }
            Debug.Log("isleft" + isLeft);
            elapsedTime = 0f;
        }
    }


    //public void Switchstate(PlayerBaseState state)
    //{
    //    currentState = state;
    //    state.EnterState(this);
    //}

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
           
        }

    }
}
