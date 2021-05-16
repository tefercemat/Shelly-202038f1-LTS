using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Header("Arrow Parameters")]
    [SerializeField] private float arrowSpeed;
    [SerializeField] private float arrowStickLifetime = 2.0f;
    [SerializeField] private float arrowLifetime = 5.0f;

    [Header("Arrow Components")]
    [SerializeField] private Rigidbody2D myRigidBody;

    public void Setup(Vector2 velocity, Vector3 direction)
    {
        myRigidBody.velocity = velocity.normalized * arrowSpeed;
        transform.rotation = Quaternion.Euler(direction);
    }

    private void Start()
    {
        Destroy(this.gameObject, arrowLifetime);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            ArrowStick(other);
        }
    }

    private void ArrowStick(Collider2D col)
    {
        transform.parent = col.transform;
        Destroy(myRigidBody);
        this.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(DestroyArrow());
    }

    private IEnumerator DestroyArrow()
    {
        yield return new WaitForSeconds(arrowStickLifetime);
        Destroy(this.gameObject);
    }
}
