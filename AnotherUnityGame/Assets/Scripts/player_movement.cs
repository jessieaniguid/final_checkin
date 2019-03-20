using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public game_manager gm;

    //for 3Dfication
    public GameObject fox;
    public bool is_fox;
    public bool is_possum;

    public Rigidbody2D my_rigidbody;
    public Vector3 my_velocity = Vector3.zero;
    public float hor_mov;
    public float hor_speed;
    public float ver_speed;
    public float smoothing_val = .05f;
    public bool is_grounded;
    public bool is_Alive;
    public bool can_move;

    //1 for right, 0 for left
    public bool facing_right;
    

    // Start is called before the first frame update
    void Start()
    {
        is_possum = false;
        is_Alive = true;
        is_fox = false;
        hor_speed = 4f;
        ver_speed = 6f;
        facing_right = true;
        can_move = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (facing_right && Input.GetAxis("Horizontal") < 0)
        {
            facing_right = false;
            Flip();
        }else if(!facing_right && Input.GetAxis("Horizontal") > 0)
        {
            facing_right = true;
            Flip();
        }

        check_life();
        move();
    }

    public void check_life()
    {
        if (can_move == false) return;
        if (!is_Alive) gm.display_death_screen();
        if (Input.GetKeyDown(KeyCode.R)) gm.restart();
        if (transform.position.y < -6)
        {
            transform.position = new Vector3(0, -6);
            is_Alive = false;
        }
        
        if (!is_Alive) return;

        
    }

    public void move()
    {
        if (is_grounded && Input.GetButtonDown("Jump"))
        {
            my_rigidbody.velocity = Vector2.up * ver_speed;
        }



        hor_mov = Input.GetAxis("Horizontal");


        Vector3 target_velocity = new Vector2(hor_mov * hor_speed, my_rigidbody.velocity.y);
        my_rigidbody.velocity = target_velocity;
    }

    public void AddDimension()
    {
        if(is_fox == false)
        {
            fox.transform.position = new Vector3(transform.position.x, transform.position.y, fox.transform.position.z);
            fox.SetActive(true);
            can_move = false;
            is_fox = true;
        }
        else
        {
            this.transform.position = new Vector3(fox.transform.position.x, fox.transform.position.y, transform.position.z);
            fox.SetActive(false);
            can_move = true;
            is_fox = false;
        }
        
    }

    public void Flip()
    {
        gameObject.GetComponent<SpriteRenderer>().flipX = !gameObject.GetComponent<SpriteRenderer>().flipX;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            is_grounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            is_grounded = false;
        }
    }


}
