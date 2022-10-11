using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI texts;
    [SerializeField] GameObject particle1;
    [SerializeField] GameObject particle2;
    [SerializeField] GameObject closeDoor;
    [SerializeField] GameObject obj1;
    [SerializeField] GameObject obj2;
    [SerializeField] GameObject obj3;
    [SerializeField] GameObject obj4;
    bool first = true;
    bool after = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Unity Chan") && first)
        {
            first = false;
            texts.enabled = true;
            particle1.SetActive(true);
            particle2.SetActive(true);
            closeDoor.SetActive(true);
            closeDoor.SetActive(true);
            gameObject.GetComponent<AudioSource>().enabled = true;
            closeDoor.GetComponent<Animator>().SetBool("Close", true);
            closeDoor.GetComponent<AudioSource>().enabled = true;

            Destroy(obj1);
            Destroy(obj2);
            Destroy(obj3);
            Destroy(obj4);
        }
    }

    void Update()
    {
        if (!first && closeDoor.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("EndDoorClose"))
        {
            closeDoor.GetComponent<Animator>().SetBool("Close", false);
            after = true;
        }
        else if (after && closeDoor.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("New State"))
        {
            closeDoor.GetComponent<AudioSource>().enabled = false;
        }
    }
}
