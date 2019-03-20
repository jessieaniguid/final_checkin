using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class more_movement : MonoBehaviour
{
    public game_manager gm;

    public Rigidbody myRB;
    public float speed;
    public float jumpForce;
    public float verticalVelocity;
    public bool isGrounded;
    public float gravity;
    public bool isAlive;
    // Start is called before the first frame update
    void Start()
    {
        gravity = 10;
        jumpForce = 10;
        speed = 5;
        myRB = GetComponent<Rigidbody>();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetKeyDown(KeyCode.R) && !isAlive) gm.restart();

        if (this.transform.position.y < -5)
        {
            transform.position = new Vector3(0, -5, -71);
            isAlive = false;
            gm.display_death_screen();
            return;
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isGrounded = false;
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        myRB.velocity = new Vector3(Input.GetAxis("Vertical") * speed, verticalVelocity, -Input.GetAxis("Horizontal") * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") isGrounded = true;
        verticalVelocity = 0;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
