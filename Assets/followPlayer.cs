﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {
    private GameObject player;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate() {
        float x = Mathf.Clamp(player.transform.position.x, minX, maxX);
        float y = Mathf.Clamp(player.transform.position.y, minY, maxY);
        gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }
}
