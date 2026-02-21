using UnityEngine;

public class ManagerFly : MonoBehaviour
{
    public Butterfly butterfly;
    public Spawner spawner;
    public GameObject text;
    void Start()
    {
        Time.timeScale = 0f;
        text.SetActive(true);
    }
    void Update()
    {
        if(Time.timeScale == 0f)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                text.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }
    public void ResetGame()
    {
        spawner.StopTimer();
        butterfly.Reposition();
        Transform parent = spawner.transform;

        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            Destroy(parent.GetChild(i).gameObject);
        }
        spawner.StartTimer();
    }
}
