using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject bullet;
    private GameControllerScript gameController;
    private bool isGameOver = false;
    private int ammo = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindWithTag("GameController")
            .GetComponent<GameControllerScript>();
        StartCoroutine("Shoot");
        
    }

    // Update is called once per frame
    void Update()
    {
        float dx = Input.GetAxis("Horizontal") * Time.deltaTime * 8f;
        float dy = Input.GetAxis("Vertical") * Time.deltaTime * 8f;

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + dx, -8f, 8f),
            Mathf.Clamp(transform.position.y + dy, -4.5f, 4.5f),
            0f
        );
        isGameOver = gameController.isGameOver;
    }
    public void addAmmo(int num)
    {
        ammo += num;
        gameController.setAmmo(ammo);
    }

    IEnumerator Shoot()
    {
        while (!isGameOver)
        {
            if (ammo>0&&Input.GetMouseButton(0))
            {
                ammo -= 1;
                gameController.setAmmo(ammo);
                GameObject b0 = Instantiate(bullet, transform.position, transform.rotation);
                b0.GetComponent<BulletScrpit>().bulletType = 0;
                GameObject b1 = Instantiate(bullet, transform.position, transform.rotation);
                b1.GetComponent<BulletScrpit>().bulletType = 1;
                GameObject b2 = Instantiate(bullet, transform.position, transform.rotation);
                b2.GetComponent<BulletScrpit>().bulletType = 2;
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                
                GameObject b = Instantiate(bullet, transform.position, transform.rotation);
                b.GetComponent<BulletScrpit>().bulletType = 0;
                yield return new WaitForSeconds(0.2f);
            }
           
        }
    }
}
