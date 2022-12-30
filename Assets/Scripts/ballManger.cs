using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ballManger : MonoBehaviour
{
    public GameObject ball;
    public GameObject ballLeftPos;
    public GameObject ballRighttPos;
    private GameObject ballPos;
    private float originalballDelay = 0.7f;
    private float ballDelay;
    // Start is called before the first frame update
    void Start()
    {
        ballDelay = originalballDelay;
        StartCoroutine(createBall());
        
    }

    // Update is called once per frame
    void Update()
    {
        //collisionManager ballScript = ball.GetComponent<collisionManager>();
    }

    IEnumerator createBall()
    {
        yield return new WaitForSeconds(ballDelay);
       
        ballPos = (Random.Range(-2.0f, 2.0f) <= 0 ) ? ballLeftPos : ballRighttPos;
        Instantiate(ball.GetComponent<Rigidbody>(), ballPos.GetComponent<Transform>().position , ballPos.GetComponent<Transform>().rotation);
        StartCoroutine(createBall());


    }

    public void changeSpeed(float multiplier)
    {
        this.ballDelay /= multiplier;
       
    }
    public float getOriginalBallDelay()
    {
        return originalballDelay;
    }
    public void setBallDelay(float ballDelay)
    {
        this.ballDelay = ballDelay;
    }
}
