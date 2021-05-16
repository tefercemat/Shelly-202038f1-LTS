using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sign : Interactable
{
    
    public GameObject dialogBox;
    public TextMeshProUGUI dialogText;
    public string dialog;
    public bool dialogActive;
    private PlayerControl inputActions;


    private void Awake()
    {
        inputActions = new PlayerControl();
        playerInRange = false;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if(inputActions.Movement.Attack.triggered && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            } else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && (!collision.isTrigger))
        {
            context.Raise();
            playerInRange = false;
            dialogBox.SetActive(false);
        }
    }
}
