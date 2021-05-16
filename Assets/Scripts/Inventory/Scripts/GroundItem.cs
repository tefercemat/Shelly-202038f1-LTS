using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundItem : MonoBehaviour
{
    public ItemObject item;
    //public Sprite groundSprite;
    //public Inventory inventory;
    public ItemDatabaseObject database;
    public SpriteRenderer spriteRenderer;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(spriteRenderer)
            spriteRenderer.sprite = database.GetItem[item.Id].uiDisplay;
    }


}
