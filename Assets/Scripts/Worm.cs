using UnityEngine;

public class Worm : Entity
{
    [SerializeField] private int lives = 3;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
            lives--;
            Debug.Log($"Worm lives {lives}");
        }

        if (lives < 1)
        {
            Die();
        }
    }


}
