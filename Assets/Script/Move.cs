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
    Vector2 StorageInput;
    public float speed = 100f;
    //Object that changes position depending on input
    public GameObject ObjectToChangePosition;
    public Rigidbody2D RB;
    private Animator animator;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //Changing the position on changing axes
         StorageInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(Input.GetAxis("Vertical") <= 0)
        {
            animator.SetBool("isFace", true);
            animator.SetBool("isBack", false);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            animator.SetBool("isFace", false);
            animator.SetBool("isBack", true);
        }
        
        //this.transform.position = (this.transform.position) + (new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed * Time.deltaTime);

        //Changing the position of the object
       // if (Input.GetAxis("Horizontal") > 0.1f) ObjectToChangePosition.transform.localPosition = Vector3.right*2;
       // if (Input.GetAxis("Horizontal") < -0.1f) ObjectToChangePosition.transform.localPosition = Vector3.left * 2;
       // if (Input.GetAxis("Vertical") > 0.1f) ObjectToChangePosition.transform.localPosition = Vector3.up * 2;
       // if (Input.GetAxis("Vertical") < -0.1f) ObjectToChangePosition.transform.localPosition = Vector3.down * 2;
       // if ((Input.GetAxis("Vertical") == 0) && (Input.GetAxis("Horizontal") == 0)) ObjectToChangePosition.transform.localPosition = Vector3.zero;


        ObjectToChangePosition.transform.localPosition = RB.velocity*0.8f;
    }
    private void FixedUpdate()
    {
        RB.AddForce(StorageInput * 3, ForceMode2D.Impulse);
    }

    public void setSpeed(float sped)
    {
        speed = sped;
    }
}
