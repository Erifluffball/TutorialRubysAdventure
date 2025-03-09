using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object that entered the trigger: " + other);
        PlayerController controller = other.GetComponent<PlayerController>();

         if (controller != null)
   {
    if (controller != null && controller.health < controller.maxHealth)
   {
    //controller.PlaySound(collectedClip); (Crashes the game)
       controller.ChangeHealth(1);
       Destroy(gameObject);
   }
   }
    }
}
