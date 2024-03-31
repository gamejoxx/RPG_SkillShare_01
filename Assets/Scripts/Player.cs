using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField] int moveSpeed = 1;
    [SerializeField] Rigidbody2D PlayerRigidBody;
    [SerializeField] Animator playerAnimator;

    public string transitionName;



    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        PlayerRigidBody.velocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;

        playerAnimator.SetFloat("movementX", PlayerRigidBody.velocity.x);
        playerAnimator.SetFloat("movementY", PlayerRigidBody.velocity.y);

        if(horizontalMovement != 0 || verticalMovement != 0)
        {
            playerAnimator.SetFloat("lastX", horizontalMovement);
            playerAnimator.SetFloat("lastY", verticalMovement);
        }


    }
}