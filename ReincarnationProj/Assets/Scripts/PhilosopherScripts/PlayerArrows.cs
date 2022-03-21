using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrows : MonoBehaviour
{
    public bool left, down, up, right;
    private bool timed, hit;
    public DialogueController dc;
    public Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        dc = GameObject.FindGameObjectWithTag("dc").GetComponent<DialogueController>();
        Anim = GameObject.Find("Philosopher").GetComponent<Animator>();

    }
    //Following statements determine if player struck the right key at the appropriate time
    // Update is called once per frame
    void Update()
    {
        if (left)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && dc.yourTurn)  
            {
                if (timed) { 
                    
                    hit = true;
                    
                    Anim.SetBool("Left", true);
                    Anim.SetBool("Up", false);
                    Anim.SetBool("Right", false);
                    Anim.SetBool("Down", false);
                    Anim.SetBool("Idle", false);
                    StartCoroutine("HitOff"); 
                }
                else {
                    dc.score++;
                    dc.red();
                }
            }
        }
        if (right)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && dc.yourTurn)
            {
                if (timed) { 
                    
                    hit = true;
                    
                    Anim.SetBool("Left", false);
                    Anim.SetBool("Up", false);
                    Anim.SetBool("Right", true);
                    Anim.SetBool("Down", false);
                    Anim.SetBool("Idle", false);
                    StartCoroutine("HitOff");
                }
                else {
                    dc.score++;
                    dc.red();
                }
            }
        }
        
        if (up)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && dc.yourTurn)
            {
                if (timed) { 
                   
                    hit = true;
                 
                    Anim.SetBool("Left", false);
                    Anim.SetBool("Up", true);
                    Anim.SetBool("Right", false);
                    Anim.SetBool("Down", false);
                    Anim.SetBool("Idle", false);
                    StartCoroutine("HitOff");
                }
                else {
                    dc.score++;
                    dc.red();
                }
            }
        }

        if (down)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && dc.yourTurn)
            {
                if (timed)
                {
                    
                    hit = true;
                
                    Anim.SetBool("Left", false);
                    Anim.SetBool("Up", false);
                    Anim.SetBool("Right", false);
                    Anim.SetBool("Down", true);
                    Anim.SetBool("Idle", false);
                    StartCoroutine("HitOff");
                }
                else
                {
                    dc.score++;
                    dc.red();
                }
            }
        }
    }

    IEnumerator HitOff() {
        yield return new WaitForSeconds(.1f);
        hit = false;
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
