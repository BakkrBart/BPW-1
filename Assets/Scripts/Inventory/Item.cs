using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int itemID;
    public int itemType;

    public string name;

    public GameObject weaponObject;

    public float damage;
    public float fireRate;
    public float range;
    public float reloadSpeed;

    public int maxAmmo;
}
