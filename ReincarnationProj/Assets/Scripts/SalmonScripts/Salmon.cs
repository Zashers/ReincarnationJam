using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Salmon : MonoBehaviour
{

    public float power, gravity;
    public float[] points;

    public Sprite deadSprite;

    private FadeScript fs;
    
    float x,y;

    int i = 1;
    int strokes = 0;

    bool phi = false;
    bool seed = false;
    bool plock = false; 
    bool slock = false;
    bool dead = false;
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
        if ((Input.GetKeyDown(KeyCode.UpArrow) && !dead) || (Input.GetKeyDown(KeyCode.W) && !dead)) {
            y += power * Time.deltaTime;
            GetComponent<AudioSource>().Play();
            strokes++;
        }
        if ((Input.GetKeyDown(KeyCode.LeftArrow) && !dead) || (Input.GetKeyDown(KeyCode.A) && !dead)) {
            if (i!=0) {
                i--;
                GetComponent<AudioSource>().Play();
            } 
        }
        if ((Input.GetKeyDown(KeyCode.RightArrow) && !dead) || (Input.GetKeyDown(KeyCode.D) && !dead))
        {
            if (i != points.Length-1)
            {
                i++;
                GetComponent<AudioSource>().Play();
            }
        }

        x = points[i];
        y -= gravity * Time.deltaTime;
        
        transform.position = new Vector2(x, y);

        if (transform.position.y >= 5) {
            phi = true;
        }
        if (transform.position.y <= -5.5) {
            seed = true;
            GetComponent<Animator>().SetBool("Dead", true);
          
        }
        
        if (phi && !plock) {
            plock = true;
            fs.FadeOut("Philosopher");
        }
        if (seed && !slock) {
            StartCoroutine("Seedling");
        }
    }
    IEnumerator Phi() {
        yield return new WaitForSeconds(1);
        plock = true;
        fs.FadeOut("Philosopher");
    }

    IEnumerator Seedling() {
        yield return new WaitForSeconds(1);
        slock = true;
        fs.FadeOut("Seedling");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Rock")
        {
            seed = true;
            dead = true;
            GetComponent<Animator>().SetBool("Dead", true);
            
        }
        
    }
}
