using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScrpit : MonoBehaviour
{
    static int bulletId = 0;
    public int bulletType = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        bulletId++;
    }

    // Update is called once per frame
    void Update()
    {
        // 待完善
        
        transform.position += new Vector3(
            0f, 10f * Time.deltaTime, 0f
        );
        if (bulletType == 1) {
            transform.position += new Vector3(
           -4.5f * Time.deltaTime, 0f, 0f
        );
        }
        if (bulletType == 2)
        {
            transform.position += new Vector3(
           4.5f * Time.deltaTime, 0f, 0f
        );
        }
    }
}
