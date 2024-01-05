using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;

    public static Vector2 lastCheckPointPos = new Vector2(0, 0);

    private void Awake()
    {
        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            gameOverScreen.SetActive(true);
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
