using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance;

    [Header("Ammo")]
    [SerializeField] private AmmoData handgunAmmo;
    [SerializeField] private AmmoData riffleAmmo;

    [Header("WEAPON")]
    [SerializeField] private WeaponData riffle;

    private int currency;
    private AudioSource coinsAudio;
    public int Currency => currency;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        coinsAudio = GetComponent<AudioSource>();
    }
    private void Start()
    {
        currency = DataManager.GameData.PlayerCurrency;
    }
    public void AddCurrency(int currencyToAdd, bool addCurrency = true)
    {
        currency += currencyToAdd;

        if (UIManager.Instance == null) return;

        UIManager.Instance.UpdateCurrencyText(currency, currencyToAdd, addCurrency);
    }
    public void PurchaseAmmo(AmmoData.AmmoType ammoType, Action<int> Callback)
    {
        switch (ammoType)
        {
            case AmmoData.AmmoType.Handgun:

                if (currency < handgunAmmo.price) break;

                AddCurrency(-handgunAmmo.price, false);
                Callback?.Invoke(handgunAmmo.quantity);
                coinsAudio.Play();
                break;
            case AmmoData.AmmoType.Riffle:
                if (currency < handgunAmmo.price) break;

                AddCurrency(-riffleAmmo.price, false);
                Callback?.Invoke(riffleAmmo.quantity);
                coinsAudio.Play();
                break;
        }
    }
    public void PurchaseWeapon(WeaponData.WeaponType weaponType, Action Callback)
    {
        if (currency < riffle.price) return;

        AddCurrency(-riffle.price, false);
        DataManager.GameData.HasRiffle = true;
        Callback?.Invoke();
        coinsAudio.Play();
    }
}
