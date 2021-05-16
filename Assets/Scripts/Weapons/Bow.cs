using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    private PlayerControl inputActions;
    private Animator animator;
    private PlayerController playerController;

    private void Awake()
    {
        inputActions = new PlayerControl();
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    void Start()
    {
        inputActions.Movement.Attack2.performed += _ => Attack();
    }

    public void Attack()
    {
        if ((playerController.currentState != PlayerState.attack) && (playerController.currentState != PlayerState.stagger))
        {
            StartCoroutine(BowAttackCo());
        }
    }

    public void Shoot()
    {
        Vector2 temp = new Vector2(animator.GetFloat("Horizontal"), animator.GetFloat("Vertical"));
        Arrow newArrow = Instantiate(projectile, shotPoint.position, shotPoint.rotation).GetComponent<Arrow>();
        newArrow.Setup(temp, ChooseArrowDirection());
    }

    private Vector3 ChooseArrowDirection()
    {
        float temp = Mathf.Atan2(animator.GetFloat("Vertical"), animator.GetFloat("Horizontal")) * Mathf.Rad2Deg;
        return new Vector3(0, 0, temp);
    }

    private IEnumerator BowAttackCo()
    {
        animator.SetBool("Attacking_Bow", true);
        playerController.currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("Attacking_Bow", false);
        Shoot();
        yield return new WaitForSeconds(.4f);
        if (playerController.currentState != PlayerState.interact)
        {
            playerController.currentState = PlayerState.walk;
        }
    }
}
