using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Salmon : MonoBehaviour
{

    public float power, gravity;
    public float[] points;

    private FadeScript fs;
    
    float x,y;

    int i = 1;
    int strokes = 0;

    bool phi = false;
    bool seed = false;
    bool plock = false; 
    bool slock = false;

    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        fs = GameObject.Find("Fader").GetComponent<FadeScript>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            y += power * Time.deltaTime;
            strokes++;
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
        y -= gravity * Time.deltaTime;
        
        transform.position = new Vector2(x, y);

        if (transform.position.y >= 5) {
            phi = true;
        }

        if (phi && !plock) {
            plock = true;
            fs.FadeOut("Philosopher");
        }

        if (seed && !slock) {
            slock = true;
            fs.FadeOut("Seedling");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Rock")
        {
            seed = true; 
        }
        
    }
}
