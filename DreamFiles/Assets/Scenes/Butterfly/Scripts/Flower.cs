using UnityEngine;

public class Flower : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            // Game Finish
            ManagerFly manager = FindAnyObjectByType<ManagerFly>();
            manager.ResetGame();
        }
    }
}
