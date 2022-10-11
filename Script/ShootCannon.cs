using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCannon : MonoBehaviour
{
    [SerializeField] CannonTrigger cannonTrigger1;
    [SerializeField] CannonTrigger cannonTrigger2;
    [SerializeField] CannonTrigger cannonTrigger3;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletSpeed = 150.0f;
    [SerializeField] float bulletZDirection = -10.0f;
    [SerializeField] float bulletXDirection = 0.0f;
    GameObject prefab;
    AudioSource shot;

    void Start()
    {
        shot = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cannonTrigger1.shoot && cannonTrigger1.inTrigger && !cannonTrigger2.inTrigger && !cannonTrigger3.inTrigger) StartCoroutine("Bombard");
        else if (!cannonTrigger1.inTrigger || cannonTrigger2.inTrigger || cannonTrigger3.inTrigger)
        {
            StopCoroutine("Bombard");
            shot.enabled = false;
        }
    }

    IEnumerator Bombard()
    {
        prefab = Instantiate(bullet, transform.position, Quaternion.identity);

        if (cannonTrigger1.inTrigger)
        {
            //print(cannonTrigger1.inTrigger);
            cannonTrigger1.shoot = false;
            shot.enabled = true;
            prefab.GetComponent<Rigidbody>().AddForce(new Vector3(bulletXDirection, 0.0f, bulletZDirection) * bulletSpeed, ForceMode.VelocityChange);
            yield return new WaitForSeconds(4);
            shot.enabled = false;
            cannonTrigger1.shoot = true;
        }
    }
}
