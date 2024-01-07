using System.Collections;
using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class CountdownTimer : MonoBehaviour
{
    public float waitSec;
    private int waitSecInt;
    public TextMeshProUGUI timerText;

    // Dictionary to track activated checkpoints
    private Dictionary<GameObject, bool> activatedCheckpoints = new Dictionary<GameObject, bool>();

    // Flag to check if the game is over
    private bool isGameOver = false;

    // Reference to the countdown coroutine
    private Coroutine countdownCoroutine;

    // Start the countdown coroutine
    void Start()
    {
        countdownCoroutine = StartCoroutine(StartCountdown());
    }

    // Coroutine for the countdown logic
    IEnumerator StartCountdown()
    {
        while (waitSec > 0 && !isGameOver)
        {
            waitSec -= Time.deltaTime;
            waitSecInt = Mathf.CeilToInt(waitSec);
            timerText.text = waitSecInt.ToString();
            yield return null;
        }

        // Handle actions after the countdown reaches 0 or game over
        if (!isGameOver)
        {
            isGameOver = true;  // Set the game over flag
            PlayerManager.isGameOver = true;
            PlayerManager.Instance.GameOver();
            AudioManager.instance.Play("GameOver");
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                Destroy(playerObject); // Destroy the player object
            }
        }
    }

    public void AddTimeOnCheckpoint(float checkpointTimeBonus, GameObject checkpointObject)
    {
        // Check if the checkpoint has already been activated
        if (!activatedCheckpoints.ContainsKey(checkpointObject) || !activatedCheckpoints[checkpointObject])
        {
            // Add the specific time bonus to the countdown timer
            waitSec += checkpointTimeBonus;

            // Update the display immediately
            waitSecInt = Mathf.CeilToInt(waitSec);
            timerText.text = waitSecInt.ToString();

            // Set the flag to indicate that the bonus has been applied
            activatedCheckpoints[checkpointObject] = true;
        }
    }

    // Stop the countdown coroutine
    public void StopCountdown()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }
    }
}
