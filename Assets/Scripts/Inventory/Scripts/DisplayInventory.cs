using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class DisplayInventory : MonoBehaviour
{
    [Header("Inventory Information")]
    public InventoryObject inventory;
    public GameObject inventoryPrefab;
    public MouseItem mouseItem = new MouseItem();
    Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
    public GameObject descriptionText;
    public GameObject buttonUse;
    public InventorySlot currentItem;

    // Start is called before the first frame update
    void Start()
    {
        CreateSlots();
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdateSlots();
    }

    private void Awake()
    {
        SetupDescriptionAndButton("", false);
    }

    public void CreateSlots()
    {
        //Debug.Log("Creating events");

        itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);

            if(obj)
            {
                AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
                AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
                AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
                AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
                AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });
                AddEvent(obj, EventTriggerType.PointerClick, delegate { OnPointerClick(obj); });

                itemsDisplayed.Add(obj, inventory.Container.Items[i]);
            }
        }
    }

    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> _slot in itemsDisplayed)
        {
            if(_slot.Value.ID >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[_slot.Value.item.Id].uiDisplay;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
            } else
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                _slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }

    private void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    public void OnEnter(GameObject obj)
    {
        //Debug.Log("Triggering OnEnter");

        mouseItem.hoverObj = obj;
        if (itemsDisplayed.ContainsKey(obj))
        {
            mouseItem.hoverItem = itemsDisplayed[obj];
        }
    }

    public void OnExit(GameObject obj)
    {
        //Debug.Log("Triggering OnExit");

        mouseItem.hoverObj = null;
        mouseItem.hoverItem = null;
    }

    public void OnDragStart(GameObject obj)
    {
        //Debug.Log("Triggering OnDragStart");

        var mouseObject = new GameObject();
        var rt = mouseObject.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(100, 100);
        mouseObject.transform.SetParent(transform.parent);
        if(itemsDisplayed[obj].ID >= 0)
        {
            var img = mouseObject.AddComponent<Image>();
            img.sprite = inventory.database.GetItem[itemsDisplayed[obj].ID].uiDisplay;
            img.raycastTarget = false;
        }
        mouseItem.obj = mouseObject;
        mouseItem.item = itemsDisplayed[obj];
    }

    public void OnDragEnd(GameObject obj)
    {
        //Debug.Log("Triggering OnDragEnd");

        if (mouseItem.hoverObj)
        {
            inventory.MoveItem(itemsDisplayed[obj], itemsDisplayed[mouseItem.hoverObj]);
        }
        else
        {
            inventory.RemoveItem(itemsDisplayed[obj].item);
        }
        Destroy(mouseItem.obj);
        mouseItem.item = null;
    }

    public void OnDrag(GameObject obj)
    {
        //Debug.Log("Triggering OnDrag");

        if (mouseItem.obj != null)
        {
            mouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }

    public void OnPointerClick(GameObject obj)
    {
        //Debug.Log("Triggering OnPointerClick");
        if (itemsDisplayed.ContainsKey(obj))
        {
            if (itemsDisplayed[obj].ID < 0)
            {
                SetupDescriptionAndButton("", false);
                currentItem = null;
                return;
            }

            SetupDescriptionAndButton(itemsDisplayed[obj].item.Description, itemsDisplayed[obj].item.IsUsable);
            currentItem = itemsDisplayed[obj];
        }
        
    }

    public void SetupDescriptionAndButton(string newDescriptionString, bool isButtonUsable)
    {
        descriptionText.GetComponent<TMP_Text>().SetText(newDescriptionString);
        buttonUse.SetActive(isButtonUsable);
    }
    
    public void UseButtonPressed()
    {
        //Debug.Log("Triggering UseButtonPressed");
        if (currentItem.amount > 0)
        {
            currentItem.item.Use();
            inventory.DecreaseQtyItem(currentItem);
        }
        if(currentItem.amount <= 0)
        {
            SetupDescriptionAndButton("", false);
        }
    }
    
}

public class MouseItem
{
    public GameObject obj;
    public InventorySlot item;
    public InventorySlot hoverItem;
    public GameObject hoverObj;
}