using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Vehicle : MonoBehaviour
{

    public static float yBound { get; } = -5;
    public static float zBound { get; } = -11;
    private Rigidbody vehicleBody;
    public float speed = 40;
    private int scoreValue = 1;
    private GameManager gameManager;

    void Start()
    {
        vehicleBody = GetComponent<Rigidbody>();
        vehicleBody.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        gameManager = FindObjectOfType<GameManager>();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        if(transform.position.y < yBound || transform.position.z < zBound)
        {
            gameManager.UpdateScore(scoreValue);
            Destroy(gameObject);
        }
    }

    protected virtual void Move()
    {
        vehicleBody.AddRelativeForce(Vector3.forward * speed);
        Vector3 position = GameObject.Find("Player").transform.position;
        position.y = transform.position.y;
        transform.LookAt(position);

    }
}
