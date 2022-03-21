using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Music : MonoBehaviour
{
    // Start is called before the first frame update
    static Music instance;
    public float beatTime;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Apotheosis") {
            GetComponent<AudioSource>().loop = false;
        }
        beatTime = Time.time;
    }
}
