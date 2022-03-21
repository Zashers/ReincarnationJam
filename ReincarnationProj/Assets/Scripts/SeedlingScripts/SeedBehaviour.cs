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

    public float rotSpeed = 0;
    float x, y;
    float wind, oldWind, newWind;
    float desiredTime = 1;
    float elapsedTime;

    bool move = false;
    bool locked = false;
    bool stop = false;

    float Timetotal;
    int iteration = 0;
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
            y -= gravity * (Time.timeSinceLevelLoad - dand.offsetTime) * .001f * Time.smoothDeltaTime;
            x += ((Input.GetAxis("Horizontal") * speed) + wind) * Time.smoothDeltaTime;
            x = Mathf.Clamp(x, -5.7f, 5.3f);
            transform.position = new Vector2(x, y);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            rotSpeed = rotSpeed + 0.05f;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rotSpeed = rotSpeed - 0.05f;
        }

        if (Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.LeftArrow) == false) {
            if (rotSpeed > 0)
            {
                rotSpeed = rotSpeed - 0.05f;
            }
            else if (rotSpeed < 0) {
                rotSpeed = rotSpeed + 0.05f;
            }
        }
        rotSpeed = Mathf.Clamp(rotSpeed, -23, 23);
        transform.rotation = Quaternion.Euler(0, 0, rotSpeed);
    }

    IEnumerator Wind() {
        newWind = Random.Range(-.5f, .5f);
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
