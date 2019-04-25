using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManaging : MonoBehaviour {
    public static gameManaging gameInstance {
        get;
        private set;
    }

    public int savedScore;

    private void Awake() {
        if (gameInstance == null) {
            Debug.Log("Saved Score is " + savedScore);
            gameInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
