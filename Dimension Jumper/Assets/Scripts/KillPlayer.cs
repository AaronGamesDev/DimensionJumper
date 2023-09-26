using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KillPlayer : MonoBehaviour {
    public Health health;
    public GameObject player;
    DimensionHop dimensions;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        health = player.GetComponent<Health>();
        dimensions = player.GetComponent<DimensionHop>();
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && dimensions.unlockedDims[1] == false)
        {
            health.hearts = 0;
            SceneManager.LoadScene("DeathBySign");
        }

    }
}
