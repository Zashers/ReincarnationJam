using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    private DialogueController dc;
    

    bool timed;
    float y;
    void Start()
    {
        dc = GameObject.FindGameObjectWithTag("dc").GetComponent<DialogueController>();
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        y += speed * .1f * Time.deltaTime; 
        transform.position = new Vector2(transform.position.x, y); //Controls upward movement of arrow and initial position
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Box")
        {
            dc.missed = true;
            print("bruh");
        }
    }
}
