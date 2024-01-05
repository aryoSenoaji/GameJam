using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            PlayerManager.isGameOver = true;
            PlayerManager.Instance.GameOver();
            gameObject.SetActive(false);
        }
    }
}
