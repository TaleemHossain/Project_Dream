using NUnit.Framework;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MaxHealth = 100f;
    float currentHealth;
    public bool IsDead;
    Animator animator;
    Rigidbody2D rb;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        animator = transform.GetComponent<Animator>();
        IsDead = false;
        currentHealth = MaxHealth;
    }
    void Update()
    {
        if(currentHealth <= 0 && !IsDead)
        {
            IsDead = true;
            if(animator != null)
                animator.SetTrigger("Die");
            else
                Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
    public void TakeDamage(float damage, Vector3 knockbackDirection, float knockbackForce)
    {
        currentHealth -= damage;
        if(rb != null)
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Force);
        if(animator != null)
            animator.SetTrigger("Hit");
    }
}
