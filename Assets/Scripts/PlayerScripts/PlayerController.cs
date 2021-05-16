using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}

public class PlayerController : MonoBehaviour
{
    public PlayerState currentState;
    private PlayerControl inputActions;
    private Rigidbody2D rgb2d;
    [SerializeField] private float playerSpeed = 2f;
    private Animator animator;

    private Bow equipedWeapon;


    public VectorValue startingPosition;
    public SpriteRenderer receivedItemSprite;
    public UnityEvent cameraShock;

    [Header("Impact Management")]
    public Color flashColor;
    public Color regularColor;
    public float flashDuration;
    public int numberOfFlashes;
    public Collider2D triggerCollider;
    public SpriteRenderer mySprite;


    private void Awake()
    {
        currentState = PlayerState.walk;
        inputActions = new PlayerControl();
        rgb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        equipedWeapon = GetComponent<Bow>();

    }

    private void Start()
    {
        transform.position = startingPosition.initialValue;
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void FixedUpdate()
    {


        if (currentState == PlayerState.interact)
        {
            return;
        }
        Vector2 moveInput = Vector2.zero;
        moveInput = inputActions.Movement.Move.ReadValue<Vector2>();

        
        animator.SetFloat("Speed", moveInput.sqrMagnitude);
        

        if(moveInput != Vector2.zero)
        {
            animator.SetFloat("Horizontal", moveInput.x);
            animator.SetFloat("Vertical", moveInput.y);
        }
        

        float attack = inputActions.Movement.Attack.ReadValue<float>();
        if ( (attack == 1) && (currentState != PlayerState.attack) && (currentState != PlayerState.stagger))
        {
            StartCoroutine(AttackCo());
        } else if (currentState == PlayerState.walk || currentState == PlayerState.idle)
        {
            MoveCharacter(moveInput);
        }
        
    }

    void MoveCharacter(Vector2 moveInput)
    {
        rgb2d.MovePosition(new Vector2 (transform.position.x, transform.position.y) + moveInput * playerSpeed * Time.fixedDeltaTime);
    }

    public void Knock(float knockTime)
    {
        cameraShock.Invoke();
        StartCoroutine(KnockCo(knockTime));
    }

    private IEnumerator KnockCo(float knockTime)
    {
        if (rgb2d != null)
        {
            StartCoroutine(FlashCo());
            yield return new WaitForSeconds(knockTime);
            rgb2d.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            rgb2d.velocity = Vector2.zero;
        }
    }

    private IEnumerator FlashCo()
    {
        int temp = 0;
        triggerCollider.enabled = false;
        while (temp < numberOfFlashes)
        {
            mySprite.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            mySprite.color = regularColor;
            yield return new WaitForSeconds(flashDuration);
            temp++;
        }
        triggerCollider.enabled = true;
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("Attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("Attacking", false);
         yield return new WaitForSeconds(.4f);
        if(currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    //TODO fix rasie chest item  after updaing the inventory
    /*
    public void RaiseItem()
    {
        if(playerInventory.currentItem != null)
        {
            if (currentState != PlayerState.interact)
            {
                animator.SetBool("ReceiveItem", true);
                currentState = PlayerState.interact;
                receivedItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else
            {
                animator.SetBool("ReceiveItem", false);
                currentState = PlayerState.idle;
                receivedItemSprite.sprite = null;
                playerInventory.currentItem = null;
            }
        }
    }
    */
}
