using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [Header("Components")]
   // [SerializeField] private GameObject dialoguePanel;

    public GameObject dialoguePanel;
    public Image profile;
    public Image slide;
    public TextMeshProUGUI speechText;
    public TextMeshProUGUI actorNameText;
    private int index;

    [Header("Settings")] 
    public float typingSpeed;
    private string[] sentences;
    private Sprite[] aula;
    private Sprite[] rostos;
    private string[] nomes;


   // [SerializeField] private TextMeshProUGUI dialogueText;

   // private Story currentStory;

    private bool dialogueIsPlaying;

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
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);



    }

    public void Speech( Sprite[] p, string[] txt, string[] actorName, Sprite[] Slide)
{
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        rostos = p;
        sentences = txt;
        nomes = actorName;
        aula = Slide; 
      //  profile.sprite = rostos[0];
        //actorNameText.text = nomes[0];
        //slide.sprite = aula[0]; 
        StartCoroutine(TypeSentece());
}

    IEnumerator TypeSentece(){
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
            //ainda tem textos
            if(index < sentences.Length -1){

                index++;
                speechText.text = "";
                StartCoroutine(TypeSentece());
            }else{// quando acabar
                speechText.text = "";
                index = 0;
                dialoguePanel.SetActive(false);
            }
        }
    }


    private void Update(){
        if(!dialogueIsPlaying){
            return;
        }

    }
    public void StopDialogue(){
        speechText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
   }

    public void ExitDialogueMode(){
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
       // dialogueText.text = "";
    }

}