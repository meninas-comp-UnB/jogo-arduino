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

    public void ChangeToPhase2()
    {
        if(PlayerPrefs.GetInt("Phase2", 0) == 1){
            ChangeToScene("Fase-2");
        }
        
    }
    public void ChangeToPhasesMenu()
    {
        ChangeToScene("Tela-Fases");
    }

}