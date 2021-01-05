using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Application.LoadLevel("menu");
        }
    }
}
