using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScripts : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            // Set the respawn position in the PlayerManager
            PlayerManager.lastCheckPointPos = new Vector2(-8, -2);

            // Load the WinScreen2 scene
            SceneManager.LoadScene("WinScreen2");
        }
    }
}