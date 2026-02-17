using UnityEngine;

public class Wall : MonoBehaviour
{
    public float velX = 10f;
    Rigidbody2D rb;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        rb.linearVelocity = Vector2.left * velX;
    }
}
