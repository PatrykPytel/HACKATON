using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wlacznik : MonoBehaviour
{
    public int licznik = 0;
    public int maxlicznik = 1;
    public Animator animator;
    private void Awake()
    {
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(licznik >= maxlicznik)
        {
            animator.SetBool("open", true);
            Debug.Log("udalo sie");
        }
    }


}
