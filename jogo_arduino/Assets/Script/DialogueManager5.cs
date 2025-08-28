using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager5 : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Image profile;
    public Image slide;
    public Image theoricImage;
    public Image practiceImage;
    public TextMeshProUGUI speechText;
    public TextMeshProUGUI actorNameText;

    public float typingSpeed;
    private string[] sentences;
    private Sprite[] characters;
    private Sprite[] slides;
    private string[] actorNames;
    private bool changeImage = false;
    public Sprite newImageTheoric;
    public Sprite newImagePractice;

    private int index;

    private static DialogueManager5 instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
        if (PlayerPrefs.GetInt("ImageChanged3", 0) == 1)
        {
            theoricImage.sprite = newImageTheoric;
        }
        if (PlayerPrefs.GetInt("ImageChanged3", 0) == 1 && PlayerPrefs.GetInt("PracticeImage3", 0) == 1)
        {
            practiceImage.sprite = newImagePractice;

        }
        if (PlayerPrefs.GetInt("ImageChanged4", 0) == 1 && PlayerPrefs.GetInt("PracticeImage4", 0) == 1)
        {
            practiceImage.sprite = newImagePractice;

        }
         if(PlayerPrefs.GetInt("ImageChanged5", 0) == 1 && PlayerPrefs.GetInt("PracticeImage5", 0) == 1){
            practiceImage.sprite = newImagePractice;

        }
        

    }

    public static DialogueManager5 GetInstance() 
    {
        return instance;
    }

    public void Speech(Sprite[] characters, string[] sentences, string[] actorNames, Sprite[] slides, bool changeImage = false)
    {
        this.characters = characters;
        this.sentences = sentences;
        this.actorNames = actorNames;
        this.slides = slides;
        this.changeImage = changeImage;

        dialoguePanel.SetActive(true);
        index = 0;
        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        profile.sprite = characters[index];
        actorNameText.text = actorNames[index];
        slide.sprite = slides[index];
        speechText.text = "";

        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NextSentence()
    {
        if (speechText.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;
                StartCoroutine(TypeSentence());
            }
            else
            {
                EndDialogue();
            }
        }
    }

    private void EndDialogue()
    {
        speechText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        
        if (changeImage)
        {
            PlayerPrefs.SetInt("ImageChanged5", 1);
            PlayerPrefs.Save();
            theoricImage.sprite = newImageTheoric; 
        }
    }

    public void StopDialogue()
    {
        speechText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }

    public void ExitDialogueMode(){
    speechText.text = ""; 
    index = 0; 
    dialoguePanel.SetActive(false); 
    }

}
