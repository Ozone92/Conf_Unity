using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonGestion : MonoBehaviour
{
    public float speed = 10;
    public GameObject bullet;
    public Vector3 spawnOffset = new Vector3(0, 0, 5);

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed, 0, 0);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(bullet, transform.position + spawnOffset, bullet.transform.rotation);
        }
    }
}
