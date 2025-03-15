using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightfollower : MonoBehaviour
{
    private EdgeCollider2D edgeCollider;
    [SerializeField] private GameObject laser;
    private LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
        lineRenderer =  laser.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lineRenderer.positionCount >= 2)
        {
            // Set the EdgeCollider2D points to the LineRenderer positions
            List<Vector2> colliderPoints = new List<Vector2>(lineRenderer.positionCount);

            for (int j = 0; j < lineRenderer.positionCount; j++)
            {
                // Convert the LineRenderer's world positions to local positions
                colliderPoints.Add(lineRenderer.GetPosition(j));
            }

            // Update the EdgeCollider2D's points to follow the LineRenderer
            edgeCollider.SetPoints(colliderPoints);
        }
    }
}
