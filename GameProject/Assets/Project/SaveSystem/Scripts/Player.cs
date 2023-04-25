using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private void Update() {
        if(Input.GetKeyUp(KeyCode.M))
        {
            SavePlayer();

            Debug.Log("Data Saved");
        }
        if(Input.GetKeyUp(KeyCode.N))
        {
            LoadPlayer();

            
        }
    }

    public void SavePlayer() //для кнопки сохранить
    {
        SaveSystem.SavePlayer(this);
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


}
