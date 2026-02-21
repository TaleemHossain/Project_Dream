using UnityEngine;
namespace StarterAssets
{
    public class Doors : MonoBehaviour
    {
        public int requiredKeyCode;
        public Transform otherGate;
        bool PlayerInsideTrigger = false;
        GameObject tip;
        private StarterAssetsInputs input;
        void Awake()
        {
            tip = GameObject.FindGameObjectWithTag("Tip");
        }
        void Start()
        {
            input = GameObject.FindGameObjectWithTag("Player").GetComponent<StarterAssetsInputs>();
            tip.SetActive(false);
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
            }
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerInsideTrigger = true;
            }
            tip.SetActive(PlayerInsideTrigger);
        }
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                PlayerInsideTrigger = false;
            }
            tip.SetActive(PlayerInsideTrigger);
        }
        void OnDrawGizmos()
        {
            if (otherGate != null)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(transform.position, otherGate.position);
            }
        }
    }
}