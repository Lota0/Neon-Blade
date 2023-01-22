using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody2D rb;
    private float force = 40000f;
    public float MoveSpeed = 10f;
    private float yMovement;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = rb.velocity;
        vel.y = yMovement;
        rb.velocity = vel;

        if (Input.GetKeyDown("p"))
        {
            rb.AddForce(transform.up * force);


        }
        
       //if (Input.GetKey("d"))
       //{
       //    PlayerBody2D.AddForce(transform.right * forceright* Time.deltaTime);
       //}

        if (Input.GetKey("d"))
        {
            rb.velocity = new Vector2(MoveSpeed, yMovement);
        }
        else if (Input.GetKey("a"))
        {
            rb.velocity = new Vector2(-MoveSpeed, yMovement);
        }
        else
        {
            
        }

        

    }
    
}
