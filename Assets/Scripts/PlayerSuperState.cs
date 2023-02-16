
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSuperState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player, Transform launchOffset, bool isLeft)
    {
        GameObject ProjectileObject = ProjectilePool.Instance.GetPoolObject();
        GameObject ProjectileObject1 = ProjectilePool.Instance.GetPoolObject();
        GameObject ProjectileObject2 = ProjectilePool.Instance.GetPoolObject();


        if (isLeft)
        {
            launchOffset.localPosition = new Vector3(-0.05f, 0.0012f, 0f);
            ProjectileObject.transform.rotation = Quaternion.Euler(0, 0, 180f);
            ProjectileObject1.transform.rotation = Quaternion.Euler(0, 0, 160f);
            ProjectileObject2.transform.rotation = Quaternion.Euler(0, 0, -160f);
        }
        else
        {
            launchOffset.localPosition = new Vector3(0.0429f, 0.0012f, 0f);
            ProjectileObject.transform.rotation = Quaternion.identity;
            ProjectileObject1.transform.rotation = Quaternion.Euler(0, 0, 20f);
            ProjectileObject2.transform.rotation = Quaternion.Euler(0, 0, -20f);
        }


        ProjectileObject.transform.position = launchOffset.position;
        ProjectileObject1.transform.position = launchOffset.position;
        ProjectileObject2.transform.position = launchOffset.position;


        ProjectileObject.SetActive(true);
        ProjectileObject1.SetActive(true);
        ProjectileObject2.SetActive(true);

    }

}
