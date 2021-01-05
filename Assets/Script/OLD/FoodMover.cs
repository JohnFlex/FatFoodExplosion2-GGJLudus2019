using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMover : MonoBehaviour
{
    //GameObjet to follow
    public GameObject Desination;
    //Timer that I don't care about real time
    private float Timerr;
    //Radius to detect distance
    public float RadiusToEscape = 10f;
    //Distance that can be travelled by an ennemy (every second)
    public float MoveDistance = 2f;
    //Random point to go to once he is too near
    private Vector3 Goto;


    // Update is called once per frame
    void Update()
    {
        //Cheching what distance we have.
        //If it's smallest get random out point
        float TpF2 = Vector2.Distance(Desination.transform.position, this.transform.position);
        if (TpF2 < RadiusToEscape*2)
        {
            if (Goto==transform.position) Goto = FindRandomDistance();
            Debug.Log(Goto);
            transform.position = Vector2.MoveTowards(this.transform.position, Goto, MoveDistance * Time.deltaTime * 2);
        }
        else if (TpF2 > RadiusToEscape/2)
        {
            transform.position = Vector2.MoveTowards(transform.position, Desination.transform.position, MoveDistance * Time.deltaTime);
        }
    }

    private Vector2 FindRandomDistance()
    {
        Vector2 TempRandomDistance = Random.insideUnitCircle * 20;
        if ((Vector2.Distance(TempRandomDistance, Desination.transform.position) < RadiusToEscape))
        {
            return TempRandomDistance;
        }
        else
        {
            FindRandomDistance();
        }
        return TempRandomDistance;
    }

//    private void Fuite()
//    {

//    }

//    private void Approche()
//    {

//    }
}
