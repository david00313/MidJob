using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EnemyScript : MonoBehaviour
{
    private int HP = 100;
    public Slider healthBar;
    private Animator _animator;
    Rigidbody rb;


    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }
        private void Start() {
            _animator = GetComponent<Animator>();
    }

    void Update()
    {
        healthBar.value = HP;
        _animator.SetBool("IsHitting", false);

    }

    public void TakeDamage(int damageAmount)
    {   
        HP -= damageAmount;
        _animator.SetBool("IsHitting", true);
        Debug.Log("Am primit damage"+ damageAmount);
        if(HP <= 0)
        {
            WinScript.enemyCount--;
            _animator.SetBool("IsDying", true);
            GetComponent<EnemyFollow>().enabled = false;
            GetComponent<Collider>().enabled = false;
            StartCoroutine(EnemyDied());
        }
        
    }
    public IEnumerator EnemyDied(){
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other) {
            if (other.gameObject.tag == "Player"){
            Debug.Log("Collision Enemy");
            _animator.SetBool("IsAttacking", true);

        }
}
}
