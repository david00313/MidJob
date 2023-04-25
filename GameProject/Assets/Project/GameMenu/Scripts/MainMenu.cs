using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void PlayGame(){
        SceneManager.LoadScene(1);
    }
    public void ExitGame(){
        Debug.Log("Jocul s-a inchis");
        Application.Quit();
    }

    public void LoadGame(){
        LoadGun();
        SceneManager.LoadScene(1);

    }

        public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

    }

      public int usingAmmo;
    public int totalAmmo;
    public void LoadGun()
    {
        GunData data = SaveSystem.LoadGun();
        totalAmmo = data.totalAmmo;
        usingAmmo = data.usingAmmo;

    }


}


