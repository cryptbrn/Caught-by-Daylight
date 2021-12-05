using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CBD.Gameplay;
namespace CBD.Mechanics{
    public class EnemyController : MonoBehaviour
    {
        public int EnemySpeed;
        public int XMoveDirection;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            EnemyRaycast();
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0)*EnemySpeed;

        }

        void Flip(){
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            if (XMoveDirection > 0){
                XMoveDirection = -1;
            }
            else {
                XMoveDirection = 1;
            }
        }

        void EnemyRaycast(){
            RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2(XMoveDirection, 0));
            RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
            if(hit.distance < 0.9f && hit.collider.tag != "Ground"){
                Flip();
                if(hit.collider.tag == "Player"){
                    gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0)*EnemySpeed;
                    FindObjectOfType<PlayerHealth>().LoseHealth(10);
                }
            }

            if(rayUp.collider!=null && rayUp.distance< 0.9&& rayUp.collider.tag == "Player"){
                GetComponent<Rigidbody2D>().AddForce(Vector2.right*200);
                GetComponent<Rigidbody2D>().gravityScale = 8;
                GetComponent<Rigidbody2D>().freezeRotation = false;
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<EnemyController>().enabled = false;
            }

        }
    }
}

