using UnityEngine;

public class TowerGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float nextFireTime = 0f;

    private void Update()
    {
        RotateToMouse();

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime) // ЛКМ для стрельбы
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private void RotateToMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        if (plane.Raycast(ray, out float distance))
        {
            Vector3 point = ray.GetPoint(distance);
            Vector3 direction = point - transform.position;
            direction.y = 0; // Убрать вращение по оси Y
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

