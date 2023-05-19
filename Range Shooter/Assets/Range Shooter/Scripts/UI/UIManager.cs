using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] protected TMP_Text currencyText;
    [SerializeField] protected TMP_Text addedCurrencyText;
    [SerializeField] protected TMP_Text scoreText, bestScoreText;
    [SerializeField] protected Animator addedCurrencyAnimator;

    public static string PlayerName;

    protected void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public virtual void Start()
    {
        InitializeText();
    }
    public virtual void InitializeText()
    {
        scoreText.text = DataManager.GameData.PlayerScore + " pts";
        currencyText.text = DataManager.GameData.PlayerCurrency + "$";
    }
    public virtual void UpdateCurrencyText(int currency, int currencyToAdd, bool addCurrency = true)
    {
        currencyText.text = currency + "$";
        addedCurrencyText.text = addCurrency ? "+" + currencyToAdd + "$" : currencyToAdd + "$";

        if (addCurrency)
            addedCurrencyAnimator.SetTrigger("CurrencyAdd");
        else
            addedCurrencyAnimator.SetTrigger("CurrencyRemove");
    }
}
