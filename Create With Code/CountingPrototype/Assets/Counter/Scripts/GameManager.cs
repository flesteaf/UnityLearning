using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private GameObject targetLine;
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject currentBall;
    [SerializeField] private int forceMultiplier = 1;
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = targetLine.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var force = (lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0)) * forceMultiplier;

            var ballRb = currentBall.GetComponent<Rigidbody>();
            ballRb.AddForce(force, ForceMode.Impulse);
        }

        int presentBalls = FindObjectsOfType<Ball>().Length;
        if (presentBalls == 0)
            NewShot();
    }

    public void NewShot()
    {
        currentBall = Instantiate(ballPrefab);
        float newX = Random.Range(0, -20f);
        float newZ = Random.Range(20f, -20f);

        box.transform.position = new Vector3(newX, box.transform.position.y, newZ);
    }
}
