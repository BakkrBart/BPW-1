using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int[] inventory;
    public GameObject[] weaponSlot;

    private void Start()
    {
        inventory = new int[2];
        weaponSlot = new GameObject[2];

        weaponSlot[0] = GameObject.FindGameObjectWithTag("Primary");        
        weaponSlot[1] = GameObject.FindGameObjectWithTag("Secondary");        
    }
}
