using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    private enum GameState
    {
        GameOver,
        Playing,
        Won
    }

    private static int level = 1;
    private static bool init = true;

    private float score;
    
    public GameObject player;
    public Health healthPlayer;

    public GameObject gameCanvas;

    public GameObject gameOverCanvas;
    public GameObject coin;
    public GameObject World1;
    public GameObject World2;
    private CoinBehaviour coinBehaviour;
    public float startTime = 30;

    public Text timer;

    public Text scoreText;

    private GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        if (player != null)
            player = GameObject.FindWithTag("Player");
        
        healthPlayer = player.GetComponent<Health>();

        if (coin != null)
            coin = GameObject.FindWithTag("Coin");

        coinBehaviour = coin.GetComponent<CoinBehaviour>();

        if(gameCanvas != null)
            gameCanvas = GameObject.Find("Game canvas");

        gameState = GameState.Playing;
        
        gameCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);

        World1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case GameState.GameOver:
                if(init)
                {
                    init = false;
                    gameCanvas.SetActive(false);
                    gameOverCanvas.SetActive(true);
                }
                break;
            case GameState.Playing:
                startTime -= Time.deltaTime;
                float tempTime = Mathf.Round(startTime);
                timer.text = tempTime.ToString();
                scoreText.text = score.ToString();
                if (!healthPlayer.isAlive)
                {
                    init = true;
                    gameState = GameState.GameOver;
                }
                if (tempTime < 0)
                {
                    init = true;
                    gameState = GameState.GameOver;
                }
                if (score >= 2)
                {
                    init = true;
                    gameState = GameState.Won;
                }
                break;
            case GameState.Won:
                if (World1.activeSelf)
                {
                    World1.SetActive(false);
                    World2.SetActive(true);   
                }
                else
                {
                    World2.SetActive(false);
                    World1.SetActive(true);
                }
                coinBehaviour.SetNewPos();
                healthPlayer.Respawn();
                gameState = GameState.Playing;
                startTime = Time.deltaTime + 30;
                score = 0;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void AddScore()
    {
        score++;
        startTime += 10;
    }
}
