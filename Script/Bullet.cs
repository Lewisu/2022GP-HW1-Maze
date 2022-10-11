using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int health;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3);
        health = GameObject.Find("unitychan").GetComponent<playerController>().HP;
        //print(health);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Unity Chan"))
        {
            Destroy(gameObject);
            health = health - 1;
            GameObject.Find("unitychan").GetComponent<playerController>().HP = health;
        }
        if (collision.collider.name == "Inner Long Wall" || collision.collider.name == "Outer Wall Full Back")
        {
            Destroy(gameObject);
        }
    }
}
