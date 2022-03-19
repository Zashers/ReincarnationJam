using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public Dandelion dand;
    
    public float gravity, speed;
    public GameObject target;
    private Vector3 startPos;

    public AnimationCurve curve;
  
    float x, y;
    float wind, oldWind, newWind;
    float desiredTime = 1;
    float elapsedTime;

    bool move = false;
    bool locked = false;
    bool stop = false;
    void Start()
    {
        StartCoroutine("Wind");
        startPos = transform.position;
        y = transform.position.y;
        dand = GameObject.FindGameObjectWithTag("Dandelion").GetComponent<Dandelion>();
        target = GameObject.FindGameObjectWithTag("target");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != target.transform.position && !locked) {
            elapsedTime += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, target.transform.position, curve.Evaluate(elapsedTime / desiredTime));
            x = transform.position.x;
            y = transform.position.y;
            move = false;
            }
        else {
            locked = true;
            move = true;
        }

        if (move && !stop)
        {
            y -= gravity * (Time.timeSinceLevelLoad - dand.offsetTime) * .001f;
            x += (Input.GetAxis("Horizontal") * speed * Time.deltaTime) + wind;
            x = Mathf.Clamp(x, -5.7f, 5.3f);
            transform.position = new Vector2(x, y);
        }
    }

    IEnumerator Wind() {
        newWind = Random.Range(-.003f, .003f);
        float t = Random.Range(.5f, 2);
        wind = Mathf.Lerp(oldWind, newWind, curve.Evaluate(t));
        yield return new WaitForSeconds(t+.1f);
        oldWind = newWind;
        StartCoroutine("Wind");    
    }

   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "landing")
        {
            dand.change = true;
            stop = true;
        }
        else if (other.gameObject.tag == "Water")
        {
            dand.offsetTime = Time.timeSinceLevelLoad;
            dand.pop = true;
            Destroy(gameObject);
        }
    }

   
}
