using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
    public bool tutorialVersion;

    public Sprite[] profile;
    public Sprite[] slide;
    public string[] speechText;
    public string[] actorNameText;

    private bool playerInRange;

    private void Awake() 
    {
        playerInRange = false;
        visualCue.SetActive(true);
    }

    private void Update() 
    {
        if (playerInRange ) 
        {
            visualCue.SetActive(false);

            //DialogueManager.GetInstance().Speech(profile, speechText, actorNameText, slide);

        }
        else 
        {
            visualCue.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
            if(tutorialVersion == true){
                DialogueTutorial.GetInstance().Speech(profile, speechText, actorNameText, slide);
            }else{
              DialogueManager.GetInstance().Speech(profile, speechText, actorNameText, slide);  
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}