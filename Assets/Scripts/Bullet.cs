using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // Скорость пули
    public int damage = 10;   // Урон от пули
    public float lifetime = 5f; // Время жизни пули

    void Start()
    {
        // Уничтожить пулю через заданное время, если она не столкнется с врагом
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Движение пули вперед
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Проверка, столкнулась ли пуля с врагом
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Вызов метода получения урона у врага
            }

            Destroy(gameObject); // Уничтожить пулю после попадания
        }
    }
}
