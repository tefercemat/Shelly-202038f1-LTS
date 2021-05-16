using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public SignalSender context;
    public bool playerInRange;
    public BoolValue isActionedStoredValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && (!collision.isTrigger))
        {
            playerInRange = true;
            if (isActionedStoredValue != null)
            {
                //Debug.Log("ENTER isActionedStoredValue is NOT NULL");
                if (!isActionedStoredValue.runTimeValue)
                {
                    context.Raise();
                    //Debug.Log("ENTER isActionedStoredValue is FALSE");
                }
            } else
            {
                //Debug.Log("ENTER isActionedStoredValue is NULL");
                context.Raise();
            }
        }
        

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && (!collision.isTrigger))
        {
            playerInRange = false;

            if (isActionedStoredValue != null)
            {
                //Debug.Log("EXIT isActionedStoredValue is NOT NULL");
                if (!isActionedStoredValue.runTimeValue)
                {
                    context.Raise();
                    //Debug.Log("EXIT isActionedStoredValue is FALSE");
                } else
                {
                    //Debug.Log("EXIT isActionedStoredValue is TRUE");
                }
            } else
            {
                //Debug.Log("EXIT isActionedStoredValue is NULL");
                context.Raise();
            }
        }
        
    }
}
