using UnityEngine;
using UnityEngine.UI;
namespace StarterAssets
{
    public class Collectibles : MonoBehaviour
    {
        public int keyCode;
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
                    player.GetComponent<PlayerKeyHandler>().CollectKey(keyCode);
                    tip.SetActive(false);
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
    }
}