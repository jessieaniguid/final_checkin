using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game_manager : MonoBehaviour
{
    public Image image;
    public player_movement player;
    // Start is called before the first frame update
    
    public void display_death_screen()
    {
        Debug.Log("died");
        image.gameObject.SetActive(true);
    }

    public void restart()
    {
        image.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
