using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ballScript : MonoBehaviour
{
    private float moveSpeed = 10.0f;
    private double vel = 0.0;
    private float x;
    public GameObject UIelement;
    private GameObject leftCont;
    private ActionBasedController leftScript;
    private bool isDestroyed = false;
    private UI uiScript;
    private MeshRenderer mr;
    private ballScript bs;
    public XRController xr;
    private GameObject AudioElement;
    private AudioSource audioFile;
    private float audioVol = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

        //x = Random.Range(-2.0f, 2.0f);
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        UIelement = GameObject.Find("Canvas");
        uiScript = UIelement.GetComponent<UI>();
        mr = gameObject.GetComponent<MeshRenderer>();
        bs = gameObject.GetComponent<ballScript>();

        leftCont = GameObject.Find("LeftHand Controller");
        leftScript = leftCont.GetComponent<ActionBasedController>();

        AudioElement = GameObject.Find("bgAudioInitial");
        audioFile = gameObject.GetComponent<AudioSource>();


    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * -(moveSpeed) * Time.deltaTime);
        

    }
   
    void OnCollisionEnter(Collision col)
    {
        vel = col.relativeVelocity.magnitude * 100000000;
        if( vel != 0 && !isDestroyed)
        {
            mr.enabled = false;
            bs.enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
            uiScript.updateVel(vel);
            uiScript.setStreak(uiScript.getStreak() + 1);
            vel = 0.0;
            isDestroyed = true;
            if(uiScript.getIsGood())
            {
                audioFile.PlayOneShot(audioFile.clip, audioVol * 2);
            } else
            {
                audioFile.PlayOneShot(audioFile.clip, audioVol);
            }
            
            Invoke("destBall", 0.4f);


        } else
        {
            uiScript.setStreak(0);
        }
        
    }

    
    void destBall()
    {
        gameObject.SetActive(false);
    }
    public double getVel()
    {
        return vel;
    }
}
