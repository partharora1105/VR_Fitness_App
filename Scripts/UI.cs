using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI tmp;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI totalScoreUI;
    public TextMeshProUGUI streakUI;
    public GameObject leftCollider;
    public GameObject ball;
    private string color;
    public double vel = 0;
    private double sum = 0;
    private double num = 0;
    private double mean = 0;
    private int streak = 0;
    private int score;
    private int totalScore;
    private bool isGood = false;
    public GameObject ballMan;
    public ballManger bm;
    private GameObject audioFile;
    private bgAudioManager audioScript;


    // Start is called before the first frame update
    void Start()
    {
        bm = ballMan.GetComponent<ballManger>();
        audioFile = GameObject.Find("bgAudio");
        audioScript = audioFile.GetComponent<bgAudioManager>(); 
        tmp.text = "S = NA";
    }

    // Update is called once per frame
    void Update()
    {
        //tmp.text = "Score = " + score + "\n" + "Streak = " + streak + "\n" + "Color = " +color + "Total Score = " + totalScore;
        this.scoreUI.text = "+" + score;
        this.totalScoreUI.text = totalScore.ToString();
        this.streakUI.text = streak.ToString();
        if(score > 0)
        {
            this.scoreUI.color = isGood ? new Color(0, 255, 0, 255) : new Color(255, 0, 0, 255);
        }
        
    }
    public void updateVel(double vel)
    {
        this.vel = vel;
        score = (int)Mathf.Round((float)vel);
        while (score > 999) {
            score = (int) (score / (Mathf.Pow(10 , (score.ToString().Length - 3))));
            score = (int)Mathf.Round((float)score);
        }
        num++;
        sum += score;
        mean = sum / num;
        isGood = vel >= (1.5 * mean);
        totalScore += score;

    }
    public void checkStreak()
    {
        if (streak > 0 && (streak % 10 == 0.0))
        {
            bm.changeSpeed((float) ((streak + 5.0) /10.0));
            audioScript.playSpeedMusic();


        } else if (streak < 10)
        {
            bm.setBallDelay(bm.getOriginalBallDelay());
        }
        
    }
    public int buildscore()
    {
        return (int)Mathf.Round((float)vel);
    }
    public void setStreak(int streakAdder)
    {
        this.streak = streakAdder;
        checkStreak();

    }
    public int getStreak()
    {
        return this.streak;

    }
    public bool getIsGood()
    {
        return isGood;
    }
 




}

