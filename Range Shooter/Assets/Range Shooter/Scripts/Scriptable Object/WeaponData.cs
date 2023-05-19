using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Range Shooter/Purchasable Item/New Weapon")]
public class WeaponData : ScriptableObject
{
    public enum WeaponType { Handgun, Riffle }

    public WeaponType type;
    public int price;
    public bool isPurchased;
    public GameObject weaponPrefab;
}
