using System.Collections;
using System.Collections.Generic;
using WorldEnum;
using UnityEngine;

public abstract class CharacterBehaviour : MonoBehaviour
{
    public int life;
    public int mana;
    public float speed;
    public float crouchedSpeed;
    public float jumpForce;

    protected new Rigidbody2D rigidbody;

    public bool isOnGround;
    public bool isCrouched;
    
    public FacingEnum facing;
    public void Stand()
    {
        gameObject.transform.localScale += new Vector3(0, 0.25f, 0);
        isCrouched = false;
    }

    public void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce);
    }

    public void MoveLeft()
    {
        gameObject.transform.Translate(-speed, 0, 0);
        if (facing < FacingEnum.Up)
            facing = FacingEnum.Left;
        else 
            facing = FacingEnum.UpLeft;
    }

    public void MoveRight()
    {
        gameObject.transform.Translate(speed, 0, 0);
        if (facing < FacingEnum.Up)
            facing = FacingEnum.Right;
        else 
            facing = FacingEnum.UpRight;
    }

    public void Crouch()
    {
        gameObject.transform.localScale += new Vector3(0, -0.25f, 0);
        isCrouched = true;
    }


    public void StopFacingUp()
    {
        facing -= 3;
    }

    public void StartFacingUp()
    {
        facing = FacingEnum.Up + (int)facing + 1;
    }

    protected void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.gameObject.tag == "floor"){
            isOnGround = true;
        }
    }

    protected void OnCollisionExit2D(Collision2D other) {
        if (other.collider.gameObject.tag == "floor"){
            isOnGround = false;
        }
    }
}
