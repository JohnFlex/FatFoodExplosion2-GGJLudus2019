using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public float timing;
    public Text timer;
    private float minutes;
    private float seconds;
    private bool playMode = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(playMode)
        seconds =Mathf.Floor(timing % 60);
        minutes = Mathf.Floor(timing / 60);
        timing -= Time.deltaTime;
        /*
        if(seconds < 10) timer.text = minutes.ToString() + ": 0" + seconds.ToString();
        else if(seconds < 10) timer.text = minutes.ToString() + ":" + seconds.ToString();*/
        timer.text = minutes.ToString() + ":" + seconds.ToString();

        if(timing <= 0)
        {
            Application.LoadLevel("menu");
        }
    }

    public void win()
    {
        playMode = false;
        timer.text = "YOU WIN";
    }
}
