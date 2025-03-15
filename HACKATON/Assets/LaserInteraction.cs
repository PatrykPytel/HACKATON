using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class LaserInteraction : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision with: " + collision.tag); // Log the tag of the collided object

        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("Button"))
        {
            animator.SetBool("open",true);
        }
    }
}
