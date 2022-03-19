using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    bool locked;
    public bool change = false;

    void Start()
    {
        pop = true;
        landing = GameObject.Find("Rock");
    }

    // Update is called once per frame
    void Update()
    {
        if (pop) {
            pop = false;
            Instantiate(seed, transform.position, Quaternion.identity);
            landSpot = Random.Range(-5.5f, 5.5f);
            startSpot = landing.transform.position;
            elapsedTime = 0;
        }
        if (landing.transform.position.x != landSpot)
        {       
            elapsedTime += Time.deltaTime;
            float x = Mathf.Lerp(startSpot.x, landSpot, curve.Evaluate(elapsedTime / Duration));
            landing.transform.position = new Vector2(x, landing.transform.position.y);
        }
        if (change) {
            StartCoroutine("Change");
        }
    }

    IEnumerator Change() {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Salmon");
    }
}
