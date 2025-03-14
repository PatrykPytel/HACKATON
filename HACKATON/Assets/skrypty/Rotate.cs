using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.SocialPlatforms;
using static UnityEngine.GraphicsBuffer;

public class Rotate : MonoBehaviour
{
    public GameObject doobrotu;
    private bool isclose = false;
    public float rotate = 45f;
    public bool test = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((isclose == true) && (Input.GetKeyDown(KeyCode.E)))
        {
            doobrotu.transform.Rotate(0, 0, rotate);
           // rotate += 45;
        }else if(test)
        {
            test = false;
            doobrotu.transform.Rotate(0, 0, rotate);
           // rotate += 45;

        }

    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            isclose = true;
            // teleport.transform.position = target.position;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isclose = false;
        }
    }
}