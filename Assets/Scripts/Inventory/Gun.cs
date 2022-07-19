using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    GameObject gameController;
    public GameObject nozzle;
    public GameObject inpactEffect;
    
    ItemDatabase database;
    
    Camera mainCam;

    [SerializeField]
    int currAmmo;
    int maxAmmo;
    int id;

    float damage;
    float range;
    float reloadSpeed;
    float nextFire;
    float fireRate;

    bool reloading = false;
    private void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        database = gameController.GetComponent<ItemDatabase>();

        mainCam = Camera.main;

        id = GetComponent<ItemID>().itemID;

        maxAmmo = database.weapons[id].maxAmmo;
        currAmmo = maxAmmo;
        range = database.weapons[id].range;
        reloadSpeed = database.weapons[id].reloadSpeed;
        damage = database.weapons[id].damage;
        fireRate = database.weapons[id].fireRate;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && currAmmo != maxAmmo && !reloading)
        {
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetButton("Fire1") && Time.time >= nextFire && !reloading && currAmmo > 0 && gameObject.layer == 0)
        {
            nextFire = Time.time + 1f / fireRate;
            Shoot();
            nozzle.SetActive(true);
            Invoke("Off", 0.1f);
        }
    }

    void Off()
    {
        nozzle.SetActive(false);
    }

    void Shoot()
    {
        currAmmo--;

        Vector3 rayOrigin = mainCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        RaycastHit hit;
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range))
        {
            if (hit.transform.tag == "Enemy")
            {
                CharacterStats enemyStats = hit.transform.GetComponent<CharacterStats>();
                enemyStats.TakeDamage(damage);
            }
            GameObject impactObject = Instantiate(inpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactObject, 1f);
        }
    }

    IEnumerator Reload()
    {
        reloading = true;
        yield return new WaitForSeconds(reloadSpeed);
        currAmmo = maxAmmo;
        reloading = false;
    }
}
