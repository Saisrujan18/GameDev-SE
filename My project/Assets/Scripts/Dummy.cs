using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Dummy : MonoBehaviour
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


    private Vector2 movement;
    public Animator anim;
    public float moveSpeed;
    public Rigidbody2D rb;
    public PhotonView view;
    // Start is called before the first frame update

    void Awake()
    {
        if( view.IsMine )
        {
            Debug.Log("Awake called");
            playerCamera.SetActive(true);
            canvas.SetActive(true);
            InteractorCanvas.worldCamera = playerCam;
        }
    }
    void Start()
    {
        Debug.Log("Called Start"); 
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Called update"); 
        if( view.IsMine )
        {
            MovementInput();
        }
    }
    
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
    
    void FixedUpdate()
    {
        if( view.IsMine )
        {
            setAnimation();
            rb.velocity = movement * moveSpeed; 
        }
    }
    
    void MovementInput(){
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");
        movement = new Vector2(mx, my).normalized;
    }
}
