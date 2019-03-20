using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class possum_move : MonoBehaviour
{
    public float speed;
    public Transform left_bound;
    public Transform right_bound;
    public bool going_right;
    // Start is called before the first frame update
    void Start()
    {
        going_right = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (going_right)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, right_bound.position, speed);
            if (transform.position.x == right_bound.position.x) going_right = false;
        }
        else if(!going_right)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, left_bound.position, speed);
            if (transform.position.x == left_bound.position.x) going_right = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && 
            collision.gameObject.GetComponent<player_movement>().is_possum == false)
        {
            collision.GetComponent<player_movement>().is_Alive = false;
        }
    }
}
