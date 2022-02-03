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
    public SanitizerBar sanitizerBar;
    public MaskBar mask;
    public Canvas InteractorCanvas;
    public GameObject canvas;
    public GameObject playerCamera;
    public Camera playerCam;
    public float timeStart = 60;
    public float punishTime = 5.0f;
    public BuyMaskandSanitizer ms;
    public BuyAppleandBread ab;


    private Vector2 movement;
    public Animator anim;
    public float moveSpeed;
    public float hasMask = 0;
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
        timeStart -= Time.deltaTime;
    }
    
    void setAnimation(){
        
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);
        if (hasMask == 0) { anim.SetFloat("Mask", 0); }
        else { anim.SetFloat("Mask", 1); }
    }
    
    void FixedUpdate()
    {
        if( view.IsMine )
        {
            setAnimation();
            rb.velocity = movement * moveSpeed; 
        }
    }
    public void punishTimer(){
        timeStart -= punishTime;
    }
    void MovementInput(){
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");
        movement = new Vector2(mx, my).normalized;
    }

    public void AppleClicked(){
        float timeSincelastSantized = Time.time - sanitizerBar.lastSanitized;
        if(timeSincelastSantized > 10.0f){
            punishTimer();
        }
        energybar.IncrementEnergy(5.0f);
    }
    public void BreadClicked(){
        float timeSincelastSantized = Time.time - sanitizerBar.lastSanitized;
        if(timeSincelastSantized > 10.0f){
            punishTimer();
        }
        energybar.IncrementEnergy(10.0f);
    }

    public void SanitizerClicked()
    {
        sanitizerBar.DecrementSanitizer();
    }
    public void BuySanitizer(){
        if(money.money >= ms.sanitizerPrice){
            money.DecrementMoney(ms.sanitizerPrice);
            sanitizerBar.IncreaseSanitizerCount(1);
        }
    }
    public void BuyMask(){
        if(money.money >= ms.maskPrice){
            money.DecrementMoney(ms.maskPrice);
            mask.IncreaseMaskCount(1);
        }
    }
    public void BuyApple(){
        if(money.money >= ab.applePrice){
            money.DecrementMoney(ab.applePrice);
            apple.IncreaseApples(1);
        }
    }
    public void BuyBread(){
        if(money.money >= ab.breadPrice){
            money.DecrementMoney(ab.breadPrice);
            bread.IncreaseBread(1);
        }
    }
    void OnTriggerEnter2D (Collider2D other){
        if(other.name == "MedicalTrigger"){
            ms.gameObject.SetActive(true);
        }
        else if(other.name == "MarketTrigger"){
            ab.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.name ==  ("MedicalTrigger")){
            ms.gameObject.SetActive(false);
        }
        else if(other.name == "MarketTrigger"){
            ab.gameObject.SetActive(false);
        }
    }   
}
