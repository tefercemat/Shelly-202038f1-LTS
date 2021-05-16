using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Sprite activeSprite;
    private SpriteRenderer spriteInUse;
    public Door thisDoor;

    // Start is called before the first frame update
    void Start()
    {
        spriteInUse = GetComponent<SpriteRenderer>();
        if (thisDoor.isActionedStoredValue.runTimeValue)
        {
            spriteInUse.sprite = activeSprite;
        }
    }

    private void ActivateSwitch()
    {
        spriteInUse.sprite = activeSprite;
        thisDoor.Open(thisDoor.thisDoorType);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !thisDoor.isOpened)
        {
            ActivateSwitch();
        }
    }
}
