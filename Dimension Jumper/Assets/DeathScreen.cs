using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour {
    public GameObject player, deathCanvas;
    public Health health;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        deathCanvas = GameObject.Find("Death Canvas");
        deathCanvas.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        health = player.GetComponent<Health>();

        if (health.hearts <= 0)
        {
            deathCanvas.SetActive(true);
        }
	}
}
