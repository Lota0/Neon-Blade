using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private BoxCollider2D enemiecollision;// unused variable
    private Rigidbody2D ERB;// variable for enemys rigidbody
    public bool facingleft = true;// a creates a bool type variable (this variable can only be set to either true or false)
    public float movespeed = 20f;// variable for movespeed
    private SpriteRenderer ESR;// creates and sets the variable type
    // Start is called before the first frame update
    void Start()
    {
        ESR=GetComponent<SpriteRenderer>();//asigns the variable 
        enemiecollision = GetComponent<BoxCollider2D>();// "GetComponent" gets the boxcollider2D component from directly from unity
        ERB= GetComponent<Rigidbody2D>(); // same here as line 16 but instead the component is rigidbody2D and is set for a different variable
    }

    // Update is called once per frame
    void Update()
    {
        if (facingleft == true)//checks if the bool variable "facingleft" is true (The "facingleft variable will automaticly be set to true because of line9,Exept for when a "enemyB"tag is detected (line36)
        {
            ERB.velocity = new Vector2(-movespeed, 0f); // If the variable "facingleft" is true the character will go to the left (because minus float is left on a axis graph)
        }

        if (facingleft == false) //checks if the "facingleft" variable is false
        {
            ERB.velocity = new Vector2(movespeed, 0f); // same thing here as on line 25 but since it is positive it will move to the right (again like an axis graph)
        }
 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyB")// "EnemyB" is EnemyBorder, it is the tag on the trigger collider that are used to make the enemy go the opposite direction when reached
        {
            facingleft = !facingleft;// "!" = not , so when "!" is put before the "facingleft" variable it means nottrue or in other words "false" (since bool can only be "true"or"false"
            ESR.flipX = !facingleft;//this will flip whats inside the variable "ESR" which is the variable for the sprite(only if the if statemens's conditions are completed
            //(flip asumming you have got it connected to a spriterender variable for example "ESR.flipx" will flip the sprite  on its x axis (if it was "flipY" it would flip it 
            // "ESR.flipX = true would activate flipping the sprite but if it was "ESR.flipX = false" it would not do anything or revert the sprite back to it default X axis position(depending on the if the the sprite is currently flipped or not, in short basically "true" will actuvate the precurser while "false" will deactivate the precurser)
        }
    }
    
}


