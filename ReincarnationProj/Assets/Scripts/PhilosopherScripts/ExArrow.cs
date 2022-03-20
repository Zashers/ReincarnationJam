using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class ExArrow : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public bool left, down, up, right;
    

    private GameObject target;
    public DialogueController dc;
    public Animator Anim;
    string dir;
    float y;
    void Start()
    {
        Anim = GameObject.Find("Interlocutor").GetComponent<Animator>();
        dc = GameObject.FindGameObjectWithTag("dc").GetComponent<DialogueController>();
        y = transform.position.y;
        if (left){
            target = GameObject.FindGameObjectWithTag("ExLeft");
            dir = "left";
        }
        else if (down) {
            target = GameObject.FindGameObjectWithTag("ExDown");
            dir = "down";
        }
        else if (up) {
            target = GameObject.FindGameObjectWithTag("ExUp");
            dir = "up";
        }
        else if (right) {
            target = GameObject.FindGameObjectWithTag("ExRight");
            dir = "right";
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        y += speed * .1f * Time.deltaTime;
        transform.position = new Vector2(transform.position.x, y);
        if (transform.position.y >= target.transform.position.y) {
            switch (dir)
            {
                case "left":
                Anim.SetBool("Left", true);
                Anim.SetBool("Up", false);
                Anim.SetBool("Right", false);
                Anim.SetBool("Down", false);
                Anim.SetBool("Idle", false);
                    break;
                case "right":
                Anim.SetBool("Left", false);
                Anim.SetBool("Up", false);
                Anim.SetBool("Right", true);
                Anim.SetBool("Down", false);
                Anim.SetBool("Idle", false);
                    break;
                case "down":
                Anim.SetBool("Left", false);
                Anim.SetBool("Up", false);
                Anim.SetBool("Right", false);
                Anim.SetBool("Down", true);
                Anim.SetBool("Idle", false);
                    break;
                case "up":
                Anim.SetBool("Left", false);
                Anim.SetBool("Up", true);
                Anim.SetBool("Right", false);
                Anim.SetBool("Down", false);
                Anim.SetBool("Idle", false);
                    break;
                default:
                    break;
            }
            dc.Play();
            Destroy(gameObject);
        }
    }
}
