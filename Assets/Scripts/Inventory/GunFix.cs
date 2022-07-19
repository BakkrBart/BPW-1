using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFix : MonoBehaviour
{
    Gun gunMain;
    Gun gunSecond;

    public GameObject MainGun;
    public GameObject SecondGun;
    // Start is called before the first frame update
    void Start()
    {
        gunMain = MainGun.GetComponent<Gun>();
        gunSecond = SecondGun.GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MainGun.activeInHierarchy == true)
        {
            gunMain.enabled = true;

        }
        if (MainGun.activeInHierarchy == false)
        {
            gunMain.enabled = false;
        }

        if (SecondGun.activeInHierarchy == true)
        {
            gunSecond.enabled = true;

        }
        if (SecondGun.activeInHierarchy == false)
        {
            gunSecond.enabled = false;
        }
    }
}
