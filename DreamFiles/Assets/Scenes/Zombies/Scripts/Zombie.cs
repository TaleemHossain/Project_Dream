using UnityEngine;

public class Zombie : MonoBehaviour
{
    Transform player;
    public float maxClosingDistance = 0.5f;
    public float speed = 5f;
    public float damage = 20f;
    public float knockbackForce = 5f;
    public float attackCooldown = 2f;
    float lastAttackTime = 0f;
    public float attackRange = 2f;
    Rigidbody2D rb;
    Health health;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        health = transform.GetComponent<Health>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(health.IsDead)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }
        Vector3 dir = player.transform.position - transform.position;
        if(dir.magnitude > maxClosingDistance)
        {
            rb.linearVelocity = dir.normalized * speed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
        if(rb.linearVelocityX < 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = true;
        } 
        else if(rb.linearVelocityX > 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    void FixedUpdate()
    {
        if(health.IsDead)
        {
            return;
        }
        Attack();
    }
    void Attack()
    {
        if(Time.time - lastAttackTime > attackCooldown)
        {
            Vector3 dir = player.transform.position - transform.position;
            // Debug.Log("Distance to player: " + dir.magnitude);
            if(dir.magnitude < attackRange)
            {
                Health health = player.GetComponent<Health>();
                if(health != null)
                {
                    Vector3 knockbackDir = dir.normalized;
                    health.TakeDamage(damage, knockbackDir, knockbackForce);
                }
                lastAttackTime = Time.time;
            }
        }
    }
}
