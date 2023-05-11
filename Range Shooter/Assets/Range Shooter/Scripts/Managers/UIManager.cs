using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

    [Header("TEXT")]
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text scoreText, currencyText, addedCurrencyText;
    [SerializeField] private TMP_Text startPositionText, headshootText;

    private Animator headshootAnimator, addedCurrencyAnimator;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        startPositionText.gameObject.SetActive(false);

        headshootAnimator = headshootText.GetComponent<Animator>();
        addedCurrencyAnimator = addedCurrencyText.GetComponent<Animator>();
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
        scoreText.text = "Score : " + score;
    }
    public void SetAddedCurrencyText(int currency, int addedCurrency, Color textColor)
    {
        currencyText.text = currency + " $";
        addedCurrencyText.text = "+" + addedCurrency + "$";
        addedCurrencyAnimator.SetTrigger("CurrencyAdd");
    }
    public void SetCurrencyText(int currency)
    {
        currencyText.text = currency + " $";
    }
    public void TriggerHeadshoot()
    {
        headshootAnimator.SetTrigger("Headshoot");
    }
}
