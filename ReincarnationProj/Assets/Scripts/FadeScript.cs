using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{

    public bool fadeIn, fadeOut;

    public SpriteRenderer black;
    public float inStep, inStepTime, outStep, outStepTime;
    private SceneController sc;
    // Start is called before the first frame update
    void Start()
    {
        black.color = new Color(black.color.r, black.color.b, black.color.g, 1);
        sc = GameObject.Find("SceneManager").GetComponent<SceneController>();
        FadeIn();
    }

    // Update is called once per frame
    void Update()
    {

    }

   public void FadeIn() {
        StartCoroutine(fadeInCoroutine());
    }

    IEnumerator fadeInCoroutine() {
        if (black.color.a > 0)
        {
            black.color -= new Color(0, 0, 0, inStep);
            yield return new WaitForSeconds(inStepTime);
            StartCoroutine(fadeInCoroutine());
            print(black.color.a);
        }
        //print(black.color.a);
    }

    public void FadeOut(string scene)
    {
        StartCoroutine(fadeOutCoroutine(scene));
    }

    IEnumerator fadeOutCoroutine(string scene)
    {
        if (black.color.a < 1)
        {
            black.color += new Color(0, 0, 0, outStep);
            yield return new WaitForSeconds(outStepTime);
            StartCoroutine(fadeOutCoroutine(scene));
        }
        else
        {
            sc.LoadScene(scene);
        }
    }
}
