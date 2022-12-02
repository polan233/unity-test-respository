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

        Vector3 mousePositionOnScreen = Input.GetTouch(0).position;
        //Vector3 mousePositionOnScreen = Input.mousePosition;
        Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);
        float dx, dy;
        

        if (mousePositionInWorld.x <= -8)
        {
            mousePositionInWorld.x = -8;
        }
        if (mousePositionInWorld.x >= 8)
        {
            mousePositionInWorld.x=8;
        }
        if (mousePositionInWorld.y >= 4.5)
        {
            mousePositionInWorld.y=4.5f;
        }
        if (mousePositionInWorld.y <= -4.5)
        {
            mousePositionInWorld.y=-4.5f;
        }

        dx = Mathf.Lerp(transform.position.x, mousePositionInWorld.x, 0.05f);
        dy = Mathf.Lerp(transform.position.y, mousePositionInWorld.y, 0.05f);

        transform.position = new Vector3(
            dx,
            dy,
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
            if (ammo>0)
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
