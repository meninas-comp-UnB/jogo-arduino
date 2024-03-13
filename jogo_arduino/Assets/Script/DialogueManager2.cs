using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DialogueManager2 : MonoBehaviour
{
[Header("Components")]
    public GameObject dialoguePanel;
    public Image profile;
    public Image slide;
    public Image theoricImage; // Image da UI a ser alterada
    public Image practiceImage;
    public TextMeshProUGUI speechText;
    public TextMeshProUGUI actorNameText;
    private int index;
    public Sprite newImageTheoric;
    public Sprite newImagePractice;

    [Header("Settings")] 
    public float typingSpeed;
    private string[] sentences;
    private Sprite[] aula;
    private Sprite[] rostos;
    private string[] nomes;

    private bool changeImage = false; // Flag para indicar se a imagem deve ser alterada
    
    private static DialogueManager2 instance;

    private void Awake() 
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
        if(PlayerPrefs.GetInt("ImageChanged2", 0) == 1){
            theoricImage.sprite = newImageTheoric;
        }
        if(PlayerPrefs.GetInt("ImageChanged2", 0) == 1 && PlayerPrefs.GetInt("PracticeImage2", 0) == 1){
            practiceImage.sprite = newImagePractice;

        }
        

    }
    
    public static DialogueManager2 GetInstance() 
    {
        return instance;
    }

    private void Start(){
        dialoguePanel.SetActive(false);
    }

    public void Speech(Sprite[] p, string[] txt, string[] actorName, Sprite[] Slide, bool changeImage = false)
    {
        dialoguePanel.SetActive(true);
        rostos = p;
        sentences = txt;
        nomes = actorName;
        aula = Slide; 
        this.changeImage = changeImage; // Define a flag para alterar a imagem
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence(){
        profile.sprite = rostos[index];
        actorNameText.text = nomes[index];
        slide.sprite = aula[index]; 
        foreach (char letter in sentences[index].ToCharArray()){
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence(){
        if(speechText.text == sentences[index]){
            if(index < sentences.Length -1){
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }else{
                if(changeImage){
                    // Define a preferência de imagem alterada como 1
                    PlayerPrefs.SetInt("ImageChanged2", 1);
                    PlayerPrefs.Save();
                    theoricImage.sprite = newImageTheoric; 
                }
                speechText.text = "";
                index = 0;
                dialoguePanel.SetActive(false);
            }
        }
    }

    public void StopDialogue(){
        speechText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    public void ExitDialogueMode(){
        dialoguePanel.SetActive(false);
    }

}
