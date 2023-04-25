using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public GameObject[] Slots = new GameObject[3];
    Transform _transform;
    public GameObject _gameObject1;
    public GameObject _gameObject2;
    public GameObject _gameObject3;

    void Start()
    {
        _gameObject1.GetComponent<GunFire>();
        _gameObject2.GetComponent<GunFire>();
        _gameObject3.GetComponent<GunFire>();

    }

    void Update()
    {
        if(Input.GetKeyDown("1"))
        {
            _gameObject1.GetComponent<AudioSource>().enabled = false;
            Equip1();
        }
        if(Input.GetKeyDown("2"))
        {
            _gameObject2.GetComponent<AudioSource>().enabled = false;
            Equip2();
        }
        if(Input.GetKeyDown("3"))
        {
            _gameObject3.GetComponent<AudioSource>().enabled = false;
            Equip3();
        }
    }

    public void Equip1()
    {   
        Debug.Log("1");
        Slots[0].SetActive(true);
        Slots[1].SetActive(false);
        Slots[2].SetActive(false);
    }

    public void Equip2()
    {
        Slots[0].SetActive(false);
        Slots[1].SetActive(true);
        Slots[2].SetActive(false);
        
    }

    public void Equip3()
    {
        Slots[0].SetActive(false);
        Slots[1].SetActive(false);
        Slots[2].SetActive(true);
        
    }
}
