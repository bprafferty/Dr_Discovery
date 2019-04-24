using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {
    public int movementSpeed = 10;
    private float moveX;
    public int jumpPower = 1100;
    public bool onFloor;
    public float distanceToPlayerFeet = 0.55f;


    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        movePlayer();
        rayCast();
        if (gameObject.transform.position.y < -10) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void movePlayer() {

        //controls
        if (Input.GetButtonDown("Jump") && onFloor == true) {
            jumpPlayer();
        }
        moveX = Input.GetAxis("Horizontal");

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

    void jumpPlayer() {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
        onFloor = false;
    }

    void rayCast() {
        RaycastHit2D downwardCollisionDetection = Physics2D.Raycast(transform.position, Vector2.down);
        //check for being on the ground
        if (downwardCollisionDetection != null && downwardCollisionDetection.collider != null && downwardCollisionDetection.distance < distanceToPlayerFeet && downwardCollisionDetection.collider.tag != "Enemy") {
            onFloor = true;
        }
        //jump on top of enemy, make the enemy fall through the floor
        if (downwardCollisionDetection != null && downwardCollisionDetection.collider != null && downwardCollisionDetection.distance < distanceToPlayerFeet && downwardCollisionDetection.collider.tag == "Enemy") {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1500);
            downwardCollisionDetection.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 400);
            downwardCollisionDetection.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 30;
            downwardCollisionDetection.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            downwardCollisionDetection.collider.gameObject.GetComponent<enemyController>().enabled = false;
            GetComponent<playerScore>().score += 100;
        }


    }
}
