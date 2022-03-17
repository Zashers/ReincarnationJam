using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dandelion : MonoBehaviour
{
    // Start is called before the first frame update

    public bool pop = true;
    public GameObject seed;
    public float offsetTime;
    public AnimationCurve curve;
    public GameObject landing;

    float landSpot, elapsedTime;
    float Duration = 2f;
    Vector2 startSpot;

    void Start()
    {
        pop = true;
        landing = GameObject.Find("Landing");
    }

    // Update is called once per frame
    void Update()
    {
        if (pop) {
            pop = false;
            Instantiate(seed, transform.position, Quaternion.identity);
            moveLanding();
        }
    }
    void moveLanding() {
        landSpot = Random.Range(0, 12);
        startSpot = landing.transform.position;
        while (landing.transform.position.x != landSpot)
        {
            elapsedTime += Time.deltaTime;
            float x = Mathf.Lerp(startSpot.x, landSpot, curve.Evaluate(elapsedTime / Duration));
            landing.transform.position = new Vector2(x, landing.transform.position.y);
        }
    }
}
