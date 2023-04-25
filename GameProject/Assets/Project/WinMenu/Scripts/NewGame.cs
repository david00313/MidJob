using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    private void Start() {
        Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
    }
    public void PlayNewGame(){
        Debug.Log("New Game");
        SceneManager.LoadScene(1);
    }
    public void ExitGame(){
        Debug.Log("Jocul s-a inchis");
        Application.Quit();
    }
    public void MainMenu(){
        SceneManager.LoadScene(0);
    }
}
