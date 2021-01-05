using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Intro : MonoBehaviour
{
    public TextMeshProUGUI tmp1;
    public TextMeshProUGUI tmp2;
    Coroutine coroutine;


    private void Awake()
    {
        coroutine = StartCoroutine(ShowDialog("Bienvenue au Salon Siep... En ligne !"));
        Invoke("TheAfter", 1f);
    }

    void TheAfter()
    {
        tmp1 = tmp2;
        coroutine = StartCoroutine(ShowDialog("Commencez par utiliser les flèches pour vous déplacer"));
        Invoke("CloseTab", 3f);
    }

    /// <summary>
    /// Shows a string char by char
    /// </summary>
    /// <param name="dialogLine">The string to show</param>
    /// <returns></returns>
    IEnumerator ShowDialog(string dialogLine)
    {
        tmp1.text = "";
        foreach (char letter in dialogLine.ToCharArray())
        {
            tmp1.text += letter;
            yield return null;
        }
        EndCoroutine(dialogLine);
    }

    void EndCoroutine(string line)
    {
        StopCoroutine(coroutine);
        tmp1.text = line;
    }

    void CloseTab() {
        gameObject.SetActive(false);
    }

}
