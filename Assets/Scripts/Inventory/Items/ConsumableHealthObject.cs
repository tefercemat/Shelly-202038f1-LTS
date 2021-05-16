using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Object", menuName = "Inventory System/Items/Consumable Health")]
public class ConsumableHealthObject : ItemObject
{
    public int healthRegen;

    public void Awake()
    {
        type = ItemType.ConsumableHealth;
    }
}
