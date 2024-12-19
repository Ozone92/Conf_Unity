using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    public bool usePhysic = false;

    [SerializeField] private int speed = 10;
    [SerializeField] private int rotSpeed = 10;
    [SerializeField] private int jumpCooldown = 2;
    [SerializeField] private int jumpForce = 3;

    private float jumpTimer = 0;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        if (!usePhysic)
            transform.position += Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        else
            rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * speed / 2, ForceMode.Force);
    }

    void Rotation()
    {
        transform.localEulerAngles += new Vector3(0, 1, 0) * Input.GetAxis("Vertical") * rotSpeed * Time.deltaTime;
    }

    void Saut()
    {
        if (jumpTimer <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            if (!usePhysic)
                transform.position += Vector3.up * jumpForce;
            else
                rb.AddForce(Vector3.up * jumpForce * 2, ForceMode.Impulse);
            jumpTimer = jumpCooldown;
        }

        if (jumpTimer > 0)
        {
            jumpTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mur"))
        {
            Debug.Log("Aye");
        }
    }
}
