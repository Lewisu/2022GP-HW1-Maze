using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playerController : MonoBehaviour
{
    public int HP = 2;
    [SerializeField] Animator _anim;
    [SerializeField] Rigidbody _rb;
    [SerializeField] CapsuleCollider _col;
    [SerializeField] TextMeshProUGUI texts;
    [SerializeField] GameObject bar1;
    [SerializeField] GameObject bar2;


    [SerializeField] float animSpeed = 1.5f;
    [SerializeField] float forwardSpeed = 110.0f;
    [SerializeField] float backwardSpeed = 80.0f;
    [SerializeField] float rotateSpeed = 2.0f;

    Vector3 velocity;
    AudioSource footStep;
    AudioSource getHit;
    AudioSource [] audios;
    //List<AudioSource> audios = new List<AudioSource>();
    bool instructionToggle = true;
    bool helpToggle = true;
    bool isDead = false;

    void Start()
    {
        audios = GetComponents<AudioSource>();
        //GetComponents(audios);

        footStep = audios[0];
        getHit = audios[1];
    }
    void Update()
    {
        if (Input.GetKeyDown("i")) instructionToggle = !instructionToggle;
        if (Input.GetKeyDown("h")) helpToggle = !helpToggle;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float h;
        float v;

        if (!isDead)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
        }
        else
        {
            h = 0.0f;
            v = 0.0f;
        }

        _anim.SetFloat("Speed", v);
        _anim.SetFloat("Direction", h);
        _anim.speed = animSpeed;
        _rb.useGravity = true;

        
        velocity = new Vector3(0, 0, v);
        velocity = transform.TransformDirection(velocity);

        if (v > 0.1)
        {
            velocity *= forwardSpeed;
            footStep.enabled = true;
            footStep.pitch = 1.0f;
        }
        else if (v < -0.1)
        {
            velocity *= backwardSpeed;
            footStep.enabled = true;
            footStep.pitch = 0.6f;
        }
        else
        {
            footStep.enabled = false;
        }

        transform.localPosition += velocity * Time.fixedDeltaTime;

        transform.Rotate(0, h * rotateSpeed, 0);
    }

    void OnGUI()
    {
        if (instructionToggle)
        {
            GUI.Box(new Rect(Screen.width - 260, 10, 250, 150), "Instructions");
            GUI.Label(new Rect(Screen.width - 245, 30, 250, 30), "W / Up Arrow: Move Forward");
            GUI.Label(new Rect(Screen.width - 245, 50, 250, 30), "S / Down Arrow: Move Backward");
            GUI.Label(new Rect(Screen.width - 245, 70, 250, 30), "A / Left Arrow: Turn Left");
            GUI.Label(new Rect(Screen.width - 245, 90, 250, 30), "D / Right Arrow: Turn Right");
            GUI.Label(new Rect(Screen.width - 245, 110, 250, 30), "Hit M : Toggle map");
            GUI.Label(new Rect(Screen.width - 125, 110, 250, 30), "Hit H : Toggle Help");
            GUI.Label(new Rect(Screen.width - 245, 130, 250, 30), "Hit I : Toggle Instruction");
        }

        if (helpToggle)
        {
            GUI.Box(new Rect(Screen.width - 360, 180, 350, 150), "Help");
            GUI.Label(new Rect(Screen.width - 345, 200, 350, 30), "Welcome to the game!");
            GUI.Label(new Rect(Screen.width - 345, 220, 350, 30), "There're several mechanisms (Puzzle & Trap) here");
            GUI.Label(new Rect(Screen.width - 345, 240, 350, 30), "They can be interacted by using mouse");
            GUI.Label(new Rect(Screen.width - 345, 260, 350, 30), "Some of them is a trigger based");
            GUI.Label(new Rect(Screen.width - 345, 280, 350, 30), "Small hint: Find Switches on wall and follow the path");
            GUI.Label(new Rect(Screen.width - 345, 300, 350, 30), "Hope you can escape the maze!");
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        //print("collided");
        if (collision.gameObject.CompareTag("Trap"))
        {
            getHit.enabled = false;
            getHit.enabled = true;

            if (HP == 1) bar2.SetActive(false);
            print("You Got Hit");
            if (HP <= 0)
            {
                isDead = true;
                bar1.SetActive(false);
                bar2.SetActive(false);
                StartCoroutine(RestartScene());
            }
        }
    }

    IEnumerator RestartScene()
    {
        print("You Died");
        forwardSpeed = 0.0f;
        backwardSpeed = 0.0f;
        rotateSpeed = 0.0f;
        animSpeed = 0.0f;

        texts.enabled = true;
        yield return new WaitForSeconds(2.5f);

        Scene thisScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(thisScene.name);
    }
}
