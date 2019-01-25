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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Changing the position on changing axes
        this.transform.position =(this.transform.position) + (new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0) * speed * Time.deltaTime);
    }
}
