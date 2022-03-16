using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dandelion : MonoBehaviour
{
    // Start is called before the first frame update

    public bool pop = true;
    public GameObject seed;
    public float offsetTime;
    void Start()
    {
        pop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (pop) {
            pop = false;
            Instantiate(seed, transform.position, Quaternion.identity);
        }
    }
}
