using System.Collections;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    // Time bonus specific to this checkpoint
    public float checkpointTimeBonus = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerManager.lastCheckPointPos = transform.position;

            // Find the CountdownTimer in the scene and call AddTimeOnCheckpoint
            CountdownTimer countdownTimer = FindObjectOfType<CountdownTimer>();
            if (countdownTimer != null)
            {
                countdownTimer.AddTimeOnCheckpoint(checkpointTimeBonus);
            }
        }
    }
}
