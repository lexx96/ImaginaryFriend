using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject Player;
    public bool isKeyboardOn = true;
    public bool isDead = false;

    public AudioClip GrassStep;
    public AudioClip ConcreteStep;
    public AudioClip MetalStep;
    public AudioClip StairStep;
    public AudioClip LadderStep;

    [Header("Matchsticks")]
    public GameObject MatchStick;
    public GameObject handPosition;
    public GameObject backPosition;

    [Header("Movement")]
    public float player_Movement_Speed = 5f;
    public float player_Max_MovementSpeed = 20f;
    public float player_Rotation_Speed = 50f;
    public float player_Rotation_Damping = 2f;
    public float player_ClimbSpeed = 0.75f;

    [Header("Animation / Ladder / Stair")]
    private float h = 0.0f;
    private float v = 0.0f;
    public bool OnLadder = false;
    public bool OnStair = false;
    public bool OnStairDown = false;
    public GameObject InteractUI2;

    public AudioSource player_audiosource;

    #region AutoFill
    [Header("Autofilled")]
    private Animator anim;
    private Rigidbody rb;
    private CircuitManager circuitManager;
    private KillTrigger killTrigger;
    #endregion

    #region Start & Awake
    void Start()
    {
        circuitManager = GameObject.Find("CircuitManager").GetComponent<CircuitManager>();
        rb = GetComponent<Rigidbody>();
        Player = gameObject;
        anim = GetComponent<Animator>();

        InteractUI2.SetActive(false);
        UseGrassStep();
    }
    #endregion

    void Update()
    {
        KeyboardCtrls();

        #region Check Stairs
        RaycastHit HitStair;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out HitStair, 2f))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * HitStair.distance, Color.blue);
            if (HitStair.collider.name == "StairsUpCol")
            {
                OnStair = true;
                OnStairDown = false;
            }
            else if (HitStair.collider.name == "StairsDownCol")
            {
                OnStairDown = true;
            }
        }
        else
        {
            OnStair = false;
            OnStairDown = false;
        }


        if (OnStair)
        {
            UseStair();
            //isKeyboardOn = false;
            BagStick();
            if (Input.GetKey(KeyCode.W) && !OnStairDown)
            {
                if (!player_audiosource.isPlaying)
                {
                    player_audiosource.Play();
                }

                player_Movement_Speed = 2;
                anim.speed = 1;
                anim.SetBool("StairUp", true);
                anim.SetBool("StairDown", false);
            }
            else if (Input.GetKey(KeyCode.S) && OnStairDown)
            {
                if (!player_audiosource.isPlaying)
                {
                    player_audiosource.Play();
                }

                player_Movement_Speed = 2;
                anim.speed = 1;
                anim.SetBool("StairDown", true);
                anim.SetBool("StairUp", false);
            }
            else
            {
                if (!Input.GetKey(KeyCode.W) && anim.GetCurrentAnimatorStateInfo(0).IsName("StairsUp"))
                {
                    player_audiosource.Stop();
                    anim.speed = 0;
                }
                else if (!Input.GetKey(KeyCode.S) && anim.GetCurrentAnimatorStateInfo(0).IsName("StairsDown"))
                {
                    player_audiosource.Stop();
                    anim.speed = 0;
                }
            }
        }
        else if (!OnStair && !OnStairDown)
        {
            player_Movement_Speed = player_Max_MovementSpeed;

            anim.SetBool("StairUp", false);
            anim.SetBool("StairDown", false);
        }
        #endregion

        #region Check Ladder

        #region Checking If Ladder is On
        RaycastHit LadderForwardHit;
        if (Physics.Raycast(transform.position + new Vector3(0, 1, 0), transform.TransformDirection(Vector3.forward), out LadderForwardHit, 1.4f)) 
        {
            if (!OnLadder && LadderForwardHit.collider.name == "L_Ladder" || !OnLadder && LadderForwardHit.collider.name == "R_Ladder")
            {
                InteractUI2.SetActive(true);
            }
            else
            {
                InteractUI2.SetActive(false);
            }

            if (!OnLadder && Input.GetKeyDown(KeyCode.E))
            {
                if (LadderForwardHit.collider.name == "L_Ladder")
                {
                    InteractUI2.SetActive(false);
                    Player.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
                    OnLadder = true;
                }
                else if (LadderForwardHit.collider.name == "R_Ladder")
                {
                    InteractUI2.SetActive(false);
                    Player.gameObject.transform.localEulerAngles = new Vector3(0, -180, 0);
                    OnLadder = true;
                }
            }
        }
        else
        {
            InteractUI2.SetActive(false);
        }
        #endregion

        RaycastHit hit1;
        RaycastHit hit2;
        if (OnLadder)
        {
            UseLadder();
            isKeyboardOn = false;
            rb.useGravity = false;
            rb.isKinematic = true;

            if (!anim.GetBool("Up") && !anim.GetBool("Down"))
            {
                anim.SetBool("Up", true);
            }

            BagStick();

            #region CheckTop
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up), out hit2, 3f))
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * 3f, Color.blue);
                //print(hit2.collider.name);
                if (hit2.collider.name == "Top_Checker")
                {
                    //print("HitTop");
                    circuitManager.InteractUI.SetActive(false);

                    OnLadder = false;
                }
            }
            #endregion

            #region CheckBtm
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit1, .1f))
            {
                if (hit1.collider.name == "Btm_Checker")
                {
                    circuitManager.InteractUI.SetActive(false);

                    OnLadder = false;
                }
            }
            #endregion

            if (Input.GetKey(KeyCode.W))
            {
                if (!player_audiosource.isPlaying)
                {
                    player_audiosource.Play();
                }

                anim.speed = 1;
                anim.SetBool("Up", true);
                anim.SetBool("Down", false);
                transform.position += new Vector3(0, Time.deltaTime * player_ClimbSpeed, 0);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                if (!player_audiosource.isPlaying)
                {
                    player_audiosource.Play();
                }

                anim.speed = 1;
                anim.SetBool("Down", true);
                anim.SetBool("Up", false);
                transform.position -= new Vector3(0, Time.deltaTime * player_ClimbSpeed, 0);
            }
            else
            {
                if (!Input.GetKey(KeyCode.W) && anim.GetCurrentAnimatorStateInfo(0).IsName("ClimbUp"))
                {
                    player_audiosource.Stop();
                    anim.speed = 0;
                }
                else if (!Input.GetKey(KeyCode.S) && anim.GetCurrentAnimatorStateInfo(0).IsName("ClimbDown"))
                {
                    player_audiosource.Stop();
                    anim.speed = 0;
                }
            }
        }
        else
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            anim.SetBool("Down", false);
            anim.SetBool("Up", false);
        }
        #endregion

        #region Not On Ladder
        if (!OnLadder && !OnStair && !isDead)
        {
            anim.speed = 1;
            isKeyboardOn = true;
            HandStick();

            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                isKeyboardOn = false;
            }
            else
            {
                isKeyboardOn = true;
            }
        }
        #endregion
    }

    public void UseGrassStep()
    {
        player_audiosource.clip = GrassStep;
        player_audiosource.pitch = 1.2f;
        player_audiosource.volume = 1f;
    }

    public void UseConcreteStep()
    {
        player_audiosource.clip = ConcreteStep;
        player_audiosource.pitch = 1.4f;
        player_audiosource.volume = 0.1f;
    }

    public void UseMetalStep()
    {
        player_audiosource.clip = MetalStep;
        player_audiosource.pitch = 1.4f;
        player_audiosource.volume = 1f;
    }

    public void UseStair()
    {
        player_audiosource.clip = StairStep;
        player_audiosource.pitch = 1f;
        player_audiosource.volume = 1f;
    }

    public void UseLadder()
    {
        player_audiosource.clip = LadderStep;
        player_audiosource.pitch = 1f;
        player_audiosource.volume = 1f;
    }

    public void UseRunGrassStep()
    {
        player_audiosource.clip = GrassStep;
        player_audiosource.pitch = 2.25f;
        player_audiosource.volume = 1f;
    }

    public void UseRunMetalStep()
    {
        player_audiosource.clip = MetalStep;
        player_audiosource.pitch = 2.5f;
        player_audiosource.volume = 1f;
    }

    #region Keyboard Controls Method
    public void KeyboardCtrls()
    {
        if (isKeyboardOn)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            anim.SetFloat("H", h);
            anim.SetFloat("V", v);

            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * Time.deltaTime * player_Movement_Speed;
                //transform.position += Vector3.forward * Time.deltaTime * player_Movement_Speed;

                //if (transform.forward != new Vector3(0, 0, 1))
                //{
                //    transform.forward += new Vector3(0, 0, Time.deltaTime * player_Rotation_Speed * player_Rotation_Damping);
                //}
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.forward * Time.deltaTime * player_Movement_Speed;
                //transform.position += -Vector3.forward * Time.deltaTime * player_Movement_Speed;

                //if (transform.forward != new Vector3(0, 0, -1))
                //{
                //    transform.forward -= new Vector3(0, 0, Time.deltaTime * player_Rotation_Speed * player_Rotation_Damping);
                //}
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -Time.deltaTime * player_Rotation_Speed, 0);
                //transform.position += -Vector3.right * Time.deltaTime * player_Movement_Speed;

                //if (transform.forward != new Vector3(-1, 0, 0))
                //{
                //    transform.forward -= new Vector3(Time.deltaTime * player_Rotation_Speed * player_Rotation_Damping, 0, 0);
                //}
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, Time.deltaTime * player_Rotation_Speed, 0);
                //transform.position += Vector3.right * Time.deltaTime * player_Movement_Speed;

                //if (transform.forward != new Vector3(1, 0, 0))
                //{
                //    transform.forward += new Vector3(Time.deltaTime * player_Rotation_Speed * player_Rotation_Damping, 0, 0);
                //}
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                if (!player_audiosource.isPlaying)
                {
                    player_audiosource.Play();
                }
            }
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                if (player_audiosource.isPlaying && !OnStair && !OnLadder)
                {
                    player_audiosource.Stop();
                }
            }
        }
        else if (!isKeyboardOn)
        {
            anim.SetFloat("H", 0);
            anim.SetFloat("V", 0);
        }
    }
    #endregion

    #region MatchStick Method
    public void BagStick()
    {
        MatchStick.transform.parent = backPosition.transform;
        MatchStick.transform.position = backPosition.transform.position;
        MatchStick.transform.rotation = backPosition.transform.rotation;
    }

    public void HandStick()
    {
        MatchStick.transform.parent = handPosition.transform;
        MatchStick.transform.position = handPosition.transform.position;
        MatchStick.transform.rotation = handPosition.transform.rotation;
    }
    #endregion
}
