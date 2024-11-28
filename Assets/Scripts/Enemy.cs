using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public int damage = 10;
    public int health = 20;
    public AudioSource hitSource;
    public Transform hitPoint;
    public GameObject HitEffect;

    private Transform target;

    void Start()
    {
        hitSource = GetComponent<AudioSource>();

        target = FindObjectOfType<PlayerTower>().transform;
    }

    void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        hitSource.Play();
        Instantiate(HitEffect, hitPoint.position, hitPoint.rotation);

        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject, 0.5f); // ”ничтожить объект врага
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerTower playerTower))
        {
            TowerHealth tower = collision.gameObject.GetComponent<TowerHealth>();
            if (tower != null)
            {
                tower.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
