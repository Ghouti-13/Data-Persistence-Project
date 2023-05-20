using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUI : UIManager
{
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private Button buyButton;

    public override void Start()
    {
        base.Start();

        if (string.IsNullOrWhiteSpace(DataManager.GameData.BestPlayerName))
        {
            bestScoreText.text = "NO BEST SCORE AVAILABLE";
        }
        else
        {
            bestScoreText.text = DataManager.GameData.BestPlayerName + " HAS BEST SCORE OF " + DataManager.GameData.BestScoe + " PTS";
        }

        InitializeInputField();

        if (DataManager.GameData.HasRiffle) LockBuyButton(true);
    }
    private void InitializeInputField()
    {
        if (string.IsNullOrWhiteSpace(DataManager.GameData.PlayerName)) return;

        usernameInputField.text = DataManager.GameData.PlayerName;
        usernameInputField.ForceLabelUpdate();
    }
    public override void UpdateCurrencyText(int currency, int currencyToAdd, bool addCurrency = true)
    {
        base.UpdateCurrencyText(currency, currencyToAdd, addCurrency);
    }
    public void OnPlayButtonPressed()
    {
        SceneLoader.Instance.LoadScene(1);
    }
    public void OnLeaveButtonPressed()
    {
        DataManager.Save();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void OnBuyButtonPressed()
    {
        ShopManager.Instance.PurchaseWeapon(WeaponData.WeaponType.Riffle, () =>
        {
            LockBuyButton(true);
        });
    }
    public void OnSetPlayerName(string playerName)
    {
        DataManager.GameData.PlayerName = playerName;
    }
    public void OnDeleteButtunPressed()
    {
        DataManager.DeleteSaveFile();
    }
    private void LockBuyButton(bool value)
    {
        buyButton.interactable = !value;
        buyButton.GetComponentInChildren<TextMeshProUGUI>().text = value ? "SOLD" : "BUY";
    }
}
