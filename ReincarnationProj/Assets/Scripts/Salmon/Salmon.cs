using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salmon : MonoBehaviour
{

    public float power, gravity;
    public float[] points;

    float x,y;

    int i = 1;
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            y += power;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (i!=0) {
                i--;
            } 
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (i != points.Length-1)
            {
                i++;
            }
        }

        x = points[i];
        y -= gravity * .001f;
        
        transform.position = new Vector2(x, y);
    }
}
