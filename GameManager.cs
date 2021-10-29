using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private enum GameState {
        Playing,
        Finished,
        ScoreScreen
    }

    private GameState state;
    public GameObject ScoreScreen;
    public GameObject GameScreen;
    public GameObject[] enemies;
    public Text TimerText;
    public Text ScoreText;
    public Text RoundsText;
    public Text ScoreScreenScoreText;
    public int Score { get; private set; }

    public int StartCountRounds;
    private float timeOffset = 0.0f;
    
    public int Rounds { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Reset();
        Rounds = StartCountRounds;
        ScoreScreen.SetActive(false);
        GameScreen.SetActive(true);
        state = GameState.Playing;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case GameState.Finished:
                GameScreen.SetActive(false);
                ScoreScreen.SetActive(true);
                ScoreScreenScoreText.text = GetScore();
                state = GameState.ScoreScreen;
                break;
            case GameState.Playing:
                TimerText.text = GetTime();
                ScoreText.text = GetScore();
                RoundsText.text = GetRounds();
                if (Rounds <= 0)
                    state = GameState.Finished;
                break;
            case GameState.ScoreScreen:
                break;
        }
    }

    private string GetTime()
    {
        float timeInSeconds = Time.time - timeOffset;
        int minutes = (int)Mathf.Floor(timeInSeconds/60.0f);
        int seconds = ((int)timeInSeconds) - (minutes * 60);
        return $"{minutes.ToString("00")}:{seconds.ToString("00")}";
    }

    public void Finish()
    {
        ScoreScreen.SetActive(true);
    }

    public void AddScore(int count)
    {
        Score += count;
    }

    public void DidARound()
    {
        Rounds--;
        foreach (var enemy in enemies)
        {
            enemy.SetActive(true);
        }
    }

    public string GetScore()
    {
        return $"Score: {Score}";
    }

    public string GetRounds()
    {
        return $"Rounds: {Rounds}";
    }

    public void GameOver()
    {
        state = GameState.Finished;
    }

    public void Reset()
    {
        Score = 0;
        Rounds = StartCountRounds;
        timeOffset = Time.time;
    }
}
