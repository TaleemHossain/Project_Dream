using UnityEngine;

public class PlayerMovementZombie : MonoBehaviour
{
    public float speed = 10f;
    
    Rigidbody2D rb;
    Animator animator;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        animator = transform.GetComponent<Animator>();
    }

    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");

        if (hor < 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = true;
            // transform.localScale = new(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (hor > 0)
        {
            transform.GetComponent<SpriteRenderer>().flipX = false;
            // transform.localScale = new(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePos - transform.position;
            if (direction.x > 0)
            {
                transform.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                transform.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        float ver = Input.GetAxisRaw("Vertical");
        Vector2 inputDir = new(hor, ver);
        rb.linearVelocity = inputDir.normalized * speed;
        if (rb.linearVelocity.magnitude > 0.01f)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }
}
