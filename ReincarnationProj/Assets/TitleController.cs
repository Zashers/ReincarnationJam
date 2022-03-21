using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleController : MonoBehaviour
{
    // Start is called before the first frame update

    public FadeScript fs;
    void Start()
    {
        StartCoroutine("Change");
    }


    IEnumerator Change() {
        yield return new WaitForSeconds(3);
        fs.FadeOut("Seedling");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
