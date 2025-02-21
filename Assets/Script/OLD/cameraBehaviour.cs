﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehaviour : MonoBehaviour
{
    private Vector3 persoPos;
    private Vector3 camPos;
    public float lerpSpeed;
    public Vector3 offsetPos;
    public GameObject ObjectToFollow;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("persoPos = " + persoPos);
        //Debug.Log(camPos);
        cameraMove(persoPos);
        camPos = transform.position;
        persoPos = ObjectToFollow.transform.position;
    }

    /**
     * Donne un mouvement fluide à la caméra
     * params:
     * - trackingPos = position de l'objet traqué
     */
    private void cameraMove(Vector3 trackingPos)
    {
        Vector3 prevPos = camPos;
        Vector3 newPos = Vector3.Lerp(prevPos, trackingPos + offsetPos, lerpSpeed * Time.deltaTime);
        camPos = newPos;
        transform.position = camPos;
     }
}
