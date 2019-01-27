using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charBehaviour : MonoBehaviour
{
    //vitesse du personnage par default
    public float speed;
    //public float initSpeed;
    //tag des éléments bouf à détecter
    public string tagToDetect;
    //score du joueur sous forme de poid
    private int _poid;
    public int poid
    {
        get
        {
            return _poid;
        }
        set
        {
            if (value < 0)
            {
                _poid = 0;
            }
            else _poid = value;
        }
    }

    //représentation du poid dans l'ui
    //public Text uiPoid;
    public Move moveScript;
    private Animator animator;

    void Start()
    {
        /*moveScript = GetComponent<Move>();
        speed = moveScript.speed;*/
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //le perso bouge vers le haut
        //transform.position += Vector3.up * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //si l'objet détecté a le bon tag
        if(collision.gameObject.tag == tagToDetect)
        {
            poid++;
            //uiPoid.text = poid.ToString();

            if(poid > 10)
            {
                animator.SetBool("isThin", false);
                animator.SetBool("isFat", false);
                animator.SetBool("isNormal", true);
            }

            if (poid > 25)
            {
                animator.SetBool("isThin", false);
                animator.SetBool("isFat", true);
                animator.SetBool("isNormal", false);
            }

            if (poid <= 10)
            {
                animator.SetBool("isThin", true);
                animator.SetBool("isFat", false);
                animator.SetBool("isNormal", false);
            }

            if (speed > 1)
            {
                speed -= speed * (poid * 2) / 100;
                moveScript.setSpeed(speed);
            }
            else moveScript.setSpeed(1);

            Destroy(collision.gameObject);
        }
    }
}
