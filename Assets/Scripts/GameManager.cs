using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float timeToRestartGame;

    [SerializeField]
    private UnityEvent onStartGame;
    [SerializeField]
    private UnityEvent onGameOver;
    [SerializeField]
    private UnityEvent onIncreaseScore;

    public int score
    {
        get; private set;
    }
    public bool IsGameOver
    {
        get; private set;
    }
    public static GameManager Instance;
    
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(this.gameObject);
        }
    }
    public void StartGame()
    {
        onStartGame?.Invoke();
    }
    public void Gameover()
    {
        IsGameOver = true;

        onGameOver?.Invoke();
    }
    public void IncreaseScore()
    {
        score++;

        onIncreaseScore?.Invoke();
    }
    public void CheckHighScore()
    {
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
    public void RestartGame()
    {
        Invoke("ReloadScene", timeToRestartGame);
    }

    private void ReloadScene()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
