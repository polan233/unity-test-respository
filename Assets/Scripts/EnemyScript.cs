using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float randomNum0;
    private float randomNum1;

    public int type = 0;
    public GameObject explosion;

    private GameControllerScript gameController;
    private PlayerScript playerScript;

    // Start is called before the first frame update
    void Start()
    {
        randomNum0 = Random.Range(-0.5f, 0.5f);
        randomNum1 = Random.Range(-0.5f, 0.5f);
        playerScript = GameObject.FindWithTag("Player")
            .GetComponent<PlayerScript>();

        if (Random.Range(0, 100f) > 70)
            type = 1;
        Debug.Log(randomNum0 + " " + randomNum1);
        gameController = GameObject.FindWithTag("GameController")
            .GetComponent<GameControllerScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // 待完善
        if (transform.position.x <= -8)
        {
            randomNum0 = Random.Range(0, 0.5f);
        }
        if (transform.position.x >= 8)
        {
            randomNum0 = Random.Range(-0.5f, 0);
        }
        if (transform.position.y >= 4)
        {
            randomNum1 = Random.Range(-0.5f, 0);
        }
        if (transform.position.y <= -4)
        {
            randomNum1 = Random.Range(0, 0.5f);
        }
        float dx = randomNum0 * Time.deltaTime * 8f;
        float dy = randomNum1 * Time.deltaTime * 8f;
        
       
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + dx, -8f, 8f),
            Mathf.Clamp(transform.position.y + dy, -4.5f, 4.5f),
            0f
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("I am dead");
            gameController.AddScore(1);
            if (type == 1)
            {
                playerScript.addAmmo(10);
            }
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            gameController.GameOver();
            Instantiate(explosion, transform.position, transform.rotation);
            Instantiate(explosion, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        
    }
    

}
