using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectibleBehaviour : MonoBehaviour
{
    //si la bouffe fuit ou pas
    private bool isrunningAway = false;
    //position de la bouffe
    private Vector3 boufPos;
    //position player
    private Vector3 playerPos;
    //vitesse de déplacement
    public float speed;
    //trigger de détection de la bouf
    public float dangerDetectionSize;
    //walking direction
    private Vector3 randomDirection;
    //detectionRange
    public float detectionRange;
    //player
    private GameObject player;
    //indique si la bouffe a courru ou pas
    private bool hasRun = false;
    private Animator animator;

    private Vector3 nowPos;
    private Vector3 prevPos;

    // Start is called before the first frame update
    void Start()
    {
        /*BoxCollider2D dangerDetector = GetComponent<BoxCollider2D>();
        dangerDetector.radius = dangerDetectionSize;*/
        randomDirection = Vector3.zero;
        walkingFreely();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        //animator.Play("walk_fraise_back");

        nowPos = transform.position;
        prevPos = nowPos;
        animator.Play("walk_fraise_face");
    }

    // Update is called once per frame
    void Update()
    {
        boufPos = transform.position;
        playerPos = player.transform.position;

        Vector3 directionToRun = boufPos - playerPos;
        float distanceBetween = directionToRun.magnitude;
        Vector3 normalizedDrection = directionToRun / distanceBetween;

        if (distanceBetween <= detectionRange)
        {
            hasRun = false;
            isrunningAway = true;
        }

        else if(!hasRun)
        {
            hasRun = true;
            isrunningAway = false;
            Invoke("walkingFreely", 3);
        }

        if (isrunningAway)
        {
            CancelInvoke();
            runAway();
        }

        else transform.position += randomDirection * speed * Time.deltaTime;

        nowPos = transform.position;
        float TempHor = prevPos.x - nowPos.x;
        float TempVer = prevPos.y - nowPos.y;

        if(TempHor < 0 || TempHor > 0)
        {
            animator.SetBool("isProfil", true);
            animator.SetBool("isBack", false);
            animator.SetBool("isFace", false);
        }



        if (((TempHor > 0 && TempHor < 0.1f) || (TempHor < 0 && TempHor > -0.1f)) && TempVer > 0)
        {
            animator.SetBool("isFace", true);
            animator.SetBool("isBack", false);
            animator.SetBool("isProfil", false);
        }

        if (((TempHor > 0 && TempHor < 0.1f) || (TempHor < 0 && TempHor > -0.1f)) && TempVer < 0)
        {
            animator.SetBool("isFace", false);
            animator.SetBool("isBack", true);
            animator.SetBool("isProfil", false);
        }


        prevPos = nowPos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "wall")
        {
            speed *= -1;
        }
    }

    private void runAway()
    {

        Vector3 directionToRun = boufPos - playerPos;
        float distanceBetween = directionToRun.magnitude;
        Vector3 normalizedDrection = directionToRun / distanceBetween;
        transform.position += (normalizedDrection * speed * Time.deltaTime);
    }

    private void walkingFreely()
    {
        InvokeRepeating("switchDirection", 1.5f, 1.5f);
    }

    private void switchDirection()
    {
        randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
    }
}
