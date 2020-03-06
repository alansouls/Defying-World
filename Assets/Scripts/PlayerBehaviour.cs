using System.Collections;
using System.Collections.Generic;
using WorldEnum;
using UnityEngine;

public class PlayerBehaviour : CharacterBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.25f;
        jumpForce = 250f;
        life = 100;
        mana = 50;
        isOnGround = false;
        facing = FacingEnum.Right;
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Crouch();
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            Stand();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartFacingUp();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            StopFacingUp();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            life -= 5;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            mana -= 2;
        }
    }
}
