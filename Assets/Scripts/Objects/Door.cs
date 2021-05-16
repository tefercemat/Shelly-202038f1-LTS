using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum DoorType
{
    key,
    enemy,
    button
}

public class Door : Interactable
{
    [Header("Door Variables")]
    public DoorType thisDoorType;
    public bool isOpened = false;
    //public BoolValue storedValue;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;


    public PlayerControl inputActions;

    public void Awake()
    {
        inputActions = new PlayerControl();
        playerInRange = false;
    }

    public void OnEnable()
    {
        inputActions.Enable();
    }

    public void OnDisable()
    {
        inputActions.Disable();
    }

    public void Start()
    {
        isOpened = isActionedStoredValue.runTimeValue;
        if (isOpened)
        {
            Open(thisDoorType);
        }
    }

    public void Open(DoorType doorType)
    {
        doorSprite.enabled = false;
        isOpened = true;
        isActionedStoredValue.runTimeValue = isOpened;
        physicsCollider.enabled = false;
        if (doorType == DoorType.key)
        {
            context.Raise();
        }
    }

    public void Close()
    {

    }
}
