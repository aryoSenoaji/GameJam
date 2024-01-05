using System.Collections;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float waitSec;
    private int waitSecInt;
    public TextMeshProUGUI timerText;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (waitSec > 0)
        {
            waitSec -= Time.fixedDeltaTime;
            waitSecInt = Mathf.CeilToInt(waitSec);  // Menggunakan Mathf.CeilToInt untuk memastikan tidak ada nilai negatif
            timerText.text = waitSecInt.ToString();
        }
        else
        {
            // Handle actions after the countdown reaches 0, if needed
        }
    }
}
