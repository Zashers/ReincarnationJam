using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public GameObject A1, A2, A3;
    
    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(0, 2);
        if (x == 0)
        {
            A1.SetActive(true);
        }
        else if (x == 1)
        {
            A2.SetActive(true);
        }
        else if (x == 2) {
            A3.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
