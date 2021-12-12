using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    private object thisObject;
    CBD.Gameplay.PlayerHealth playerhealth;
    public float healthBonus = 20f;

    void Awake(){
        thisObject = GetComponent<Food>();
        playerhealth = FindObjectOfType<CBD.Gameplay.PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            if(playerhealth.health<playerhealth.maxhealth){
                playerhealth.health += 10;
                Destroy(gameObject);
                Debug.Log("Health: " + playerhealth.health);
            }
            else{
                playerhealth.health=playerhealth.maxhealth;
                Destroy(gameObject);
                Debug.Log("Health: " + playerhealth.health);
            }   
        }
    }
}
