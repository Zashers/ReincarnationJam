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
    float y;
    void Start()
    {
        dc = GameObject.FindGameObjectWithTag("dc").GetComponent<DialogueController>();
        y = transform.position.y;
        if (left){
            target = GameObject.FindGameObjectWithTag("ExLeft");
            
        }
        else if (down) {
            target = GameObject.FindGameObjectWithTag("ExDown");
        }
        else if (up) {
            target = GameObject.FindGameObjectWithTag("ExUp");
        }
        else if (right) {
            target = GameObject.FindGameObjectWithTag("ExRight");
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        y += speed * .1f * Time.deltaTime;
        transform.position = new Vector2(transform.position.x, y);
        if (transform.position.y >= target.transform.position.y) {
            
            dc.Play();
            Destroy(gameObject);
        }
    }
}
