using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CBD.Gameplay{
    public class PlayerTime : MonoBehaviour
    {
        public float timeLeft = 10;
        public GameObject timeLeftUI; 

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(timeLeft>0){
                timeLeft -= Time.deltaTime;
            }
            
            timeLeftUI.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = ("Waktu tersisa: "+(int)timeLeft);
            if(timeLeft< 0.1f){
                PlayerHealth.isPlayerDead = true;
            }
        }
    }
}

