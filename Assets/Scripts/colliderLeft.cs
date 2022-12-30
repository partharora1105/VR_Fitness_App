using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class colliderLeft : MonoBehaviour
{
    private int count = 0;

    private string controllerSide = "Left";
    private GameObject cont;
    private ActionBasedController contScript;
    private UI uiScript;
    public GameObject UIelement;
    private float hapticIntensity = 0.4f;
    private float hapticDuration = 0.3f;

    private void Start()
    {

        cont = GameObject.Find(controllerSide + "Hand Controller");
        contScript = cont.GetComponent<ActionBasedController>();
        UIelement = GameObject.Find("Canvas");
        uiScript = UIelement.GetComponent<UI>();
    }

    void OnCollisionEnter(Collision col)
    {
        count++;
        if (uiScript.getIsGood())
        {
            contScript.SendHapticImpulse(hapticIntensity * 2, hapticDuration * 2);
        
        }
        else
        {
            contScript.SendHapticImpulse(hapticIntensity, hapticDuration);
        }
    }
    void Update()
    {

        gameObject.transform.position = GameObject.Find("LeftHand Controller").transform.position;
    }
    public int getCount()
    {
        return count;
    }

}
