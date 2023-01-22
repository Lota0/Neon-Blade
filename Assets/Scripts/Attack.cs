using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Attack : MonoBehaviour
{

    public bool IsOverLapping;
    public GameObject Enemy;

    void Update()
    {
        if (IsOverLapping == true && Input.GetKey("e"))
        {
            UnityEngine.Debug.Log("Trigger");
            Destroy(Enemy.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            IsOverLapping = true;
            Enemy = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            IsOverLapping = false;
            Enemy = null;
            

        }
    }





}
