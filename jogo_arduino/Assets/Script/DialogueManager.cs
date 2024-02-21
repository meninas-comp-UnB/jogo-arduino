using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialoguePanel;
    public Image profile;
    public Image slide;
    public Image newImageUI; // Image da UI a ser alterada
    public TextMeshProUGUI speechText;
    public TextMeshProUGUI actorNameText;
    private int index;
    public Sprite newImage;

    [Header("Settings")] 
    public float typingSpeed;
    private string[] sentences;
    private Sprite[] aula;
    private Sprite[] rostos;
    private string[] nomes;

    private bool changeImage = false; // Flag para indicar se a imagem deve ser alterada
    
    private static DialogueManager instance;

    private void Awake() 
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }

    public static DialogueManager GetInstance() 
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
      //  if (changeImage && newImageUI != null) // Se a flag changeImage estiver definida e a Image da UI não for nula
      ////  {
            //newImageUI.sprite = newImage; // Altera a sprite da Image da UI
       // }
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
                    newImageUI.sprite = newImage; 
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
