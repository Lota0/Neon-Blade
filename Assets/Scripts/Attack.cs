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
        if (IsOverLapping == true && Input.GetKey("e"))// "&&"sets another condition
        {
            UnityEngine.Debug.Log("Trigger");
            Destroy(Enemy.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other) //"other" will allow us to access information from what we collided with,So only if the collider has the tag "Enemy" other will be assigned to the variable "Enemy" (can see this from line 24-29),therefore when the condition on line16 is met,line19 ("Destroy(Enemy.gameObject);") will then destroy whats in the "Enemy" variable which is "other" and "other" stores the collider so that collider will be destroyed
    {
        if (other.gameObject.tag == "Enemy")// "OnTriggerEnter2D" means on entering the collider,so on entering another collider it will check if the collider has the "Enemy" tag and will then set "IsOverLapping" viariable true
        {
            IsOverLapping = true;
            Enemy = other.gameObject;
        }//"OnTriggerEnter2D" and "OnTriggerExit2D" know that it is using/interacting with colliders because of "(Collider2D other)" nevermind
    }
    private void OnTriggerExit2D(Collider2D other)//"OnTriggerExit2D" means on exiting the collider if the collider that is bieng exited has the tag "Enemy" the variable "IsOverLapping" will be set to false
    {
        if (other.gameObject.tag == "Enemy")
        {
            IsOverLapping = false;
            Enemy = null;
            

        }
    }





}
