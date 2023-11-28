using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionSetup : MonoBehaviour
{
    [SerializeField]
    private List<QuestionData> questions;
    private QuestionData currentQuestion;

    [SerializeField]
    private TextMeshProUGUI questionText;
    
    [SerializeField]
    private AnswerButton[] answerButtons;

    [SerializeField]
    private TextMeshProUGUI pointsTela;
    
    private int index;

    private void Awake()
    {
        // Get all the questions ready
        GetQuestionAssets();
    }

    // Start is called before the first frame update
    void Start()
    {
        index = 1;
        //Get a new question
        SelectNewQuestion();
        // Set all text and values on screen
        SetQuestionValues();
        // Set all of the answer buttons text and correct answer values
        SetAnswerValues();
        SetPoint(index);
        index++;
        
    }


    public void NextSentence(){
        if(index < 6){
             SelectNewQuestion();
            // Set all text and values on screen
            SetQuestionValues();
            // Set all of the answer buttons text and correct answer values
            SetAnswerValues();
            SetPoint(index);
            index++;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetQuestionAssets()
    {
        // Get all of the questions from the questions folder
        questions = new List<QuestionData>(Resources.LoadAll<QuestionData>("Fase1"));
    }

    private void SelectNewQuestion()
    {
        // Get a random value for which question to choose
        int randomQuestionIndex = Random.Range(0, questions.Count);
        //Set the question to the randon index
        currentQuestion = questions[randomQuestionIndex];
        //Set the image to help to interpretate the question
        
        // Remove this questionm from the list so it will not be repeared (until the game is restarted)
        questions.RemoveAt(randomQuestionIndex);
    }

    private void SetQuestionValues()
    {
        // Set the question text
        questionText.text = currentQuestion.question;
    }

    private void SetAnswerValues()
    {
        // Randomize the answer button order
       // List<string> answers = RandomizeAnswers(new List<string>(currentQuestion.answers));
       int contadorCorrect = 0;

        // Set up the answer buttons
        for (int i = 0; i < answerButtons.Length; i++)
        {
            // Create a temporary boolean to pass to the buttons
            bool isCorrect = false;

            // If it is the correct answer, set the bool to true
            if(i == currentQuestion.correctAnswer)
            {
                isCorrect = true;
                contadorCorrect++;
                
            }

            answerButtons[i].SetIsCorrect(isCorrect);
            answerButtons[i].SetAnswerText(currentQuestion.answers[i]);
            answerButtons[i].SetAnswerImage(currentQuestion.images[i]);
            
        }
    }

    

    public void SetPoint(int number){
        Debug.Log(number);
        string text = number + "/5";
        pointsTela.text = text;
    }
}