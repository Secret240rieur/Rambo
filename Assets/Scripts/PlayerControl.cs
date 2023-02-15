using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float speed = .1f;
    [SerializeField] Transform LaunchOffset;
    [SerializeField] bool superState = false;
    Animator animator;

    public bool SuperState { get => superState; set => superState = value; }

    private void Start()
    {
        StartCoroutine(Shoot());

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"), 0);

        transform.position += move
            * speed * Time.deltaTime;

    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            GameObject ProjectileObject = ProjectilePool.Instance.GetPoolObject();
            ProjectileObject.transform.position = LaunchOffset.position;
            ProjectileObject.transform.rotation = Quaternion.identity;
            ProjectileObject.SetActive(true);
            if (superState)
            {
                GameObject ProjectileObject1 = ProjectilePool.Instance.GetPoolObject();
                GameObject ProjectileObject2 = ProjectilePool.Instance.GetPoolObject();
                ProjectileObject1.transform.position = LaunchOffset.position;
                ProjectileObject2.transform.position = LaunchOffset.position;
                ProjectileObject1.transform.rotation = Quaternion.Euler(0, 0, 20f);
                ProjectileObject2.transform.rotation = Quaternion.Euler(0, 0, -20f);
                ProjectileObject1.SetActive(true);
                ProjectileObject2.SetActive(true);
            }
        }
    }


}
