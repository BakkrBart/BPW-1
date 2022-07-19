using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPickup : MonoBehaviour
{
    public float pickupRange = 2f;

    int pickupLayerMask;

    GameObject GameController;

    GameObject primaryWeapon, secondaryWeapon;

    [SerializeField] Image PickupPopup;

    ItemDatabase database;
    PlayerInventory inventory;

    Camera cam;

    private void Start()
    {
        GameController = GameObject.FindGameObjectWithTag("GameController");
        database = GameController.GetComponent<ItemDatabase>();
        inventory = GameController.GetComponent<PlayerInventory>();

        cam = GetComponent<Camera> ();

        pickupLayerMask = LayerMask.GetMask("Pickup");

        DisablePickup();
    }

    private void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickupRange, pickupLayerMask))
        {
            EnablePickup();
            if(Input.GetKeyDown (KeyCode.E))
            {
                int id = hit.transform.GetComponent<ItemID> ().itemID;
                if(database.weapons[id].itemType == 1)
                {
                    if(inventory.inventory[0] == id)
                    {
                        Debug.Log("Die heb je al poepiehead");
                    }
                    else if (inventory.inventory[0] == 0)
                    {
                        inventory.inventory[0] = id;
                        primaryWeapon = hit.transform.gameObject; //temp
                        primaryWeapon.transform.SetParent(inventory.weaponSlot[0].transform);
                        primaryWeapon.transform.localPosition = new Vector3(0, 0, 0);
                        primaryWeapon.transform.localRotation = Quaternion.Euler(0, 0, 0); //temp
                        primaryWeapon.layer = 0;
                    }
                    else if (inventory.inventory[0] != id)
                    {
                        Destroy(primaryWeapon.gameObject);
                        
                        inventory.inventory[0] = id;
                        primaryWeapon = hit.transform.gameObject; //temp
                        primaryWeapon.transform.SetParent(inventory.weaponSlot[0].transform);
                        primaryWeapon.transform.localPosition = new Vector3(0,0,0); //temp
                        primaryWeapon.transform.localRotation = Quaternion.Euler(0,0,0); //temp
                        primaryWeapon.layer = 0;
                    }
                } 
                if(database.weapons[id].itemType == 2)
                {
                    if(inventory.inventory[1] == id)
                    {
                        Debug.Log("Die heb je al poepiehead");
                    }
                    else if (inventory.inventory[1] == 0)
                    {
                        inventory.inventory[1] = id;
                        secondaryWeapon = hit.transform.gameObject; //temp
                        secondaryWeapon.transform.SetParent(inventory.weaponSlot[1].transform);
                        secondaryWeapon.transform.localPosition = new Vector3(0, 0, 0);
                        secondaryWeapon.transform.localRotation = Quaternion.Euler(0, 0, 0); //temp
                        secondaryWeapon.layer = 0;
                    }
                    else if (inventory.inventory[1] != id)
                    {
                        inventory.inventory[0] = id;
                        secondaryWeapon = hit.transform.gameObject; //temp
                        secondaryWeapon.transform.SetParent(inventory.weaponSlot[1].transform);
                        secondaryWeapon.transform.localPosition = new Vector3(0, 0, 0);
                        secondaryWeapon.transform.localRotation = Quaternion.Euler(0, 0, 0); //temp
                        secondaryWeapon.layer = 0;

                        Destroy(hit.transform.gameObject);
                    }
                }
            }
        }
        else
        {
            DisablePickup();
        }
    }

    void EnablePickup()
    {
        PickupPopup.gameObject.SetActive(true);
    }

    void DisablePickup()
    {
        PickupPopup.gameObject.SetActive(false);
    }
}
