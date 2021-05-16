using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum ItemType
{
    Armor,
    ConsumableHealth,
    ConsumableMana,
    Trash,
    Usable,
    Weapon,
}

public enum Attribute
{
    Agility,
    Stamina,
    Intellect,
    Strenght,
}

public abstract class ItemObject : ScriptableObject
{
    public int Id;
    public ItemType type;
    public Sprite uiDisplay;
    [TextArea (20,15)] public string description;
    public bool isUsable = false;
    public int maxStack;
    public ItemBuff[] buffs;

    public UnityEvent thisEvent;

    //public abstract void Use();
}

[System.Serializable]
public class Item
{
    public string Name;
    public int Id;
    public string Description;
    public bool IsUsable = false;
    public ItemType Type;
    public ItemBuff[] buffs;
    public int MaxStack;
    public UnityEvent ThisEvent;

    public Item(ItemObject item)
    {
        Name = item.name;
        Description = item.description;
        IsUsable = item.isUsable;
        Id = item.Id;
        MaxStack = item.maxStack;
        Type = item.type;
        ThisEvent = item.thisEvent;
        buffs = new ItemBuff[item.buffs.Length];
        for (int i = 0; i < item.buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.buffs[i].min, item.buffs[i].max);
            buffs[i].atttribute = item.buffs[i].atttribute;
        }
    }
    public void Use() {
        ThisEvent.Invoke();
    }
}

[System.Serializable]
public class ItemBuff
{
    public Attribute atttribute;
    public int value;
    public int min;
    public int max;

    public ItemBuff(int _min, int _max)
    {
        min = _min;
        max = _max;
        GenerateValue();
    }

    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }
}