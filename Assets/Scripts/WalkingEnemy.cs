using UnityEngine;

public class WalkingEnemy : Entity
{
    // private float speed = 3f;
    private Vector3 dir;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    [SerializeField] private bool moveRight = false, somthing = false;
    private void Start()
    {
        dir = transform.right;
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        startPosition = transform.position;
    }

    // private void Update()
    // {
    //     Move();
    // }

    // private void Move()
    // {
    //     Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * dir.x * 0.7f, 0.1f);

    //     if (colliders.Length > 0) dir *= -1f;
    //     transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    // }
    Vector3 startPosition = Vector3.zero;
    [SerializeField] float offsetLeft = 0, offsetRight = 0, speed = 1;

    void FixedUpdate()
    {
        if (somthing)
        {
            moveRight = !moveRight;
            somthing = false;
            rb.gameObject.transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
        if (moveRight && transform.position.x < startPosition.x + offsetRight)
        {
            Move(offsetRight);
        }
        else if (transform.position.x >= startPosition.x + offsetRight)
        {
            moveRight = false;
            rb.gameObject.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        if (!moveRight && transform.position.x > startPosition.x + offsetLeft)
        {
            Move(offsetLeft);
        }
        else if (transform.position.x <= startPosition.x + offsetLeft)
        {
            moveRight = true;
            rb.gameObject.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
    void Move(float offset)
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(startPosition.x + offset, transform.position.y, transform.position.z), speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        somthing = true;
        if (other.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
        }
    }

}
