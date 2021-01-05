using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendInfos : MonoBehaviour
{

    static GameObject infosEcoles;
    public EcoleScriptableObject infosEcolesSO;

    private void Awake()
    {
        if (infosEcoles == null)
        {
            infosEcoles = GameObject.FindGameObjectWithTag("ScrapShower");
            infosEcoles.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            infosEcoles.SetActive(true);
            infosEcoles.GetComponent<ShowInfosEcoleManager>().ShowInfosEcole(infosEcolesSO);
        }
    }

   
}
