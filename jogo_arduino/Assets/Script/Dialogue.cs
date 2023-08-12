using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite[] profile;
    public Sprite[] slide;
    public string[] speechTxt;
    public string[] actorName;

    private DialogueManager dc;

    public void Start(){
        dc = FindObjectOfType<DialogueManager>();
    }
}
