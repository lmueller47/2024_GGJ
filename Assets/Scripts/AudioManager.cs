using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip repeat;
    public AudioClip intro;
    private AudioSource audi;
    private float waitTime;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = intro.length;
        StartCoroutine(Loop());
        audi = GetComponent<AudioSource>();
    }

    public IEnumerator Loop()
    {
        yield return new WaitForSeconds(waitTime);
        audi.Stop();
        audi.clip = repeat;
        audi.loop = true;
        audi.Play();
    }
}
