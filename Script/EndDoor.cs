using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDoor : MonoBehaviour
{
    PressurePlate pressurePlate;
    [SerializeField] GameObject plate;
    [SerializeField] GameObject area;
    Animator m_Animator;
    AudioSource slide;
    // Start is called before the first frame update
    void Start()
    {
        pressurePlate = plate.GetComponent<PressurePlate>();
        m_Animator = gameObject.GetComponent<Animator>();
        slide = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pressurePlate.pressed)
        {
            m_Animator.SetBool("Pressed", true);
            slide.enabled = true;
        }
        else m_Animator.SetBool("Pressed", false);

        if (transform.position.y < -85.0f)
        {
            Destroy(area);
            Destroy(gameObject);
        }
    }

}
