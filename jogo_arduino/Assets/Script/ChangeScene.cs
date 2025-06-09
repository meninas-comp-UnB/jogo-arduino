using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
public void ChangeToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ChangeToPhase1()
    {
        ChangeToScene("Fase-1");
    }

    public void ChangeToPhase_2()
    {
        ChangeToScene("Fase-2");
    }

    public void ChangeToPhase_3()
    {
        ChangeToScene("Fase-3");
    }


    public void ChangeToPhase2()
    {
        if(PlayerPrefs.GetInt("Phase2", 0) == 1){
            ChangeToScene("Fase-2");
        }
        
    }

    public void ChangeToPhase3()
    {
        if(PlayerPrefs.GetInt("Phase3", 0) == 1){
            ChangeToScene("Fase-3");
        }
        
    }
    public void ChangeToPhasesMenu()
    {
        ChangeToScene("Tela-Fases");
    }
    public void ChangeToQuiz1(){
        ChangeToScene("Mini-Game1");
    }
    public void ChangeToQuiz2(){
        ChangeToScene("Mini-Game2");
    }

    public void ChangeToQuiz3(){
        ChangeToScene("Mini-Game3");
    }

}