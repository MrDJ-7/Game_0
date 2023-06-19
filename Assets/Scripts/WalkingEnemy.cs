using UnityEngine;

public class WalkingEnemy : Entity
{
    private float speed = 3f;
    private Vector3 dir;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Start()
    {
        dir = transform.right;
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * dir.x * 0.7f, 0.1f);

        if (colliders.Length > 0) dir *= -1f;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
        }
    }
}
