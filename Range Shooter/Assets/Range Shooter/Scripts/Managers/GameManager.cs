using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [SerializeField] private float shootingTime;
    [SerializeField] private int score;
    [SerializeField] private int currency;
    private bool isCountDown;
    public bool IsCountDown => isCountDown;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        ResetGameData();
    }
    private void Update()
    {
        if (isCountDown) StartCountDown();
    }
    public void AddScore(int scoreToAdd, bool isHeadshoot = false)
    {
        score += scoreToAdd;
        UIManager.Instance.SetScoreText(score);
        if (isHeadshoot) UIManager.Instance.TriggerHeadshoot();
    }
    public void AddCurrency(int currencyToAdd)
    {
        currency += currencyToAdd;
        UIManager.Instance.SetAddedCurrencyText(currency, currencyToAdd, Color.green);
    }
    public void StartGame(bool value)
    {
        isCountDown = value;
        UIManager.Instance.SetStartText(!value);
        if (!value) ResetGameData();
    }
    private void StartCountDown()
    {
        if (shootingTime > 0.1f)
        {
            shootingTime -= Time.deltaTime;
            UpdateTimer();
        }
    }
    private void ResetGameData()
    {
        score = currency = 0;
        shootingTime = 90f;

        UIManager.Instance.SetCurrencyText(currency);
        UIManager.Instance.SetScoreText(score);

        UpdateTimer();
    }
    private void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(shootingTime / 60);
        int seconds = Mathf.FloorToInt(shootingTime % 60);

        UIManager.Instance.SetTimeText(minutes, seconds);
    }
}
