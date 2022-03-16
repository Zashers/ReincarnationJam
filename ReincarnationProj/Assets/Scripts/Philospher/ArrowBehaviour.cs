using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
   
    

    bool timed;
    float y;
    void Start()
    {
        
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        y += speed * .001f; 
        transform.position = new Vector2(transform.position.x, y); //Controls upward movement of arrow and initial position
    }
}
