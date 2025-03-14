using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    [SerializeField] private float maxLength = 8f;
    [SerializeField] private int maxReflections = 8;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private LayerMask mirrorsLayerMask;
    private EdgeCollider2D edgeCollider;
    //  [SerializeField] private LayerMask playerLayerMask;
    //   [SerializeField] private LayerMask buttonLayerMask;
    //   [SerializeField] private Wlacznik Wlacznik;
    private Ray ray;
    private RaycastHit2D hit;
    //  private RaycastHit2D hit2;
    //  private RaycastHit2D hit3;
    //  public GameObject player;


    private void Start()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
    }
    private void Update()
    {
        ray = new Ray(transform.position, transform.up);

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        float remainingLength = maxLength;

        for (int i = 0; i < maxReflections; i++)
        {
            hit = Physics2D.Raycast(ray.origin, ray.direction, remainingLength, mirrorsLayerMask.value);
           // hit2 = Physics2D.Raycast(ray.origin, ray.direction, remainingLength, playerLayerMask.value);
           // hit3 = Physics2D.Raycast(ray.origin, ray.direction, remainingLength, buttonLayerMask.value);
            lineRenderer.positionCount += 1;
            //   if(hit2)
            //     {
            //Destroy(player);
            //         Debug.Log("Zginoles");
            //  SceneManager.LoadScene("GameOver");
            //     }
            ///     if(hit3)
            //      {
            //         Wlacznik.licznik = 1;
            // Debug.Log("sdsffddf");
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
            //         }
            if (hit)
            {
                
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
                remainingLength -= Vector2.Distance(ray.origin, hit.point);
                ray = new Ray(hit.point - (Vector2)ray.direction * 0.01f, Vector2.Reflect(ray.direction, hit.normal));

            }
            else
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);
        }

    }

}
