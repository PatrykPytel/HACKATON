using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class LaserInteraction : MonoBehaviour
{
   // [SerializeField] private GameObject player;
    public Animator animator;
    public Animator playeranim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void smierc()
    {
        SceneManager.LoadScene("GameOver");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with: " + collision.tag); // Log the tag of the collided object

        if (collision.CompareTag("Player"))
        {
            playeranim.SetBool("dying", true);
            Invoke("smierc", 1.5f);
         //   SceneManager.LoadScene("GameOver");
           // playeranim.SetBool("dying", true);
           // playeranim.SetBool("dying", true);

            //Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Button"))
        {
            animator.SetBool("open",true);
        }
    }
}
