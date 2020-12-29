using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetForce : MonoBehaviour
{
    private LineRenderer lineRenderer; 

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");
        var pos = lineRenderer.GetPosition(1);

        pos.z += horizontalInput * Time.deltaTime;
        pos.x += verticalInput * Time.deltaTime;
        pos.y += verticalInput * Time.deltaTime;

        lineRenderer.SetPosition(1, pos);
    }
}
