using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CBD.Gameplay{
    public class PlayerHealth : MonoBehaviour
    {
        public float health;
        public Image fillbar;
        public static bool isPlayerDead;

        // Start is called before the first frame update
        void Start()
        {
            isPlayerDead = false;
            health = 100;
        }

        // Update is called once per frame
        void Update()
        {
            PlayerRaycast();
        }

        void PlayerRaycast(){
            RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);
            
            if(rayDown.collider != null && rayDown.distance < 0.9 && rayDown.collider.tag == "DeathZone") {
                isPlayerDead = true;
            }
        }

        public void LoseHealth(int value){
            if (health<=0)
                return;
            health -= value;
            fillbar.fillAmount = health / 100;
            if(health<=0)
                isPlayerDead = true;
        }
    }
}