using UnityEngine;

public class Butterfly : MonoBehaviour
{
    public Sprite[] player;
    public float vel = 10f;
    Rigidbody2D rb;
    public Transform respawn;
    int idx;
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        idx = 0;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (idx + 2 < player.Length)
                rb.linearVelocityY += vel;
            if (idx % 2 == 0)
            {
                idx++;
                transform.GetComponent<SpriteRenderer>().sprite = player[idx];
            }
            else
            {
                idx--;
                transform.GetComponent<SpriteRenderer>().sprite = player[idx];
            }

        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        FindAnyObjectByType<ManagerFly>().ResetGame();
        if (idx + 2 >= player.Length)
        {
            // exit_game
        }
        else
        {
            idx += 2;
            transform.GetComponent<SpriteRenderer>().sprite = player[idx];
        }
    }
    public void Reposition()
    {
        transform.position = respawn.position;
    }
}
