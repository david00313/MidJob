using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOnColl : MonoBehaviour
{
    public static Animator _animator; 
    public Transform _camera1;
    public Transform _camera2;
    private EnemyFollow enemyFollow;


    private void Start() {
        _animator = GetComponent<Animator>();
        
    }


private void OnCollisionEnter(Collision other) {
            if (other.gameObject.tag == "Enemy"){
            Debug.Log("Collision Enemy");
            Indicators.healthAmount -= 15;
            }
            if(Indicators.healthAmount == 0){
            _animator.SetBool("IsDead", true);
            Destroy(GetComponent<PlayerController>());
            Destroy(GetComponent<Rotate>());          
            _camera1.gameObject.SetActive(false);
            _camera2.gameObject.SetActive(true);
            gameObject.tag = "Died";
            StartCoroutine(DiedDelay());
        }
            
}
private IEnumerator DiedDelay(){
    yield return new WaitForSeconds(5f);
    _camera1.gameObject.SetActive(true);
    _camera2.gameObject.SetActive(false);
    SceneManager.LoadScene(3);
    Destroy(gameObject);
}


}
