using UnityEngine;
namespace StarterAssets
{
    public class Doors : MonoBehaviour
    {
        public int requiredKeyCode;
        public Transform otherGate;
        bool PlayerInsideTrigger = false;
        private StarterAssetsInputs input;
        void Start()
        {
            input = GameObject.FindGameObjectWithTag("Player").GetComponent<StarterAssetsInputs>();
        }
        void Update()
        {
            if (PlayerInsideTrigger)
            {
                if (input.interact)
                {
                    GameObject player = GameObject.FindGameObjectWithTag("Player");
                    if (player.GetComponent<PlayerKeyHandler>().HasKey(requiredKeyCode))
                    {
                        if (otherGate != null)
                        {
                            player.transform.position = otherGate.position;
                        }
                    }
                }
                else
                {
                    Debug.Log("You need the correct key to open this door.");
                }
            }
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerInsideTrigger = true;
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerInsideTrigger = false;
            }
        }
    }
}