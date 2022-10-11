using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButton : MonoBehaviour
{
    [SerializeField] GameObject cannon1;
    [SerializeField] GameObject cannon2;
    [SerializeField] GameObject area1;
    [SerializeField] GameObject area2;
    public bool clicked = false;
    public Camera m_Cam;
    bool first = true;
    Animator m_Animator;
    AudioSource clicky;
    RaycastHit m_hitObj;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        clicky = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Input.mousePosition;
        Ray mRay = m_Cam.ScreenPointToRay(pos);
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(mRay, out m_hitObj))
            {
                //print(m_hitObj.collider.gameObject.tag);
                if (first && m_hitObj.collider.gameObject.tag == "Button")
                {
                    first = false;
                    clicked = true;
                    clicky.enabled = true;
                    cannon1.SetActive(true);
                    cannon2.SetActive(true);
                    area1.SetActive(true);
                    area2.SetActive(true);

                    m_Animator.SetBool("Clicked", true);
                    print("Clicked");
                }
            }
        }

        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("WallTrigger"))
        {
            m_Animator.SetBool("Clicked", false);
        }
    }

}
