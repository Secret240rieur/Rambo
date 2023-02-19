
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerNormalState : PlayerBaseState
{

    public override void EnterState(PlayerStateManager player, Transform LaunchOffset,bool isLeft)
    {
        
        GameObject ProjectileObject = ProjectilePool.Instance.GetPoolObject();
        if (isLeft)
        {
            LaunchOffset.localPosition = new Vector3(-0.05f, 0.0012f, 0f);
            ProjectileObject.transform.rotation = Quaternion.Euler(0, 0, -90f);
        }
        else
        {
            LaunchOffset.localPosition = new Vector3(0.0429f, 0.0012f, 0f);
            ProjectileObject.transform.rotation = Quaternion.Euler(0, 0, 90f);
        }
        ProjectileObject.transform.position = LaunchOffset.position;

        ProjectileObject.SetActive(true);
       
    }
}
