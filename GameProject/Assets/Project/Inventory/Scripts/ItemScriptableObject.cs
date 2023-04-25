using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType{Default, Food, Weapon, Instrument}

public class ItemScriptableObject : ScriptableObject 
{
    [Header("General Characteristics")]
    public ItemType itemType;
    public string itemName;
    public GameObject itemPrefab;
    public int maximumAmount;
    public string itemDescription;
    public Sprite icon;
    public bool isConsumeable;
    [Header("Consumable Characteristics")]
    public float changeHealth;
    public float changeHunger;
    public float changeWater;

    



}

