using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    private bool isCorrect;
    [SerializeField] private TextMeshProUGUI answerText;

    
    [SerializeField] private Image answerImage; // Usando Image para exibir a Sprite

    // Método para configurar o texto da resposta e a Sprite
    public void SetAnswerImage( Sprite newSprite)
    {
        answerImage.sprite = newSprite;
    }
    public void SetAnswerText(string newText)
    {
        answerText.text = newText;
    }


    // Método para configurar se a resposta é correta ou não
    public void SetIsCorrect(bool newBool)
    {
        isCorrect = newBool;
    }

    // Método chamado quando o botão é clicado
    public void OnClick()
    {
        if (isCorrect)
        {
            Debug.Log("CORRECT ANSWER");
            SetAnswerText("Acertou");
            // Adicione aqui as ações a serem realizadas quando a resposta estiver correta
        }
        else
        {
            Debug.Log("WRONG ANSWER");
            SetAnswerText("Errou");
            // Adicione aqui as ações a serem realizadas quando a resposta estiver incorreta
        }
    }
}
