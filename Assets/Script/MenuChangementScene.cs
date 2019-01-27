using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChangementScene : MonoBehaviour
{
    public void changeMenuScene(string nameScene)
    {
        Application.LoadLevel(nameScene);
    }

    public void quitteApplication()
    {
        Application.Quit();
        Debug.Log("On quitte l'application !");
    }
}
