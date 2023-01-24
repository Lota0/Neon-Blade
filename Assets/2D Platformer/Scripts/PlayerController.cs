using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float movingSpeed;//change the variables to match the game
        public float jumpForce;
        private float moveInput;

        private bool facingRight = true;
        [HideInInspector]
        public bool deathState = false;

        private bool isGrounded;
        public Transform groundCheck;

        private Rigidbody2D rigidbody;
        private Animator animator;
        public BoxCollider2D AttackRadius;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();

        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        void Update()
        {
            if (Input.GetKeyDown("e"))
            {
                animator.SetInteger("playerState", 2);


            }
            else if (Input.GetButton("Horizontal")) 
            {
                moveInput = Input.GetAxis("Horizontal");
                Vector3 direction = transform.right * moveInput;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
                animator.SetInteger("playerState", 1); 
            }
            else
            {
                if (isGrounded) animator.SetInteger("playerState", 0);// changed the playerstate to 0
            }
            if(Input.GetKeyDown(KeyCode.Space) && isGrounded )
            {
                rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }
            if (!isGrounded)animator.SetInteger("playerState", 0); 

            if(facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if(facingRight == true && moveInput < 0)
            {
                Flip();
            }

        }

        private void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
            isGrounded = colliders.Length > 1;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            //if (other.gameObject.tag == "Enemy" && Input.GetKey("e"))
            //{
            //    Destroy(other.gameObject);
            //    //deathState = true; // Say to GameManager that player is dead
            //}
            //else
            //{
            //    deathState = false;
            //}
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
           //if (other.gameObject.tag == "Coin")
           //{
           //    Destroy(other.gameObject);
           //}
           //if (other.gameObject.tag == "Enemy" && Input.GetKeyDown("e"))
           //{
           //    Destroy(other.gameObject);
           //    //deathState = true; // Say to GameManager that player is dead
           //}
        }
    }
}
