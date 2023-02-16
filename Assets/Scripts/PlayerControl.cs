using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed = .1f;
    [SerializeField] Transform launchOffset;
    [SerializeField] bool superState = false;
    Animator animator;
    [SerializeField] bool isLeft=false;

    public bool SuperState { get => superState; set => superState = value; }
    public Transform LaunchOffset { get => launchOffset; set => launchOffset = value; }
    public bool IsLeft { get => isLeft; set => isLeft = value; }

    private void Start()
    {
        //StartCoroutine(Shoot());
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"), 0);

        transform.position += move.normalized
            * speed * Time.fixedDeltaTime;

        animator.SetFloat("h",move.x);
        animator.SetFloat("v",move.y);


        if (Input.GetKey(KeyCode.D)) IsLeft = false;
        else if (Input.GetKey(KeyCode.A)) IsLeft = true;

    }





    //IEnumerator Shoot()
    //{
    //    while (true)
    //    {
    //        yield return new WaitForSeconds(0.5f);
            
    //        GameObject ProjectileObject = ProjectilePool.Instance.GetPoolObject();
    //        if (IsLeft)
    //        {
    //            launchOffset.localPosition = new Vector3(-0.05f, 0.0012f, 0f);
    //            ProjectileObject.transform.rotation = Quaternion.Euler(0, 0, 180f);
    //        }
    //        else
    //        {
    //            launchOffset.localPosition = new Vector3(0.0429f, 0.0012f, 0f);
    //            ProjectileObject.transform.rotation = Quaternion.identity;
    //        }
    //        ProjectileObject.transform.position = launchOffset.position;

    //        ProjectileObject.SetActive(true);
    //        if (superState)
    //        {
    //            GameObject ProjectileObject1 = ProjectilePool.Instance.GetPoolObject();
    //            GameObject ProjectileObject2 = ProjectilePool.Instance.GetPoolObject();
    //            ProjectileObject1.transform.position = launchOffset.position;
    //            ProjectileObject2.transform.position = launchOffset.position;
    //            ProjectileObject1.transform.rotation = Quaternion.Euler(0, 0, 20f);
    //            ProjectileObject2.transform.rotation = Quaternion.Euler(0, 0, -20f);
    //            ProjectileObject1.SetActive(true);
    //            ProjectileObject2.SetActive(true);
    //        }
    //    }
    //}


}
