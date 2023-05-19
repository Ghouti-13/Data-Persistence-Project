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
    [SerializeField] private Button buyButton;

    public override void Start()
    {
        base.Start();

        if (string.IsNullOrWhiteSpace(DataManager.GameData.BestPlayerName))
        {
            bestScoreText.text = " NO BEST SCORE AVAILABLE";
            PlayerName = "Player";
        }
        else
        {
            bestScoreText.text = DataManager.GameData.BestPlayerName + " HAS BEST SCORE OF " + DataManager.GameData.BestScoe;
        }
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
            LockBuyButton();
        });
    }
    public void OnSetPlayerName(string playerName)
    {
        PlayerName = playerName;
    }
    private void LockBuyButton()
    {
        buyButton.interactable = false;
        buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "SOLD";
    }
}
