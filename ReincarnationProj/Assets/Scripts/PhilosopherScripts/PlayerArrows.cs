using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrows : MonoBehaviour
{
    public bool left, down, up, right;
    private bool timed, hit;
    private DialogueController dc;
    // Start is called before the first frame update
    void Start()
    {
        dc = GameObject.FindGameObjectWithTag("dc").GetComponent<DialogueController>();
    }
    //Following statements determine if player struck the right key at the appropriate time
    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))  
            {
                if (timed) { 
                    dc.score++;
                    hit = true;
                    dc.Play();
                }
                else {
                    dc.missed = true; 
                }
            }
        }
        if (right)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (timed) { 
                    dc.score++;
                    hit = true;
                    dc.Play();
                }
                else {
                    dc.missed = true;
                }
            }
        }
        
        if (up)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (timed) { 
                    dc.score++;
                    hit = true;
                    dc.Play();
                }
                else {
                    dc.missed = true;
                }
            }
        }

        if (down)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (timed)
                {
                    dc.score++;
                    hit = true;
                    dc.Play();
                }
                else
                {
                    dc.missed = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timed = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (hit) {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        timed = false;
    }
}
