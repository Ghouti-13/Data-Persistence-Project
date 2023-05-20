using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    [SerializeField] private GameplayUI gameplayUI;

    [SerializeField] private float shootingTime;
    [SerializeField] private int score;

    private float initialShootingTime;
    private int bestScore;

    private bool isCountDown;
    private bool gamePaused;

    public bool IsCountDown => isCountDown;
    public bool IsGamePaused => gamePaused;
    public int Score => score;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        score = 0;
        initialShootingTime = shootingTime;
        bestScore = DataManager.GameData.BestScoe;
    }
    private void Update()
    {
        if (isCountDown) StartCountDown();
    }
    public void AddScore(int scoreToAdd, bool isHeadshoot = false)
    {
        score += scoreToAdd;
        gameplayUI.SetScoreText(score);
        if (isHeadshoot) gameplayUI.TriggerHeadshoot();
    }
    public void AddCurrency(int currencyToAdd, bool addCurrency = true)
    {
        ShopManager.Instance.AddCurrency(currencyToAdd, addCurrency);
    }
    public void StartGame(bool value)
    {
        shootingTime = initialShootingTime;
        isCountDown = value;
        gameplayUI.SetStartText(false);
    }
    public void ResetData()
    {
        score = 0;
    }
    private void StartCountDown()
    {
        if (gamePaused) return;

        if (shootingTime > 0.1f)
        {
            shootingTime -= Time.deltaTime;
            UpdateTimer();
        }
        else
        {
            Gameover();
        }
    }
    private void PauseGame(bool value)
    {
        if (UIManager.Instance == null) return;

        Time.timeScale = value ? 0 : 1f;

        Cursor.lockState = value ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = value;

        gameplayUI.DisplayPauseWindow(value);
        gamePaused = value;
    }
    public void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(shootingTime / 60);
        int seconds = Mathf.FloorToInt(shootingTime % 60);

        gameplayUI.SetTimeText(minutes, seconds);
    }
    public void Gameover()
    {
        if (GameplayUI.Instance == null) return;

        gamePaused = true;
        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        DataManager.GameData.PlayerScore = score;
        DataManager.GameData.PlayerCurrency = ShopManager.Instance.Currency;

        // Checking the best score //
        if (score > bestScore)
        {
            DataManager.GameData.BestScoe = score;
            DataManager.GameData.BestPlayerName = string.IsNullOrWhiteSpace(DataManager.GameData.PlayerName) ? "BEST PLAYER" : DataManager.GameData.PlayerName.ToUpper();
        }

        // Saving the progress //
        DataManager.Save();

        gameplayUI.DisplayGameoverWindow(true);
    }
#region INPUT

    public void OnTryPause(InputAction.CallbackContext context)
    {
        if (shootingTime < 0.1f) return;

        switch (context)
        {
            case { phase: InputActionPhase.Performed }:
                PauseGame(!gamePaused);
                break;
        }
    }
#endregion
}
