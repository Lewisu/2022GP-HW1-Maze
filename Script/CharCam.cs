using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharCam : MonoBehaviour
{
    public float smooth = 3f;     
    Transform standardPos;
    // Start is called before the first frame update
    void Start()
    {
        standardPos = GameObject.Find("CamPos").transform;
        transform.position = standardPos.position;
        transform.forward = standardPos.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = standardPos.position;
        transform.forward = standardPos.forward;
    }
}
