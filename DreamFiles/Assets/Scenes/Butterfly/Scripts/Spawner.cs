using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Walls;
    public float respawnTime = 3f;
    public float timer;
    public bool count;
    public GameObject flower;
    public float flowerTimer = 180f;
    bool flowerSpawned = false;
    void Start()
    {
        if(Walls.Length == 0)
        {
            Debug.LogError("No Walls");
        }
        timer = 0f;
        count = true;
    }

    void Update()
    {
        flowerTimer -= Time.deltaTime;
        if(count)
            timer += Time.deltaTime;
        if(timer >= respawnTime)
        {
            timer = 0f;
            Spawn();
        }
    }
    void Spawn()
    {
        if(flowerTimer <= 0f && !flowerSpawned)
        {
            Instantiate(flower, transform.position, transform.rotation);
            flowerSpawned = true;
            return;
        }
        if(flowerSpawned)
        {
            return;
        }
        int idx = Random.Range(0, Walls.Length);
        GameObject wall = Instantiate(Walls[idx], transform.position, transform.rotation);
        wall.transform.parent = transform;
    }
    public void StartTimer()
    {
        count = true;
        timer = 0f;
    }
    public void StopTimer()
    {
        timer = 0f;
        count = false;
    }
}
