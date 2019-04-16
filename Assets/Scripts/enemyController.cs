using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class enemyController : MonoBehaviour {
    public int lives = 3;
    public GameObject livesCanvas;
    public GameObject chompCanvas;
    public int movementSpeed = 3;
    public int moveX = 1;
    public int currentLives;
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        chompCanvas.GetComponent<Text>().enabled = false;
        livesCanvas.gameObject.GetComponent<Text>().text = ("Lives: " + lives);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(moveX, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveX, 0) * movementSpeed;

        if (hit.distance < 0.9f && moveX < 0)
        {
            moveX = 1;
            GetComponent<SpriteRenderer>().flipX = true;
            if (hit.collider.tag == "Player")
            {
                damage();
            }
        }
        else if (hit.distance < 0.9f && moveX > 0)
        {
            moveX = -1;
            GetComponent<SpriteRenderer>().flipX = false;
            if (hit.collider.tag == "Player")
            {
                damage();
            }
        }

    }

    void damage() {
        lives -= 1;
        damageCanvas();
        if (lives == 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    IEnumerator damageCanvas() {
        coroutine = turnOff(2.0f);

        //chompCanvas.GetComponent<Text>().enabled = true;
        yield return StartCoroutine(coroutine);
        //yield return StartCoroutine(turnOff(2.0f));
    }

    IEnumerator turnOff(float waitTime) {
        while (true) {
            yield return new WaitForSeconds(waitTime);
            chompCanvas.GetComponent<Text>().enabled = true;
        }
    }

}
