using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform mainCam;
    public Transform downBg;
    public Transform topBg;

    public float length;

    // Update is called once per frame
    void Update()
    {
        // Check if the camera has moved below the downBg position
        if (mainCam.position.y > downBg.position.y + length)
        {
            // Move downBg to the topBg position + length
            downBg.position = topBg.position + Vector3.up * length;
        }

        // Check if the camera has moved above the topBg position
        if (mainCam.position.y < topBg.position.y - length)
        {
            // Move topBg to the downBg position - length
            topBg.position = downBg.position + Vector3.down * length;
        }
    }
}
