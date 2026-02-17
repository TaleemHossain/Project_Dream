using UnityEngine;

public class GunZombie : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float attackCooldown = 1f;
    float lastAttackTime = 0f;
    public Transform Firepoint;
    public GameObject Bullet;
    void Start()
    {

    }

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePos - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(angle > 90f || angle < -90f)
        {
            transform.GetComponent<SpriteRenderer>().flipY = true;
        } else
        {
            transform.GetComponent<SpriteRenderer>().flipY = false;
        }

        Quaternion targetRot = Quaternion.Euler(0, 0, angle);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        if(Time.time - lastAttackTime < attackCooldown)
        {
            return;
        }
        lastAttackTime = Time.time;
        GameObject bul = Instantiate(Bullet, Firepoint.position, Firepoint.rotation);
        Destroy(bul, 2);
    }
}
