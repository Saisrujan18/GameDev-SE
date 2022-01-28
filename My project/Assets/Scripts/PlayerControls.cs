using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    private Animator anim;
    public float moveSpeed;
    public bool maskOn = false, isInfected= false;
    public Button toggleMask;
    public float health;
    public float maxHealth = 100;

    public Rigidbody2D rb;

    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = maxHealth;
        toggleMask = toggleMask.GetComponent<Button>();
		toggleMask.onClick.AddListener(maskBtnClicked);
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
    }

    void FixedUpdate(){
        if(movement.x == 0) {
            anim.SetBool("isMovingRight", false);
            anim.SetBool("isMovingLeft", false);
        }
        else if(movement.x < 0) {
            anim.SetBool("isMovingRight", false);
            anim.SetBool("isMovingLeft", true);
        }
        else {
            anim.SetBool("isMovingRight", true);
            anim.SetBool("isMovingLeft", false);
        }
        rb.velocity = movement * moveSpeed; 
    }

    void MovementInput(){
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");
        movement = new Vector2(mx, my).normalized;
    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.tag == "Player"){
            PlayerControls otherPlayer = collision.gameObject.GetComponent<PlayerControls>();
            if(otherPlayer.isInfected)
                isInfected = !maskOn;
        }
    }
    void maskBtnClicked(){
        maskOn = !maskOn;
        Debug.Log(maskOn);
    }   
}
