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

    // Update is called once per frame
    void FixedUpdate()
    {
        if (waitSec > 0)
        {
            waitSec -= Time.fixedDeltaTime;
            waitSecInt = Mathf.CeilToInt(waitSec);
            timerText.text = waitSecInt.ToString();
        }
        else
        {
            // Handle actions after the countdown reaches 0
            if (!PlayerManager.isGameOver)
            {
                PlayerManager.isGameOver = true;
                PlayerManager.Instance.GameOver();
                GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
                if (playerObject != null)
                {
                    Destroy(playerObject); // Destroy the player object
                }
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
}
