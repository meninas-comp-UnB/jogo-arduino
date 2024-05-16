using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionSetup : MonoBehaviour
{
    [SerializeField] private List<QuestionData> questions;
    private QuestionData currentQuestion;
    public bool tutorial_version;
    public string numberPhase;

    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private AnswerButton[] answerButtons;
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Image resultImage;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button backButton;

    [SerializeField] private Sprite spriteForPass; // Atribua no Unity
    [SerializeField] private Sprite spriteForFail; // Atribua no Unity
    [SerializeField] private Image finalImage;

    private int index = 1;
    private bool hasAnswered = false;
    private int correctAnswersCount = 0;

    private void Awake()
    {
        GetQuestionAssets();
    }

    void Start()
    {
        SetNextQuestion();
    }

    public void NextSentence()
    {
        if (!hasAnswered && index <= 5)
        {
            hasAnswered = true;
            SetNextQuestion();
        }
        else if (index > 5)
        {
            ShowResultPanel();
        }
    }

    private void GetQuestionAssets()
    {
        questions = new List<QuestionData>(Resources.LoadAll<QuestionData>(numberPhase));
    }

    private void SetNextQuestion()
    {
        SelectNewQuestion();
        SetQuestionValues();
        SetAnswerValues();
        SetPoint(index);
        index++;
        ResetButtonsInteractivity();
        hasAnswered = false;
    }

    private void SelectNewQuestion()
    {
        int randomQuestionIndex = Random.Range(0, questions.Count);
        currentQuestion = questions[randomQuestionIndex];
        questions.RemoveAt(randomQuestionIndex);
    }

    private void SetQuestionValues()
    {
        questionText.text = currentQuestion.question;
    }

    private void SetAnswerValues()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].Initialize(currentQuestion.answers[i], currentQuestion.images[i], i == currentQuestion.correctAnswer);
        }
    }

    private void SetPoint(int number)
    {
        pointsText.text = $"{number}/5";
    }

    private void ResetButtonsInteractivity()
    {
        foreach (var button in answerButtons)
        {
            button.ResetButtonAppearance();
        }
    }

    public void RegisterAnswer(bool isCorrect)
    {
        // Adicione lógica para processar a resposta, se necessário
        // Exemplo: Atualizar pontuação, mostrar painel de resultado, etc.
        if (isCorrect)
        {
            correctAnswersCount++;
        }
    }

    private void ShowResultPanel()
    {
        if (correctAnswersCount >= 3)
        {
            resultText.text = $"Parabéns pela conquista! Você acertou {correctAnswersCount} de 5 perguntas!";
            finalImage.sprite = spriteForPass;
            if(numberPhase == "Fase1"){
                PlayerPrefs.SetInt("PracticeImage", 1);
                PlayerPrefs.SetInt("Phase2", 1);
            }else if(numberPhase == "Fase2"){
                PlayerPrefs.SetInt("PracticeImage2", 1);
            }
            PlayerPrefs.Save();
        }
        else
        {
            resultText.text = $"Você acertou {correctAnswersCount} de 5 perguntas. Melhore na próxima vez!";
            finalImage.sprite = spriteForFail;
        }

        resultPanel.SetActive(true);
        playAgainButton.gameObject.SetActive(true);
        backButton.gameObject.SetActive(true);
    }

    public void PlayAgain()
    {
        if(numberPhase == "Fase1"){
            SceneManager.LoadScene("Mini-Game1");
        }else if(numberPhase == "Fase2"){
            SceneManager.LoadScene("Mini-Game2");
        }
       
    }

    public void GoBack()
    {
        if(numberPhase == "Fase1"){
             SceneManager.LoadScene("Fase-1");
        }else if(numberPhase == "Fase2"){
            SceneManager.LoadScene("Fase-2");
        }
       
    }

}
