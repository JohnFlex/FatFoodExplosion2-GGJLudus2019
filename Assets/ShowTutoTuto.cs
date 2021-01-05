using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowTutoTuto : MonoBehaviour
{
    public GameObject TutoPlaceHolder;
    public TextMeshProUGUI text;
    [TextArea]
    public string toShow;
    bool coroutineEnded = false;


    
    

    // <summary>
    /// Shows a string char by char
    /// </summary>
    /// <param name="dialogLine">The string to show</param>
    /// <returns></returns>
    IEnumerator ShowDialog(string dialogLine)
    {
        text.text = "";
        foreach (char letter in dialogLine.ToCharArray())
        {
            text.text += letter;
            yield return null;
        }
        coroutineEnded = true;
    }

    private void Update()
    {
        if (Input.anyKeyDown && coroutineEnded)
        {
            TutoPlaceHolder.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TutoPlaceHolder.SetActive(true);
            StartCoroutine(ShowDialog(toShow));
        }
    }
}
