using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{


    [SerializeField] private GameObject virtualCam = null;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                if (hit.GetComponent<PlayerController>().currentState != PlayerState.attack)
                    virtualCam.SetActive(true);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                if (collision.gameObject.GetComponent<PlayerController>().currentState != PlayerState.attack)
                    virtualCam.SetActive(false);
            }
        }
    }


}
