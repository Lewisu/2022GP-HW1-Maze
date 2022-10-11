using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTrigger : MonoBehaviour
{
    public bool shoot = false;
    public bool inTrigger = false;

    // Update is called once per frame
    void Update()
    {
        //if (!inTrigger) shoot = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Unity Chan") && !shoot)
        {
            inTrigger = true;
            shoot = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Unity Chan"))
        {
            inTrigger = false;
            shoot = false;
        }
    }

}
