using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {
    //Aim : Letting the player Dash

    public float forceDash = 2f;
    public GameObject DirectionDash;
    private float TimerBeforeRedash = 5f;
    private bool CanDash;

	// Use this for initialization
	void Start () {
        CanDash = true;
		
	}
	
	// Update is called once per frame
	void Update () {
        //On press "Dash" player dash
        if (Input.GetButton("Dash")&&CanDash)
        {
            for (int i = 0; i < forceDash*2; i++)
            {
                GetComponent<Rigidbody2D>().AddForce((DirectionDash.transform.position - this.GetComponentInParent<Transform>().transform.position) * forceDash, ForceMode2D.Impulse);

            }
            GetComponent<Rigidbody2D>().AddForce((DirectionDash.transform.position-this.GetComponentInParent<Transform>().transform.position) * forceDash, ForceMode2D.Impulse);
            CanDash = false;
            TimerBeforeRedash = 5f;
        }

        TimerBeforeRedash = TimerBeforeRedash - Time.deltaTime;
        if (TimerBeforeRedash<0)
        {
            CanDash = true;
        }
        

    }
}
