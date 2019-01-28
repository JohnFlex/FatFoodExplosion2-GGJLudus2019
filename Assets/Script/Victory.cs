using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public charBehaviour charScript;
    public UIScript timer;
    private int ennemies;
    private GameObject[] boufs;

    // Start is called before the first frame update
    void Start()
    {
        boufs = GameObject.FindGameObjectsWithTag("bouf");
        ennemies = boufs.Length;
    }

    void Update()
    {
        
        if(charScript.poid >= ennemies && timer.timing >= 0)
        {
            timer.SendMessage("win");
        }
    }
}
