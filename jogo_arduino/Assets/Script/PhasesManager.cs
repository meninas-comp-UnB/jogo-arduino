using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PhasesManager : MonoBehaviour
{
    [Header("Components")]
    public Image phase1to2; // Image da UI a ser alterada
    public Image phase2to3;
    public Sprite cabo1;
    public Sprite cabo2;
    private void Awake() 
    {

        if(PlayerPrefs.GetInt("Phase2", 0) == 1){
            phase1to2.sprite = cabo1;
        }
        if(PlayerPrefs.GetInt("Phase3", 0) == 1){
            phase2to3.sprite = cabo2;
        }
        

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
