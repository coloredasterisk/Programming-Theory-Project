using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Vehicle : MonoBehaviour
{
    public float xSpawnRange { get; protected set; } = 13;
    protected float yBound = -5;
    protected float zBound = -11;
    private Rigidbody vehicleBody;
    protected float speed;
    protected int scoreValue;
    private GameManager gameManager;

    void Start()
    {
        SetValue();
        vehicleBody = GetComponent<Rigidbody>();
        vehicleBody.AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);
        gameManager = FindObjectOfType<GameManager>();
    }
    // ABSTRACTION
    protected abstract void SetValue();

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
    // ABSTRACTION
    protected virtual void Move()
    {
        vehicleBody.AddRelativeForce(Vector3.forward * speed);
    }
}
