using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCharacter : MonoBehaviour
{

    public GameObject losePanel;

    public Text healthDisplay;
    public float speed;
    private float horizontalInput = 0;
    
    [Range(0, 100)]
    public int health = 100;

    Rigidbody2D rb;
    Animator anim;
    AudioSource audioSource;

    public void inflictDamage(int damageAmount)
    {
        UpdateHealth(damageAmount);
        PlayDamageSound();
        CheckIfDead();
        UpdateHealthLabel();
    }

    private void UpdateHealthLabel()
    {
        healthDisplay.text = health + "%";
    }

    private void PlayDamageSound()
    {
        audioSource.Play();
    }

    private void UpdateHealth(int damageAmount)
    {
        health -= damageAmount;
    }

    private void CheckIfDead()
    {
        bool isDead = health <= 0;
        if (isDead)
        {
            losePanel.SetActive(true);
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        UpdateHealthLabel();
    }


    private void Update()
    {
        updateIsRunning();
        updateDirection();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //print(horizontalInput);
        updateKeyboardInput();
        updateVelocity();
    }

    private void updateVelocity()
    {
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }

    private void updateIsRunning()
    {
        anim.SetBool("isRunning", horizontalInput != 0);
    }

    private void updateDirection()
    {
        if (horizontalInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (horizontalInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }


    private void updateKeyboardInput()
    {
        //print("updateinput");
        horizontalInput = Input.GetAxis("Horizontal");
    }

}
