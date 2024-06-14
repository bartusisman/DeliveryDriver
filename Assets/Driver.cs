using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed = 200f;
    [SerializeField] private float moveSpeed = 30;
    [SerializeField] private float slowAmount = 5;
    [SerializeField] private float speedupAmount = 5;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }

     private void OnCollisionEnter2D(Collision2D other) 
    {
        if (!(moveSpeed < 10))
        {
            moveSpeed -= slowAmount;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "boosts" && moveSpeed <= 700)
        {
            moveSpeed += speedupAmount;
            Destroy(other.gameObject,0);
        }
        if (moveSpeed>700)
        {
            Debug.Log("Car is at max speed!");
        }
    }

}
