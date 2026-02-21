using UnityEngine;

namespace StarterAssets
{
    public class Question : MonoBehaviour
    {
        public GameObject QuestionPanel;
        public GameObject[] destroyObjects;
        bool playerInRange = false;
        GameObject tip;
        StarterAssetsInputs inputs;
        void Awake()
        {
            tip = GameObject.FindGameObjectWithTag("Tip");
        }
        void Start()
        {
            QuestionPanel.SetActive(false);
            inputs = GameObject.FindGameObjectWithTag("Player").GetComponent<StarterAssetsInputs>();
        }

        void Update()
        {
            if (playerInRange && inputs.interact)
            {
                if (!QuestionPanel.activeSelf)
                {
                    PanelEnable();
                }
                else
                {
                    PanelDisable();
                }
            }
        }
        void PanelEnable()
        {
            Time.timeScale = 0f;
            Debug.Log("Opening Question Panel");
            QuestionPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        void PanelDisable()
        {
            Time.timeScale = 1f;
            Debug.Log("Closing Question Panel");
            QuestionPanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = true;
            }
            tip.SetActive(playerInRange);
        }
        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                playerInRange = false;
            }
            tip.SetActive(playerInRange);
        }
        public void OnCorrectAnswer()
        {
            foreach (GameObject obj in destroyObjects)
            {
                Destroy(obj);
            }
        }
    }
}