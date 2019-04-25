using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {
    
    public void load(string sceneName) {
        gameManaging.gameInstance.savedScore = 0;
        SceneManager.LoadScene("level1");
    }

}
