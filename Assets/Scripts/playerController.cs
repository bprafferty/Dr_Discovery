using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {
    public int movementSpeed = 10;
    private float moveX;
    public int jumpPower = 1100;
    public bool isGrounded;
    public float distanceToPlayerFeet = 0.55f;


    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        movePlayer();
        rayCast();
        if (gameObject.transform.position.y < -7) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void movePlayer() {

        //controls
        if (Input.GetButtonDown("Jump") && isGrounded == true) {
            jumpPlayer();
        }
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

    void jumpPlayer() {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
        isGrounded = false;
    }

    void rayCast() {
        RaycastHit2D downward = Physics2D.Raycast(transform.position, Vector2.down);
        if (downward != null && downward.collider != null && downward.distance < distanceToPlayerFeet && downward.collider.tag != "Enemy") {
            isGrounded = true;
        }
        if (downward != null && downward.collider != null && downward.distance < distanceToPlayerFeet && downward.collider.tag == "Enemy") {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            downward.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            downward.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 15;
            downward.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            downward.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            downward.collider.gameObject.GetComponent<enemyController>().enabled = false;
            GetComponent<playerScore>().score += 100;
        }


    }
}
