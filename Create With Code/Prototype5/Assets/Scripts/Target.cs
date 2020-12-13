using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private const int maxTorque = 10;
    private const int xRange = 4;
    private const int yPos = -2;
    private const int minForce = 12;
    private const int maxForce = 16;
    private Rigidbody targetRb;
    private GameManager gameManager;
    private int RandomTorque => Random.Range(-maxTorque, maxTorque);
    private Vector3 RandomXPosition => new Vector3(Random.Range(-xRange, xRange), yPos);
    public int points;
    public ParticleSystem explosionParticles;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        targetRb.AddForce(RandomUpForce(), ForceMode.Impulse);

        var torque = new Vector3(RandomTorque, RandomTorque, RandomTorque);
        targetRb.AddTorque(torque, ForceMode.Impulse);

        transform.position = RandomXPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() 
    {
        Destroy(gameObject);    
        gameManager.UpdateScore(points);
        Instantiate(explosionParticles, transform.position, explosionParticles.transform.rotation);
    }

    private void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject);    
    }

    private Vector3 RandomUpForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }
}
