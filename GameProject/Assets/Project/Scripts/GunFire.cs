using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GunFire : MonoBehaviour
{
    public GameObject invetoryOpen;
    public GameObject hitEffect;
    public Camera _cam;
    public int damageAmount = 21;
    public float fireRate = 1;
    public float range = 25;
    public float nextFire;
    //ammo
    [SerializeField] Text _usingAmmo;//scripturile stanga
    [SerializeField] Text _totalAmmo;//scripturile dreapta
    public int usingAmmo;
    public int totalAmmo;

    //Audio
    private AudioSource _audiosource;

    private void Awake() {
        usingAmmo = 10;
        totalAmmo = 10;
        _audiosource = GetComponent<AudioSource>();
        _audiosource.Stop();
    }

        void Update() {
        _usingAmmo.text = usingAmmo.ToString();
        _totalAmmo.text = totalAmmo.ToString();
        WeaponFire();
        if(Input.GetKeyUp(KeyCode.M))
        {
            SaveGun();
            Debug.Log("Data gun Saved");
        }
        if(Input.GetKeyUp(KeyCode.N))
        {
            LoadGun();
        }
        

        // if(Input.GetKeyUp(KeyCode.Escape)){
        //     SaveGun();
        //     SceneManager.LoadScene(0);
        // }
    }
    

    public void SaveGun() //для кнопки сохранить
    {
        SaveSystem.SaveGun(this);
    }

    public void LoadGun()
    {
        GunData data = SaveSystem.LoadGun();
        totalAmmo = data.totalAmmo;
        usingAmmo = data.usingAmmo;

    }

        void WeaponFire()
    {   
        if ( invetoryOpen.GetComponent<InventoryManager>().isOpened == false)
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            { 
                Debug.Log("piu");
                if(usingAmmo == 0 && totalAmmo == 0)
                {
                    totalAmmo = 0;
                    usingAmmo = 0;
                }

                else if(usingAmmo > 0 && totalAmmo >= 0)
                {
                    usingAmmo--;
                    nextFire = Time.time + 1f / fireRate;
                    Shoot();
                    _audiosource.Play();
                   

                }else if (usingAmmo == 0 && totalAmmo >= 0)
                {
                    totalAmmo -= 10;
                    usingAmmo = 10;
                }
            }
        }
    }
    

    void Shoot()
    {
         
        RaycastHit hit;

        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, range))
        {
           GetComponent<AudioSource>().enabled = true;

            
                  
            if(hit.rigidbody !=null){
                 Debug.Log("Shoot");
                hit.rigidbody.AddForce(-hit.normal);
                GameObject impact = Instantiate(hitEffect, hit.point , Quaternion.LookRotation(hit.normal));
                Destroy(impact, 2f);
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<EnemyScript>().TakeDamage(damageAmount);
                
            }
            

        
        }
    }
}
