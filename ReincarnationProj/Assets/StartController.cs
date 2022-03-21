using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartController : MonoBehaviour
{
    public FadeScript fs;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Start1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Start1() {
        yield return new WaitForSeconds(8);

        fs.FadeOut("Title");
    }
}
