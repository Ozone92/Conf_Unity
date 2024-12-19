using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicsMovement : MonoBehaviour
{
    [SerializeField] private int speed = 10;
    [SerializeField] private int rotSpeed = 10;
    [SerializeField] private int jumpCooldown = 2;
    [SerializeField] private int jumpForce = 3;

    private float jumpTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Deplacement();
        Rotation();
        Saut();
    }

    void Deplacement()
    {
        transform.position += Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
    }

    void Rotation()
    {
        transform.localEulerAngles += new Vector3(0, 1, 0) * Input.GetAxis("Vertical") * rotSpeed * Time.deltaTime;
    }

    void Saut()
    {
        if (jumpTimer <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += Vector3.up * jumpForce;
            jumpTimer = jumpCooldown;
        }

        if (jumpTimer > 0)
        {
            jumpTimer -= Time.deltaTime;
            Debug.Log("Timer réduit a : " + jumpTimer.ToString());
        }
    }
}
