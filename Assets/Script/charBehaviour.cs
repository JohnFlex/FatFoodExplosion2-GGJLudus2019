using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charBehaviour : MonoBehaviour
{
    //vitesse du personnage par default
    private float speed;
    public float initSpeed;
    //tag des éléments bouf à détecter
    public string tagToDetect;
    //score du joueur sous forme de poid
    private float poid;
    //représentation du poid dans l'ui
    public Text uiPoid;

    void Start()
    {
        speed = initSpeed;
    }

    void Update()
    {
        //le perso bouge vers le haut
        transform.position += Vector3.up * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //si l'objet détecté a le bon tag
        if(collision.gameObject.tag == tagToDetect)
        {
            Destroy(collision.gameObject);
            poid++;
            uiPoid.text = poid.ToString();

            if (speed > 1)
            {
                speed -= speed * (poid * 2) / 100;
            }
            else speed = 1;
        }
    }
}
