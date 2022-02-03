using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.SceneManagement;

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
    public vaccine v;
    public GameObject MessageBox;
    public Text message;
    public GameObject workBtn;


    private Vector2 movement;
    public Animator anim;
    public float moveSpeed;
    public float hasMask = 0;
    public Rigidbody2D rb;
    public PhotonView view;
    public bool isInfected = false, atWork = false;   
    public float lastAtWork = 0.0f; 
    public bool isMaskOn = false;
    private Transform hospitalSpawnPoint;
    private Transform officeSpawnPoint;
    // Start is called before the first frame update

    public void DisplayMessage(string str, int seconds)
    {
        MessageBox.SetActive(true);
        message.text = str;
        StartCoroutine(Wait_yo(seconds));
    }
    
    IEnumerator Wait_yo(int sec){
        yield return new WaitForSeconds(sec);
        MessageBox.SetActive(false);
    }

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
        hospitalSpawnPoint = GameObject.Find("HospitalRespawn").transform;
        officeSpawnPoint = GameObject.Find("OfficeRespawn").transform;
    }
    private int nextUpdate = 1;
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Called update"); 
        if( view.IsMine )
        {
            MovementInput();
            if(Time.time>=nextUpdate){
             Debug.Log(Time.time+">="+nextUpdate);
             // Change the next update (current second+1)
             nextUpdate=Mathf.FloorToInt(Time.time)+1;
             // Call your fonction
             UpdateEverySecond();
             if(atWork) {
                 float timeElapsed = Time.time - lastAtWork;
                 if(timeElapsed > 10.0f){
                     EndWork();
                 }
             }
         }
        }
    }

    public void UpdateEverySecond()
    {
        UpdateInfectionExtent();
            energybar.IncrementEnergy(-0.2f);
            if( mask.MaskCount  != 0 )
            {
                hasMask = 1;
                infectionDecRate = 0.3f;
            }
            else
            {
                hasMask = 0;
                infectionDecRate = 0.8f;
            }
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
    public void BreadClicked(){
        if(bread.BreadCount >= 1) {
            bread.DecrementBread();
            float timeSincelastSantized = Time.time - sanitizerBar.lastSanitized;
            if(timeSincelastSantized > 10.0f){
                punishInfection();
            }
            energybar.IncrementEnergy(15.0f);
        }
    }

    public void AppleClicked(){
        if(apple.AppleCount >= 1){
            apple.DecrementApples();
            float timeSincelastSantized = Time.time - sanitizerBar.lastSanitized;
            if(timeSincelastSantized > 10.0f){
                punishInfection();
            }
            energybar.IncrementEnergy(10.0f);
        }
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

    public void getTested()
    {
        if( money.money >= v.testPrice)
        {
            money.DecrementMoney(v.testPrice);
        }
    }

    public void getVaccinated()
    {
        if( money.money >= v.vaccinePrice)
        {
            money.DecrementMoney(v.vaccinePrice);
        }
    }

    void OnTriggerEnter2D (Collider2D other){
        if(other.name == "MedicalTrigger"){
            ms.gameObject.SetActive(true);
        }
        else if(other.name == "MarketTrigger"){
            ab.gameObject.SetActive(true);
        }
        else if( other.name == "VaccineTrigger")
        {
            v.gameObject.SetActive(true);
        }
        else if(other.name == "OfficeTrigger") {
            workBtn.gameObject.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.name ==  ("MedicalTrigger")){
            ms.gameObject.SetActive(false);
        }
        else if(other.name == "MarketTrigger"){
            ab.gameObject.SetActive(false);
        }
        else if(other.name == "VaccineTrigger"){
            v.gameObject.SetActive(false);
        }
        else if(other.name == "OfficeTrigger"){
            workBtn.gameObject.SetActive(false);
        }
    }   

    public void StartWork(){
        atWork = true;
        lastAtWork = Time.time;
        Respawn(officeSpawnPoint);
        workBtn.gameObject.SetActive(false);
        Debug.Log("Work started..");
    }

    public void EndWork(){
        money.IncrementMoney(10);
        lastAtWork = 0.0f;
        atWork = false;
        Debug.Log("Work ended..");
    }

    public float infectionExtent = 0;
    public float infectionDecRate = 0.0003f;

    void UpdateInfectionExtent(){
        int sev = getSeverity();
        if(sev == 0){
            infectionExtent -= infectionDecRate;
        }
        else if(sev == 1){
            infectionExtent -= infectionDecRate/2;
            if(energybar.GetEnergy() > 80) 
                infectionExtent -= infectionDecRate/2;
        }
        else if(sev == 2){
            infectionExtent += infectionDecRate;
        }
        if( infectionExtent < 0 )
        {
            infectionExtent = 0;
        }
        CheckInfectionExtent();
    }
    
    void Respawn(Transform respawnPoint){
        transform.position = new Vector2(respawnPoint.position.x, respawnPoint.position.y);
    }

    void CheckInfectionExtent(){
        if(infectionExtent >= 80) {
            Respawn(hospitalSpawnPoint);
            DisplayMessage("You Lose, You got Infected", 10);
            end();
        }
    }
    IEnumerator end(){
            yield return new WaitForSeconds(10);
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene("MainMenu");
    }
    
    public void punishInfection(bool additional = false){
        infectionExtent += infectionDecRate;
        if(additional) infectionExtent += infectionDecRate;
        CheckInfectionExtent();       
    }
    //TODO:
    int getSeverity(){
        if(infectionExtent > 80) return 3;
        else if(infectionExtent > 60) return 2;
        else if(infectionExtent > 40) return 1;
        else return 0;
    }
}
