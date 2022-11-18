using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float horizontalMovement;
    public float verticalMovement;
    private Rigidbody playerRb;
    public float force;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        // Taking player horizontal and vertical movment
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        // Adding right force on horizontal input
        playerRb.AddForce(Vector3.right * speed * horizontalMovement);

        // Addming forward force on vertical movement
        playerRb.AddForce(Vector3.forward * speed * verticalMovement);
    }

    private void OnCollisionEnter(Collision col)
    {
        // If enemy collides with player enemy will die
        if (col.gameObject.CompareTag("Enemy"))
        { 
            gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * force);
            Destroy(col.gameObject);
        }
        // if player collides with wall player will die
        else if (col.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            gameOver = true;
        }
    }
}
