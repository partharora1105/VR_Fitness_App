using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowManager : MonoBehaviour
{
    public GameObject arrow1;
    public GameObject arrow2;
    public GameObject arrow3;
    public GameObject arrow4;
    public GameObject arrow5;
    public GameObject arrow6;
    public GameObject[] arrows = new GameObject[6];
    private float arrowDelay = 0.15f;

    private void Awake()
    {
        arrows[0] = arrow1;
        arrows[1] = arrow2;
        arrows[2] = arrow3;
        arrows[3] = arrow4;
        arrows[4] = arrow5;
        arrows[5] = arrow6;
        
    }
    void Start()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            arrows[i].SetActive(false);
        }
        Invoke("arrowRound", 1.0f);
       
    }

    void Update()
    {
       
    }
 
    void arrowRound()
    {
        
        for (int i = 0; i < arrows.Length; i++) {
            StartCoroutine(changeState(arrows[i], arrowDelay * i));
        }
        for (int i = 0; i < arrows.Length; i++)
        {
            StartCoroutine(changeState(arrows[i], arrowDelay * (arrows.Length + 1)));
        }
        Invoke("arrowRound", ((arrows.Length * arrowDelay) + 0.5f));

    }
    IEnumerator changeState(GameObject arrow, float delay)
    {
        yield return new WaitForSeconds(delay);
        arrow.SetActive(!arrow.activeSelf);
       

    }

}
