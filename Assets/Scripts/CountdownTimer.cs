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
}
