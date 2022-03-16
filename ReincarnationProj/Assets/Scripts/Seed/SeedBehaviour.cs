using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public Dandelion dand;
    
    public float gravity, speed;
       
    float y = 0;
    float x = 0;
    void Start()
    {
        y = 3.33f;
        dand = GameObject.FindGameObjectWithTag("Dandelion").GetComponent<Dandelion>();
    }

    // Update is called once per frame
    void Update()
    {
        
        y -= gravity * (Time.time - dand.offsetTime) * .001f;
        x += Input.GetAxis("Horizontal")*speed*Time.deltaTime;
        transform.position = new Vector2(x, y);

    }

    private void OnTriggerEnter(Collider other)
    {
        dand.offsetTime = Time.time;
        dand.pop = true;
        Destroy(gameObject);
    }
}
