using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public string cena;
    public string secondScena;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(cena);
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(secondScena);
    }
    public void QuitGame()
    {
        //Unity
       // UnityEditor.EditorApplication.isPlaying = false;
       Application.Quit();

    }
}
