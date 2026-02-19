using UnityEngine;
namespace StarterAssets
{
    public class Collectibles : MonoBehaviour
    {
        public int keyCode;
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
                    player.GetComponent<PlayerKeyHandler>().CollectKey(keyCode);
                    Destroy(gameObject);
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