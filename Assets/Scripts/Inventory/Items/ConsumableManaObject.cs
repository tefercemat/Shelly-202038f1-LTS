using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Object", menuName = "Inventory System/Items/Consumable Mana")]
public class ConsumableManaObject : ItemObject
{
    public int manaRegen;

    public void Awake()
    {
        type = ItemType.ConsumableMana;
    }
}
