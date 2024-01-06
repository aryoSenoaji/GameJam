using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Parallax : MonoBehaviour
{
    //private float startPos;
    //private CinemachineVirtualCamera cam;
    //[SerializeField] private float parallaxEffect;

    //void //Start()
    //{
    //    // Find the Cinemachine Virtual Camera with the "MainCamera" tag
    //    cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>();

    //    if (cam == null)
    //    {
    //        Debug.LogError("Cinemachine Virtual Camera not found.");
    //        return;
    //    }

    //    startPos = transform.position.y;
    //}

    //private void //Update()
    //{
    //    if (cam == null)
    //        return;

    //    float distance = (cam.transform.position.y * parallaxEffect);
    //    transform.position = new Vector3(transform.position.x, startPos + distance, transform.position.z);
    //}



    private float length;
    private float startPos;
    private GameObject cam;
    [SerializeField] private float parallaxEffect;

    private void Start()
    {
        cam = GameObject.Find("Vcam");
        startPos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void Update()
    {
        float temp = (cam.transform.position.y * (1 - parallaxEffect));
        float distance = (cam.transform.position.y * parallaxEffect);

        transform.position = new Vector3(transform.position.x, startPos + distance, transform.position.z);

        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}