using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject bronzeMedal;
    [SerializeField] GameObject silverMedal;
    [SerializeField] GameObject goldMedal;

    [Space, SerializeField] private TextMeshProUGUI scoreGameplay;
    [SerializeField] private TextMeshProUGUI scoreGameover;

    [Space, SerializeField] private TextMeshProUGUI highscore;
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(this.gameObject);
        }
    }
    public void UpdateScoreText()
    {
        scoreGameplay.text = GameManager.Instance.score.ToString();
        scoreGameover.text = GameManager.Instance.score.ToString();
    }
    public void UpdateHighScoreText()
    {
        GameManager.Instance.CheckHighScore();
        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public void UpdateMedal()
    {
        if (GameManager.Instance.score < 5)
        {
            bronzeMedal.SetActive(true);
        }
        else if(GameManager.Instance.score < 10)
        {
            silverMedal.SetActive(true);
        }
        else if(GameManager.Instance.score > 10)
        {
            goldMedal.SetActive(true);
        }
    }
}
