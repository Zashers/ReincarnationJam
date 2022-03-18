using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall : MonoBehaviour
{

    public float speed;
    private float offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset +=  speed * Time.deltaTime;
        gameObject.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0,offset));
    }
}
