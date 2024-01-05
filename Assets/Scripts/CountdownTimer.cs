using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float waitSec;
    private int waitSecInt;
    public TextMeshProUGUI timerText;

    // Reference to the PlayerManager script
    public PlayerManager playerManager;

    // Reference to the Player object
    public GameObject player;

    // Additional time to be added on each checkpoint
    public float additionalTimeOnCheckpoint = 5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (waitSec > 0 && !PlayerManager.isGameOver)
        {
            waitSec -= Time.fixedDeltaTime;
            waitSecInt = Mathf.CeilToInt(waitSec);
            timerText.text = waitSecInt.ToString();
        }
        else
        {
            // Handle actions after the countdown reaches 0 or game over
            if (!PlayerManager.isGameOver)
            {
                PlayerManager.isGameOver = true;
                playerManager.GameOver();
                player.SetActive(false); // Deactivate the player object
            }
        }
    }

    // Call this function when a checkpoint is triggered
    public void AddTimeOnCheckpoint(float checkpointTimeBonus)
    {
        // Add the specific time bonus to the countdown timer
        waitSec += checkpointTimeBonus;

        // Update the display immediately
        waitSecInt = Mathf.CeilToInt(waitSec);
        timerText.text = waitSecInt.ToString();
    }
}
