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
        if(collision.tag == "Player")
        {
            SceneManager.LoadScene("GameOver");
            Destroy(player);
        }else if(collision.tag == "Button")
        {
            Debug.Log("dziaka");
        }
    }
}
