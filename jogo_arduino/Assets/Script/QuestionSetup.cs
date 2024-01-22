using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionSetup : MonoBehaviour
{
    [SerializeField] private List<QuestionData> questions;
    private QuestionData currentQuestion;

    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private AnswerButton[] answerButtons;
    [SerializeField] private TextMeshProUGUI pointsText;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Image resultImage;

    private int index = 1;
    private bool hasAnswered = false;

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
    }

    private void GetQuestionAssets()
    {
        questions = new List<QuestionData>(Resources.LoadAll<QuestionData>("Fase1"));
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
    public bool HasAnswered
    {
        get { return hasAnswered; }
    }
    public void RegisterAnswer(bool isCorrect)
    {
        // Adicione lógica para processar a resposta, se necessário
        // Exemplo: Atualizar pontuação, mostrar painel de resultado, etc.
    }
}
