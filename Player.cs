using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int walkSpeed, runSpeed, currentSpeed;
    public Player()
    {
        currentSpeed = walkSpeed;
        walkSpeed = 5;
        runSpeed = 10 * walkSpeed;
    }
    public CapsuleCollider playerCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(CalculatePlayerSpeed());

        if (Input.GetKeyDown("left shift"))
        {
            print("crouching");
            Crouch();
        }

        if (Input.GetKeyUp("left shift"))
        {
            print("standing");
            Stand();
        }

    }


    // calculates the players movement speed
    private int CalculatePlayerSpeed()
    {
        int speed = currentSpeed;
        if (Input.GetKeyDown("space"))
        {
            print("running");
            currentSpeed = runSpeed;
        }
        else if (!Input.GetKey("space"))
        {
            print("walking!");
            currentSpeed = walkSpeed;
        }

        return speed;
    }

    // crouches the player
    private void Crouch()
    {
        playerCollider.height = 1f;
        playerCollider.center = new Vector3(0f, 0.5f, 0f);
    }

    // stands the player back up
    private void Stand()
    {
        playerCollider.height = 1.6f;
        playerCollider.center = new Vector3(0f, 1f, 0f);
    }

    // turns the player
    private void turn()
    {

    }

    // moves the player
    private void Move(int speed)
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        transform.Translate(movement * Time.deltaTime * speed);
    }

}