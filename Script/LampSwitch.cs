using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampSwitch : MonoBehaviour
{
    [SerializeField] GameObject lamp;
    public bool on = false;
    public Camera m_Cam;
    RaycastHit m_hitObj;
    Light set;
    Component[] audios;
    AudioSource a;
    AudioSource b;

    // Start is called before the first frame update
    void Start()
    {
        set = lamp.GetComponent<Light>();
        audios = GetComponents(typeof(AudioSource));
        int i = 0;
        foreach (AudioSource audio in audios)
        {
            if (i == 0) a = audio;
            else if (i == 1) b = audio;

            i += 1;
        }
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
                if (m_hitObj.collider.gameObject.name == name)
                {
                    if (on)
                    {
                        set.intensity = 0.0f;
                        a.enabled = false;
                        b.enabled = true;
                    }
                    else if (!on)
                    {
                        set.intensity = 10.0f;
                        a.enabled = true;
                        b.enabled = false;
                    }
                    on = !on;
                }
            }
        }
    }
}
