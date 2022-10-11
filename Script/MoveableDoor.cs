using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableDoor : MonoBehaviour
{
    WallButton wallButton;
    [SerializeField] GameObject button;
    [SerializeField] GameObject area;
    Animator m_Animator;
    AudioSource slide;
    // Start is called before the first frame update
    void Start()
    {
        wallButton = button.GetComponent<WallButton>();
        m_Animator = gameObject.GetComponent<Animator>();
        slide = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wallButton.clicked)
        {
            m_Animator.SetBool("Clicked", true);
            slide.enabled = true;
        }

        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("MoveableDoor"))
        {
            m_Animator.SetBool("Clicked", false);
        }

        if (transform.position.y < -85.0f)
        {
            Destroy(area);
            Destroy(gameObject);
        }
    }
}
