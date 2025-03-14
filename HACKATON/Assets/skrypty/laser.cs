using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Laser : MonoBehaviour
{
    [SerializeField] private float maxLength = 8f;
    [SerializeField] private int maxReflections = 8;
    public LineRenderer lineRenderer;
    [SerializeField] private LayerMask mirrorsLayerMask;
    
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
