using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{

    public float speed;
    private float horizontalInput = 0;

    [Range(0, 100)]
    public int health = 100;

    Rigidbody2D rb;
    Animator anim;


    public void inflictDamage(int damageAmount)
    {
        health -= damageAmount;
        print(health);
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();    
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
        updateInput();
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


    private void updateInput()
    {
        //print("updateinput");
        horizontalInput = Input.GetAxis("Horizontal");
    }

}
