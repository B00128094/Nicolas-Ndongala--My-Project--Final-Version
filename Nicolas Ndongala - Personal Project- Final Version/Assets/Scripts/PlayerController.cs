using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    private float forwardInput;
    private GameObject focalPoint;
    private Rigidbody playerRb;
    public bool hasPowerup;
    public float superspeed = 15;
    public GameObject powerupIndicator;
    public GameManager gameManager;
    
    
    // Start is called before the first frame update
    void Start()
    {
        focalPoint = GameObject.Find("Focal Point");
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        if (transform.position.y < -10) 
        { 
            Destroy(gameObject);
            gameManager.GameOver();
        }
        powerupIndicator.transform.position = transform.position + new Vector3(0, 3f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            playerRb.AddForce(focalPoint.transform.forward * superspeed * forwardInput);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
