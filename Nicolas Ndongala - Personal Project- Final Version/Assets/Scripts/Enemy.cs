using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed; 
    private Rigidbody enemyRb;
    private GameObject player;
    public GameManager gameManager;
   
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRb.AddForce((player.transform.position
            - transform.position).normalized * speed);
         if (transform.position.y < -10) 
        { 
            Destroy(gameObject);
            gameManager.UpdateScore(1);
        }   
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            gameManager.GameOver();
        }
    }
}
