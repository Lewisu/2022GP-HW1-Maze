using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveableDoorHint : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI texts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Unity Chan"))
        {
            texts.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Unity Chan"))
        {
            texts.enabled = false;
        }
    }
}
