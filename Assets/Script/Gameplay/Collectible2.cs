using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectible2 : MonoBehaviour
{
    private object thisObject;
    CBD.Gameplay.PlayerTime playertime;
    public float timeBonus = 20f;

    private void Awake(){
        thisObject = GetComponent<Drink>();
        playertime = FindObjectOfType<CBD.Gameplay.PlayerTime>();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            playertime.timeLeft += 10;
            Destroy(gameObject);
        }
    }
}
