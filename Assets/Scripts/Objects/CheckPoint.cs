using System.Collections;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Time bonus specific to this checkpoint
    public float checkpointTimeBonus = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerManager.lastCheckPointPos = transform.position;
            AudioManager.instance.Play("Checkpoint");

            // Find the CountdownTimer in the scene and call AddTimeOnCheckpoint
            CountdownTimer countdownTimer = FindObjectOfType<CountdownTimer>();
            if (countdownTimer != null)
            {
                countdownTimer.AddTimeOnCheckpoint(checkpointTimeBonus, gameObject);
            }

            // Disable the collider to prevent additional triggers by the same checkpoint
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
