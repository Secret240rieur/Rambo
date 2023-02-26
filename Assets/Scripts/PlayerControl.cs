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
}
