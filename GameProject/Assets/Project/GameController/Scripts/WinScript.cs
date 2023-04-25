using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameObject[] _gameObject;
    public static int enemyCount;
    private int enemyCountSet;
    private void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    private void Update() {
        EnemysAlive();
        if(enemyCount == 0){
            SceneManager.LoadScene(2);
            Debug.Log("gata");

        }
    }

    void EnemysAlive ()
    {
        _gameObject = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 1; i < _gameObject.Length - 1; i++){
                enemyCount = i;
            
        }
    }

}

