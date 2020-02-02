using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public SoundManager Instance;
    public AudioClip Intro, mainTheme;
    AudioSource audioS;
    private void OnEnable()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        audioS = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }


    void Start()
    {
        
        StartCoroutine(playEngineSound());
    }

    IEnumerator playEngineSound()
    {
        audioS.clip = Intro;
        audioS.Play();
        yield return new WaitForSeconds(audioS.clip.length -2);
        audioS.clip = mainTheme;
        GetComponent<AudioSource>().loop = true;
        audioS.Play();
    }
}
