using UnityEngine;

public class Platform : MonoBehaviour
{
    public enum MoveState : int { None, Wait, MoveLeft, MoveRight }
    public MoveState moveState { get; set; }

    private BoxCollider2D bc;
    private Rigidbody2D rb;

    public bool startPlatform = false;
    public bool start { get; set; }

    public float startXPoint { get; private set; }
    public float moveSpeed { get; private set; }
    public float waitTime { get; private set; }
    public float timer { get; set; }
    public bool already { get; set; }

    private void Awake()
    {
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        start = startPlatform;
    }

    private void OnEnable()
    {
        moveState =
            start && startPlatform ? MoveState.None : MoveState.Wait;
        startXPoint =
            start && startPlatform ? 0f : Random.Range(-1.5f, 1.5f);
        moveSpeed =
            start && startPlatform ? 0f : Random.Range(1f, 3f);
        waitTime =
            start && startPlatform ? 0f : Random.Range(1f, 3f);
        timer = 0;

        transform.position =
            new Vector3(startXPoint, transform.position.y, 0f);
        already = false;
    }

    private void Update()
    {
        if (bc != null)
        {
            float playerDatumPoint = Player.instance.transform.position.y - 0.5f;
            float thisPlatformDatumPoint = transform.position.y + 0.15f;
            float deltaHeight = playerDatumPoint - thisPlatformDatumPoint;

            if (deltaHeight > 0f)
            {
                bc.enabled = true;
            }
            else if (deltaHeight < -0.5f)
            {
                bc.enabled = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            GameManager.instance.RenewPlatformList(this);
        }
    }

    public void SetRigidbodyGravityScale(float gravityScale)
    {
        if (rb != null)
        { 
            rb.gravityScale = gravityScale;
        }
    }

    public void SetRigidbodyPosition(Vector2 position)
    {
        if (rb != null)
        { 
            rb.position = position;
        }
    }

    public void SetRigidbodyVelocity(Vector2 velocity)
    {
        if (rb != null)
        {
            rb.velocity = velocity;
        }
    }

    public Vector2 GetRigidbodyVelocity()
    {
        if (rb != null)
        {
            return rb.velocity;    
        }

        return Vector2.zero;
    }

    public void SetRigidbodyAddForce(Vector2 force)
    {
        if (rb != null)
        {
            rb.AddForce(force);
        }
    }
}
