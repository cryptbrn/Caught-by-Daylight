using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int playerSpeed = 10;
    public int playerJumpPower = 1250;
    public float moveX;
    public bool isGrounded;
    public float distanceToBottomOfPlayer = 0.9f;


    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRaycast();
    }

    void PlayerMove() {
        //CONTROLS
        moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded == true){
            Jump();
        }
        //ANIMATIONS
        if(moveX!=0){
            GetComponent<Animator>().SetBool("isRunning", true);
        } else {
            GetComponent<Animator>().SetBool("isRunning", false);
        }
        //PLAYER DIRECTION
        if(moveX < 0.0f ){
            GetComponent<SpriteRenderer>().flipX = true;
        } else if(moveX> 0.0f){
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //PHYSICS
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX*playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }

    void Jump(){
        //Jumping Code
        GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
        isGrounded = false;
    }
    void PlayerRaycast(){
        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down);

        if(rayDown != null && rayDown.collider != null && rayDown.distance < 0.9f && rayDown.collider.tag != "Enemy"){
            isGrounded=true;
        }
    }
}