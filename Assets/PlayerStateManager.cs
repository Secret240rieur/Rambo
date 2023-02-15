using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{

    PlayerBaseState currentState;
    public PlayerNormalState normalState=new PlayerNormalState();
    public PlayerSuperState superState=new PlayerSuperState();


    // Start is called before the first frame update
    void Start()
    {
        currentState=normalState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<PlayerControl>().SuperState)
        {
            currentState = superState;
            superState.EnterState(this);
        }
        else
        {
            currentState = normalState;
            normalState.EnterState(this);
        }
    }


    //public void Switchstate(PlayerBaseState state)
    //{
    //    currentState = state;
    //    state.EnterState(this);
    //}

}
