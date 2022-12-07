using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour 
{
//check bots and if bool broken = false then increase score by 1
    public Text fixedText;
    public int fixedValue;

    public GameObject bot1;
    public GameObject bot2;
    public GameObject bot3;
    public GameObject bot4;
    public GameObject ruby;

    private int check1;
    private int check2;
    private int check3;
    private int check4;
    private int check5;
    private int check6;
    private int check7;

    public Text wintext;

    public AudioSource backgroundmusic;
    public AudioClip victory;
    public AudioClip defeat;
    public AudioClip BGmusic;
    

    // Start is called before the first frame update
    void Start()
    {
        fixedValue = 0;
        check1 = 0;
        check2 = 0;
        check3 = 0;
        check4 = 0;
        check5 = 0;
        check6 = 0;
        check7 = 0;
        wintext.text = "";
        backgroundmusic.PlayOneShot(BGmusic);
        backgroundmusic.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        fixedText.text = "Bots Fixed: " + fixedValue.ToString();
        
        if (bot1.GetComponent<EnemyController>().broken == false && check1 == 0){
            fixedValue += 1;
            check1 = 1;
        }
        if (bot2.GetComponent<EnemyController>().broken == false && check2 == 0){
            fixedValue += 1;
            check2 = 1;
        }
        if (bot3.GetComponent<HardEnemyController>().broken == false && check3 == 0){
            fixedValue += 1;
            check3 = 1;
        }
        if (bot4.GetComponent<HardEnemyController>().broken == false && check4 == 0){
            fixedValue += 1;
            check4 = 1;
        }
        if(fixedValue == 4 && check5 == 0)
        {
            wintext.text = ("Talk to Jambi to continue");
            backgroundmusic.loop = false;
            backgroundmusic.Stop();
            backgroundmusic.clip = victory;
            backgroundmusic.Play();
            check5 = 1;
        }
        if(ruby.GetComponent<RubyController>().health == 0 && check6 == 0){
            wintext.text = ("You died, Press R to restart");
            backgroundmusic.loop = false;
            backgroundmusic.Stop();
            backgroundmusic.clip = defeat;
            backgroundmusic.Play();
            check6 = 1;
        }
        if(fixedValue == 4 && check7 == 0){
            Scene scene = SceneManager.GetActiveScene();
            if (scene.name == "Scene2")
            {
                wintext.text = ("Mission Complete! Good job press R to restart");
                backgroundmusic.loop = false;
                backgroundmusic.Stop();
                backgroundmusic.clip = victory;
                backgroundmusic.Play();
                check7 = 1;
            }
        }
    }
    
    
}
//wintext.text = ("Mission Complete! Good job");
