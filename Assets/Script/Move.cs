using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    /**
     * Aim : Letting the player move
     * Input : The input of the player. Using the axis of the keyboard or the controller
     * Output : The move of the player on the screen.
     * 
     */
    //The default speed for a sprite
    public float speed = 100f;
    //Object that changes position depending on input
    public GameObject ObjectToChangePosition;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Changing the position on changing axes
        this.transform.position =(this.transform.position) + (new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0) * speed * Time.deltaTime);
        //Changing the position of the object
        if (Input.GetAxis("Horizontal") > 0.1f) ObjectToChangePosition.transform.localPosition = Vector3.right*2;
        if (Input.GetAxis("Horizontal") < -0.1f) ObjectToChangePosition.transform.localPosition = Vector3.left * 2;
        if (Input.GetAxis("Vertical") > 0.1f) ObjectToChangePosition.transform.localPosition = Vector3.up * 2;
        if (Input.GetAxis("Vertical") < -0.1f) ObjectToChangePosition.transform.localPosition = Vector3.down * 2;
        if ((Input.GetAxis("Vertical") == 0) && (Input.GetAxis("Horizontal") == 0)) ObjectToChangePosition.transform.localPosition = Vector3.zero;

        
    }

    public void setSpeed(float sped)
    {
        speed = sped;
    }
}
