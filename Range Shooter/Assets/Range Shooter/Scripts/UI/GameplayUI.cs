using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameplayUI : UIManager
{
    [Header("TEXT")]
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text gameScoreText;
    [SerializeField] private TMP_Text startPositionText, headshootText;

    [Header("WINDOWS")]
    [SerializeField] private GameObject pauseWindow;
    [SerializeField] private GameObject GameoverWindow;

    private Animator headshootAnimator;

    public override void Start()
    {
        base.Start();

        headshootAnimator = headshootText.GetComponent<Animator>();
        InitializeText();
    }
    public override void InitializeText()
    {
        scoreText.text = GameManager.Instance.Score + " pts";
        currencyText.text = ShopManager.Instance.Currency + "$";
        startPositionText.gameObject.SetActive(false);

        GameManager.Instance.UpdateTimer();
    }
    public void SetStartText(bool value)
    {
        startPositionText.gameObject.SetActive(value);
    }
    public void SetTimeText(int minutes, int seconds)
    {
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
    public void SetScoreText(int score)
    {
        scoreText.text = score + " pts";
    }
    public override void UpdateCurrencyText(int currency, int currencyToSet, bool addCurrency)
    {
        base.UpdateCurrencyText(currency, currencyToSet, addCurrency);
    }
    public void SetCurrencyText(int currency)
    {
        currencyText.text = currency + " $";
    }
    public void TriggerHeadshoot()
    {
        headshootAnimator.SetTrigger("Headshoot");
    }
    public void DisplayPauseWindow(bool value)
    {
        pauseWindow.SetActive(value);
    }
    public void DisplayGameoverWindow(bool value)
    {
        bestScoreText.text = DataManager.GameData.BestPlayerName + " HAS BEST SCORE OF " + DataManager.GameData.BestScoe + " PTS";
        gameScoreText.text = "YOUR SCORE IS " + DataManager.GameData.PlayerScore;

        GameoverWindow.SetActive(value);
    }
    public void OnRestartButtonPressed(int sceneIndex)
    {
        SceneLoader.Instance.LoadScene(sceneIndex);
    }
    public void OnLeaveButtonPressed(int sceneIndex)
    {
        SceneLoader.Instance.LoadScene(sceneIndex);
    }
}
