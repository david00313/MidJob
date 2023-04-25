using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public GameObject invetoryOpen;
    public float jumpForce = 5f;
    public float moveSpeed = 2f;
    public float runMoveSpeed = 3f;

    private Rigidbody rb;
    private bool isJumping = false;
//Audio
    private AudioSource _audioSource;
//Animation
    public static Animator _animator; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        _audioSource = GetComponent<AudioSource>();
        _audioSource.Stop();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _animator = GetComponent<Animator>();
    }

    void Update()
    {   

        Jump();
        Move();
        FiringAnim();

    }

   




    private void FiringAnim(){
        if (Input.GetButton("Fire1") && invetoryOpen.GetComponent<InventoryManager>().isOpened == false )
            {
                _animator.SetBool("IsFiring", true);
            }
            else{
                    _animator.SetBool("IsFiring", false);
            }
    }

    private void Jump(){
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
            _animator.SetBool("IsJumping", true);
        }
        if (Input.GetKeyUp(KeyCode.Space)){
            _animator.SetBool("IsJumping", false);
        }
    }

    private void Move(){
        {   

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += transform.forward * runMoveSpeed * Time.deltaTime;
                _animator.SetBool("IsRunning", true);
            }

            if (Input.GetKey(KeyCode.W)){
                transform.localPosition += transform.forward * moveSpeed * Time.deltaTime;
                _animator.SetBool("IsWalking", true);
                }

            if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
            {
                _audioSource.pitch = 1.8f;
                _audioSource.Play();
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _audioSource.pitch = 0.9f;
                _audioSource.Stop();
            }

            if (Input.GetKeyDown(KeyCode.W)){
                _audioSource.Play();
            }
            if (Input.GetKeyDown(KeyCode.S)){
                _audioSource.pitch = 1.5f;
                _audioSource.Play();

            }
            if (Input.GetKeyDown(KeyCode.A)){
                _audioSource.pitch = 1.2f;
                _audioSource.Play();
            }
            if (Input.GetKeyDown(KeyCode.D)){
                _audioSource.pitch = 1.2f;
                _audioSource.Play();
            }

            if (Input.GetKeyUp(KeyCode.W)){
            _audioSource.Stop();

            _animator.SetBool("IsWalking", false);
            _animator.SetBool("IsRunning", false);
            }

            if (Input.GetKeyUp(KeyCode.W)){
            _audioSource.Stop();
            }
            if (Input.GetKeyUp(KeyCode.S)){
            _audioSource.pitch = 0.9f;
            _audioSource.Stop();
            }
            if (Input.GetKeyUp(KeyCode.A)){
            _audioSource.pitch = 0.9f;
            _audioSource.Stop();
            }
            if (Input.GetKeyUp(KeyCode.D)){
            _audioSource.pitch = 0.9f;
            _audioSource.Stop();
            }

            if (Input.GetKey(KeyCode.S))
            {
                _animator.SetBool("IsRunningBack", true);
                transform.localPosition += -transform.forward * moveSpeed * Time.deltaTime;
            }
            else{
            _animator.SetBool("IsRunningBack", false);
            }

            if (Input.GetKey(KeyCode.D))
            {
                _animator.SetBool("IsRunningRight", true);
                transform.localPosition += transform.right * moveSpeed * Time.deltaTime;
            }else{
                _animator.SetBool("IsRunningRight", false);
            }

            if (Input.GetKey(KeyCode.A))
            {
                _animator.SetBool("IsRunningLeft", true);
                transform.localPosition += -transform.right * moveSpeed * Time.deltaTime;
            }else {
                _animator.SetBool("IsRunningLeft", false);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

}
