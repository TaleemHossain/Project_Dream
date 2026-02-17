using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public float damage = 20f;
    public float knockbackForce = 5f;
    Rigidbody2D rb;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.linearVelocity = transform.up * bulletSpeed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.transform.GetComponent<Health>();
        if(health != null)
        {
            Vector3 knockbackDir = collision.transform.position - transform.position;
            health.TakeDamage(damage, knockbackDir.normalized, knockbackForce);
        }
        Destroy(gameObject);
    }
}
