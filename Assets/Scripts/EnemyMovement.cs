using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private BoxCollider2D enemiecollision;//
    private Rigidbody2D ERB;
    public bool facingleft = true;
    public float movespeed = 20f;
    private SpriteRenderer MSR;
    // Start is called before the first frame update
    void Start()
    {
        MSR=GetComponent<SpriteRenderer>();
        enemiecollision = GetComponent<BoxCollider2D>();
        ERB= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (facingleft == true)
        {
            ERB.velocity = new Vector2(-movespeed, 0f);
        }

        if (facingleft == false)
        {
            ERB.velocity = new Vector2(movespeed, 0f);
        }
 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyB")
        {
            facingleft = !facingleft;
            MSR.flipX = !facingleft;


        }
    }
    
}


