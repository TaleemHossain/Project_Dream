using UnityEngine;

public class PlayerKeyHandler : MonoBehaviour
{
    private bool[] Keys;
    void Start()
    {
        Keys = new bool[3];
    }
    public void CollectKey(int keyCode)
    {
        if (keyCode >= 0 && keyCode < Keys.Length)
        {
            Keys[keyCode] = true;
            Debug.Log("Collected key with code: " + keyCode);
        }
        else
        {
            Debug.LogWarning("Invalid key code: " + keyCode);
        }
    }
    public bool HasKey(int keyCode)
    {
        if (keyCode >= 0 && keyCode < Keys.Length)
        {
            return Keys[keyCode];
        }
        else
        {
            Debug.LogWarning("Invalid key code: " + keyCode);
            return false;
        }
    }
}
