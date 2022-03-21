using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    // Start is called before the first frame update

    public FadeScript fs;
    public Animator phAnim;
    public Animator inAnim;


    public GameObject eLeft, eDown, eUp, eRight, left, down, up, right, red;
    public GameObject[] leftArrows, rightArrows;
    public int[] sequence1,sequence2, sequence3;

    private int[] sequence;
    public float noteTime;
    public int score;

    public bool missed;
    public bool yourTurn;
    bool locked = false;
    bool started = false;
    
    private AudioSource audioL;
    private Music ms;
    int i = 0;
    int j = 0;

    float startTime;
    void Start()
    {
        ms = GameObject.Find("Music").GetComponent<Music>();
       // startTime = ms.beatTime;
        audioL = GetComponent<AudioSource>();
        fs = GameObject.Find("Fader").GetComponent<FadeScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float bruh = Mathf.Round((Time.time) * 100)/100;
        if ((bruh % .66 <= 0.1f) && !started)
        {
            StartCoroutine("Dialogue");
            started = true;
        }
        if ((score > 3) && !locked) {
            locked = true;
            StartCoroutine("End");
        }
    }

    IEnumerator End() {
        yield return new WaitForSeconds(1);
        fs.FadeOut("Salmon");
    }
   
    IEnumerator Dialogue() {
        for (j = 0; j < 3; j++)
        {
            if (j == 0)
            {
                sequence = sequence1;
            }
            else if (j == 1) {
                sequence = sequence2;
            }
            else if (j == 2)
            {
                sequence = sequence3;
            }
            for (i = 0; i < sequence.Length; i++)
            {
                yourTurn = false;
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
   
            yield return new WaitForSeconds(3.96f);
            inAnim.SetBool("Idle", true);
            inAnim.SetBool("Left", false);
            inAnim.SetBool("Up", false);
            inAnim.SetBool("Right", false);
            inAnim.SetBool("Down", false);
            for (i = 0; i < sequence.Length; i++)
            {
                yourTurn = true;
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
     
            yield return new WaitForSeconds(3.96f);
            phAnim.SetBool("Idle", true);
            phAnim.SetBool("Left", false);
            phAnim.SetBool("Up", false);
            phAnim.SetBool("Right", false);
            phAnim.SetBool("Down", false);
            yourTurn = true;
        }
        yield return new WaitForSeconds(5);
        fs.FadeOut("Apotheosis");
    }
}
