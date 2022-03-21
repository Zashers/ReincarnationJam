using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndController : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject phi;
    public SpriteRenderer white,black;
    public GameObject text;
    public float outStep, outStepTime,inStep,inStepTime;
    
    bool end = false;
    bool locked = false;
    void Start()
    {
       
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn() {
        if (black.color.a > 0)
        {
            black.color -= new Color(0, 0, 0, inStep);
            yield return new WaitForSeconds(inStepTime);
            StartCoroutine(FadeIn());
        }
        StartCoroutine("End");
    }
    IEnumerator End() {
        
        
        yield return new WaitForSeconds(3);

        phi.GetComponent<Animator>().enabled = true;
        end = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (end && !locked){
            locked = true;
            StartCoroutine("Fade");
        }
    }

    IEnumerator Fade() {
        if (white.color.a < 1)
        {
            white.color += new Color(0, 0, 0, outStep);
            yield return new WaitForSeconds(outStepTime);
            StartCoroutine(Fade());
        }
        else
        {
            yield return new WaitForSeconds(2);

            text.SetActive(true);
        }

    }
}
