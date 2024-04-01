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

    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    public bool deactivateMovement = false;



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

        if(deactivateMovement)
        {
            PlayerRigidBody.velocity = Vector2.zero;
        }
        else
        {
            PlayerRigidBody.velocity = new Vector2(horizontalMovement, verticalMovement) * moveSpeed;
        }

        playerAnimator.SetFloat("movementX", PlayerRigidBody.velocity.x);
        playerAnimator.SetFloat("movementY", PlayerRigidBody.velocity.y);

        if(horizontalMovement != 0 || verticalMovement != 0)
        {
            if(!deactivateMovement) // look arround while taling to npc
            {
                playerAnimator.SetFloat("lastX", horizontalMovement);
                playerAnimator.SetFloat("lastY", verticalMovement);
            }
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, bottomLeftEdge.x, topRightEdge.x),
            Mathf.Clamp(transform.position.y, bottomLeftEdge.y, topRightEdge.y),
            transform.position.z);

    }

    public void SetLimits(Vector3 bottomLeft, Vector3 topRight)
    {
        bottomLeftEdge = bottomLeft;
        topRightEdge = topRight;
    }

}