using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CBD.Gameplay;

public class Collectible : MonoBehaviour
{
    public string type;
    private object thisObject;
    PlayerHealth playerhealth;
    PlayerTime playertime;
    public float bonus = 20f;

    void Awake(){
        if(type=="Food"){
            thisObject = GetComponent<Food>();
        }
        else {
            thisObject = GetComponent<Drink>();
        }
        playertime = FindObjectOfType<CBD.Gameplay.PlayerTime>();
        playerhealth = FindObjectOfType<CBD.Gameplay.PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            if(type=="Food"){
                if(playerhealth.health<playerhealth.maxhealth){
                    playerhealth.health += 10;
                }
                else{
                    playerhealth.health=playerhealth.maxhealth;
                }   
            }
            else {
                playertime.timeLeft += 10;
            }
            Destroy(gameObject);
        }
    }
}
