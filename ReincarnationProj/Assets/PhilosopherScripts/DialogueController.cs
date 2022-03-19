using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    // Start is called before the first frame update

    public FadeScript fs;
    
    public GameObject eLeft, eDown, eUp, eRight, left, down, up, right;
    public GameObject[] leftArrows, rightArrows;
    public int[] sequence;
    
    public float noteTime;
    public int score;

    public bool missed;
    public bool yourTurn;
    bool locked = false;
    
    private AudioSource audioL;
    int i = 0;
    
    void Start()
    {
        audioL = GetComponent<AudioSource>();
        fs = GameObject.Find("Fader").GetComponent<FadeScript>();
        StartCoroutine("Dialogue");
    }

    // Update is called once per frame
    void Update()
    {
        if (missed && !locked) {
            locked = true;
            StartCoroutine("End");
        }
    }

    IEnumerator End() {
        yield return new WaitForSeconds(1);
        fs.FadeOut("Salmon");
    }
    public void Play() {
        audioL.Play();
    }
    IEnumerator Dialogue() {
        yourTurn = false;
        for (i = 0; i < sequence.Length; i++)
        {
            float x = sequence[i];
            switch (x)
            {
               
                case 1:
                    Instantiate(eLeft, new Vector2(rightArrows[0].transform.position.x, transform.position.y), left.transform.rotation);
                    break;
                case 2:
                    Instantiate(eDown, new Vector2(rightArrows[1].transform.position.x, transform.position.y), down.transform.rotation);
                    break;
                case 3:
                    Instantiate(eUp, new Vector2(rightArrows[2].transform.position.x, transform.position.y), up.transform.rotation);
                    break;
                case 4:
                    Instantiate(eRight, new Vector2(rightArrows[3].transform.position.x, transform.position.y), right.transform.rotation);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(noteTime);
        }
        yield return new WaitForSeconds(2);
        yourTurn = true;
        for (i = 0; i < sequence.Length; i++)
        {
            float x = sequence[i];
            switch (x)
            {
                case 1:
                    Instantiate(left, new Vector2(leftArrows[0].transform.position.x, transform.position.y), left.transform.rotation);
                    break;
                case 2:
                    Instantiate(down, new Vector2(leftArrows[1].transform.position.x, transform.position.y), down.transform.rotation);
                    break;
                case 3:
                    Instantiate(up, new Vector2(leftArrows[2].transform.position.x, transform.position.y), up.transform.rotation);
                    break;
                case 4:
                    Instantiate(right, new Vector2(leftArrows[3].transform.position.x, transform.position.y), right.transform.rotation);
                    break;
                default:
                    break;
            }
            yield return new WaitForSeconds(noteTime);
        }
        yield return new WaitForSeconds(5);
        fs.FadeOut("Apotheosis");
    }
}
