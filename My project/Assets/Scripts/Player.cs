using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Player : MonoBehaviour
{
    public EnergyBar energybar;
    public Money money;
    public Bread bread;
    public Apple apple;
    public SanitizerBar sanitizer;
    public MaskBar mask;
    public Canvas InteractorCanvas;
    public GameObject canvas;
    public GameObject playerCamera;
    public Camera playerCam;


    public Animator anim;
    public float moveSpeed;
    public bool maskOn = false, isInfected= false;
    public Button toggleMask;
    public float health;
    public float maxHealth = 100;

    public PhotonView view;

    public Rigidbody2D rb;

    private Vector2 movement;

    /*void Awake()
    {
        if( view.IsMine )
        {
            Debug.Log("Awake called");
            playerCamera.SetActive(true);
            canvas.SetActive(true);
            InteractorCanvas.worldCamera = playerCam;
        }
    } // Start is called before the first frame update
    */
    void Start()
    {
        Debug.Log("Start Called");
        /*
        anim = GetComponent<Animator>();
        health = maxHealth;
        toggleMask = toggleMask.GetComponent<Button>();
		toggleMask.onClick.AddListener(maskBtnClicked);
        */
    }

    // Update is called once per frame
    void Update()
    {
        //if( view.IsMine )
        Debug.Log("Update");
        MovementInput();
    }
    // isWalkingLeft
    // isWalkingRight
    // isWalkingDown
    // isWalkingUop
    void setAnimation(){
        if(movement.x == 0) {
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalkingLeft", false);
        }
        else if(movement.x < 0) {
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalkingLeft", true);
        }
        else if(movement.x > 0){
            anim.SetBool("isWalkingRight", true);
            anim.SetBool("isWalkingLeft", false);
        }
        if(movement.y == 0) {
            anim.SetBool("isWalkingUp", false);
            anim.SetBool("isWalkingDown", false);
        }
        else if(movement.y < 0) {
            anim.SetBool("isWalkingUp", false);
            anim.SetBool("isWalkingDown", true);
        }
        else if(movement.y > 0){
            anim.SetBool("isWalkingUp", true);
            anim.SetBool("isWalkingDown", false);
        }
    }
    void FixedUpdate(){
        setAnimation();
        rb.velocity = movement * moveSpeed; 
    }

    void MovementInput(){
        Debug.Log("Input called");
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");
        movement = new Vector2(mx, my).normalized;
    }

    /*
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.tag == "Player"){
            Player otherPlayer = collision.gameObject.GetComponent<Player>();
            if(otherPlayer.isInfected)
                isInfected = !maskOn;
        }
    }
    void maskBtnClicked(){
        maskOn = !maskOn;
        Debug.Log(maskOn);
    }   
    */
}
