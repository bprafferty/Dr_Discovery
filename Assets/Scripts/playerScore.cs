using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerScore : MonoBehaviour {
    
    public int score = 0;

    public float time = 120.0f;

    public GameObject scoreCanvas;
    public GameObject timeCanvas;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        scoreCanvas.gameObject.GetComponent<Text>().text = ("Score: " + score);
        time -= Time.deltaTime;
        timeCanvas.gameObject.GetComponent<Text>().text = ("Time: " + (int)time);

        if (time < 0.1f) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnTriggerEnter2D(Collider2D trigger) {
        if (trigger.gameObject.tag == "Finish") {
            multiplyScore();
            loadNext();
        }
    }

    void multiplyScore() {
        score = score + (int)(time * 10);
    }

    void loadNext() {
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextLevel);
    }
}
