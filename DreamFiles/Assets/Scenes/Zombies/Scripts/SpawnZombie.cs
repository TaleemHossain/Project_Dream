using UnityEngine;

public class SpawnZombie : MonoBehaviour
{
    public GameObject zombiePrefab;
    float respawnTime = 5f;
    float lastSpawnTime = 0f;
    public Transform spawnPoint;

    void Start()
    {
        Spawn();
    }

    void Update()
    {
        if(Time.time - lastSpawnTime > respawnTime)
        {
            Spawn();
        }
    }
    void Spawn()
    {
        Instantiate(zombiePrefab, spawnPoint.position, Quaternion.identity);
        lastSpawnTime = Time.time;
    }
}
