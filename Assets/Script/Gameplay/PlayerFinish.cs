using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CBD.Gameplay{
    public class PlayerFinish : MonoBehaviour
    {
        public static bool isPlayerFinish;

        // Start is called before the first frame update
        void Start()
        {
            isPlayerFinish = false;
        }

        // Update is called once per frame
        void Update()
        {
            PlayerRaycast();
        }

        void PlayerRaycast(){
            RaycastHit2D rayRight = Physics2D.Raycast(transform.position, Vector2.right);
            
            if(rayRight.collider != null && rayRight.distance < 0.9 && rayRight.collider.tag == "FinishZone") {
                Debug.Log("MASUK");
                isPlayerFinish = true;
            }
        }
    }
}