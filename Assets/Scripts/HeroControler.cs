// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.Animations;

public class HeroControler : MonoBehaviour
{

    [SerializeField] private float speed = 3f;
    [SerializeField] private int lives = 5;
    [SerializeField] private float jumpForce = 15f;

    private bool isGrounded = false;

    private Rigidbody2D _rb;
    private Animator anim;
    // для разварота
    private SpriteRenderer sprite;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        // если стоит на земеде анимация idle
        if (isGrounded) State = States.idle;
        if (Input.GetButton("Horizontal"))
            Run();
        if (isGrounded && Input.GetButtonDown("Jump"))
            Jump();

    }
    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Run()
    {
        // анимация бега вкл
        if (isGrounded) State = States.Run;
        //  часть движения
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        // Любопитноэ передвижение
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
        // Разворачивает персонажа 1 строчкой...
        sprite.flipX = dir.x < 0.0f;
    }

    private void Jump()
    {
        // Прижок
        _rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    // для анимации
    private States State
    {
        // При помощи get ми берем значение state из аниматора
        get { return (States)anim.GetInteger("state"); }
        // а set меняэт значение из get (state) 
        set { anim.SetInteger("state", (int)value); }
    }

    // Работает иза смещения оси координат к ногам спрайта
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = collider.Length > 1;

        if (!isGrounded) State = States.Jump;
    }


}
// enums велелая вещь, заменяет слово цифрой
// для анимации
public enum States
{
    idle,
    Run,
    Jump
}