using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public int life;
    public int mana;
    public float speed;
    public float crouchedSpeed;
    public float jumpForce;

    private new Rigidbody2D rigidbody;

    public bool isOnGround;
    public bool isCrouched;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.25f;
        jumpForce = 250f;
        life = 100;
        mana = 50;
        isOnGround = false;
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
    }

    public void Stand()
    {
        gameObject.transform.localScale += new Vector3(0, 0.25f, 0);
    }

    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce);
    }

    private void MoveLeft()
    {
        gameObject.transform.Translate(-speed, 0, 0);
    }

    private void MoveRight()
    {
        gameObject.transform.Translate(speed, 0, 0);
    }

    private void Crouch()
    {
        gameObject.transform.localScale += new Vector3(0, -0.25f, 0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.collider.gameObject.tag == "floor"){
            isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.collider.gameObject.tag == "floor"){
            isOnGround = false;
        }
    }
}
