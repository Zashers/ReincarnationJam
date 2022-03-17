using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Salmon : MonoBehaviour
{

    public float power, gravity;
    public float[] points;

    float x,y;

    int i = 1;
    int strokes = 0;
    // Start is called before the first frame update
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            y += power;
            strokes++;
            if ((strokes % 2) == 0) {
                transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
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
            StartCoroutine("LoadPh");
        }
    }

    IEnumerator LoadSeed() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Seedling");
    }

    IEnumerator LoadPh()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Philosopher");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Rock")
        {
            StartCoroutine("LoadSeed");
        }
        
    }
}
