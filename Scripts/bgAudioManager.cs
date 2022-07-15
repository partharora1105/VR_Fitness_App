using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgAudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource bGmusic;
    [SerializeField]
    private AudioSource initial;
    [SerializeField]
    private AudioSource speed;

    private float audioVol = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        //Invoke("playInitial", 0);
        Invoke("playBGmusic", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playBGmusic()
    {
        bGmusic.PlayOneShot(bGmusic.clip, audioVol * 2);
    }
    public void playInitial()
    {
        initial.PlayOneShot(initial.clip, audioVol * 2);
    }
    public void playSpeedMusic()
    {
        speed.PlayOneShot(speed.clip, audioVol * 2);
        Debug.Log("played");
    }
}
