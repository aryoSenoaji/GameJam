using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Nut : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            if (PlayerManager.numberOfNuts == 0)
            {
                // If it's the first nut, set the score to 100
                PlayerManager.numberOfNuts = 100;
            }
            else
            {
                // If it's not the first nut, increment the score by 100
                PlayerManager.numberOfNuts += 100;
            }

            Destroy(gameObject);
        }
    }
}
