using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public int damage = 10;
    public int health = 20;
    public Transform target;

    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject); // ”ничтожить объект врага
    }
}
