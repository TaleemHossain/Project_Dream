using UnityEngine;
using UnityEngine.UI;
using TMPro;
using StarterAssets;
public class QuestionPanel : MonoBehaviour
{
    [System.Serializable]
    public struct QuestionData
    {
        public string questionText;
        public string correctAnswer;
    }

    public QuestionData[] questions;
    public Question questionScript;
    public TextMeshProUGUI questionTextUI;
    public TMP_InputField answerInput;
    int QuestionIndex = 0;

    void Start()
    {
        ChooseQuestion();
        ShowQuestion();
    }

    void ChooseQuestion()
    {
        QuestionIndex = Random.Range(0, questions.Length);
    }
    void ShowQuestion()
    {
        questionTextUI.text = questions[QuestionIndex].questionText;
    }
    public void SubmitAnswer()
    {
        if (int.TryParse(answerInput.text, out int playerAnswer))
        {
            if (playerAnswer == int.Parse(questions[QuestionIndex].correctAnswer))
            {
                questionScript.OnCorrectAnswer();
                answerInput.gameObject.SetActive(false);
                questionTextUI.text = "Correct!";
            }
            else
            {
                Debug.Log("Wrong answer");
                answerInput.text = "";
            }
        }
        else
        {
            Debug.Log("Invalid input.");
            answerInput.text = "";
        }
    }
}
