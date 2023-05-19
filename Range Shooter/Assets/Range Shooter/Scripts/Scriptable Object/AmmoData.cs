using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ammo", menuName = "Range Shooter/Purchasable Item/New Ammo")]
public class AmmoData : ScriptableObject
{
    public enum AmmoType { Handgun, Riffle}

    public AmmoType type;
    public int price;
    public int quantity;
}
