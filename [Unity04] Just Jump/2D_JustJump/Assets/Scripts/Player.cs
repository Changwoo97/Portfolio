using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    private CircleCollider2D cc;
    private Animator ani;

    private float deltaX = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        { 
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        cc = GetComponent<CircleCollider2D>();
        ani = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform" && ani != null)
        {
            ani.SetTrigger("JumpDown");
            deltaX = transform.position.x - collision.collider.transform.position.x;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform")
        {
            transform.position =
                new Vector3(collision.collider.transform.position.x + deltaX, -1.5f, 0f);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Platform" && ani != null)
        {
            ani.SetTrigger("JumpUp");
        }
    }

    public float GetCircleColliderRadius()
    {
        if (cc != null)
        {
            return cc.radius;
        }

        return 0f;
    }
}
