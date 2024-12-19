using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemieGestion : MonoBehaviour
{
    public int speed = 10;
    public EnnemieSpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
        if (transform.position.z <= -40)
        {
            spawnManager.End();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            spawnManager.AddScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
