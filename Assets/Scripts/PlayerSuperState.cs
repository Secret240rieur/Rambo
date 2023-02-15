
using UnityEngine;

public class PlayerSuperState : PlayerBaseState
{
   public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("super state");
    }

}
