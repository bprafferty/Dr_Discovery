using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    public int movementSpeed = 10;
    private float moveX;


    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        movePlayer();
    }

    void movePlayer() {

        //controls
        moveX = Input.GetAxis("Horizontal");

        //animations

        //player direction
        if (moveX < 0.0f){
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveX > 0.0f) {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        //physics
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * movementSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
    }
}
