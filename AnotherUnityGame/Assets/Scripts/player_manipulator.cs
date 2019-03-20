using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_manipulator : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[2];

    public GameObject player;
    public Slider jump_height;
    public Slider size;
    public Button sprite_button;

    public bool is_fox;
    // Start is called before the first frame update
    void Start()
    {
        jump_height.onValueChanged.AddListener(delegate { change_jump(); });
        size.onValueChanged.AddListener(delegate { change_size(); });
        is_fox = true;
    }


    void change_size()
    {
        player.transform.localScale = new Vector3(size.value, size.value, size.value);
    }

    void change_jump()
    {
        player.GetComponent<player_movement>().ver_speed = jump_height.value;
    }

    public void change_sprite()
    {
        if (is_fox)
        {
            player.GetComponent<SpriteRenderer>().sprite = sprites[1];
            player.GetComponent<player_movement>().Flip();
            player.GetComponent<player_movement>().is_possum = true;
            is_fox = false;
        }
        else
        {
            player.GetComponent<SpriteRenderer>().sprite = sprites[0];
            player.GetComponent<player_movement>().Flip();
            player.GetComponent<player_movement>().is_possum = false;
            is_fox = true;
        }
        
    }
}
