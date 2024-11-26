using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // �������� ����
    public int damage = 10;   // ���� �� ����
    public float lifetime = 5f; // ����� ����� ����

    void Start()
    {
        // ���������� ���� ����� �������� �����, ���� ��� �� ���������� � ������
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // �������� ���� ������
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ��������, ����������� �� ���� � ������
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // ����� ������ ��������� ����� � �����
            }

            Destroy(gameObject); // ���������� ���� ����� ���������
        }
    }
}
