using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowInfosEcoleManager : MonoBehaviour
{
    
    public TextMeshProUGUI tmpInfos;
    Coroutine coroutine;
    EcoleScriptableObject obj;

    public void ShowInfosEcole(EcoleScriptableObject ecoleScriptableObject)
    {
        obj = ecoleScriptableObject;
        string line = "Bonjour et bienvenue à " + ecoleScriptableObject.Nom + ". Nous sommes situés à " + ecoleScriptableObject.Lieu + " et nos prochaines portes ouvertes se déroulent le " + ecoleScriptableObject.DateJPO;
        coroutine = StartCoroutine(ShowDialog(line));
    }
    
    public void MoreInfos()
    {

        string line = "Bien sur ! " + obj.Description;
        coroutine = StartCoroutine(ShowDialog(line));
    }

    public void Brochure()
    {
        string line = "Je vous l'envoie de suite ! Le téléchargement se lance dans 3... 2... 1...";
        coroutine = StartCoroutine(ShowDialog(line));
    }

    public void JPO()
    {
        string line = "C'est très simple ! Il suffit d'entrer votre mail dans la case qui s'affiche juste à côté. Ensuite, on vous recontacte très rapidement !";
        coroutine = StartCoroutine(ShowDialog(line));
    }
    
    public void Communication()
    {
        string line = "Il y a en ce moment " + obj.NombreDePresentateurs.ToString() + " sur le stand dont " + obj.NombreDePresentateurs.ToString() + " sont déjà en communication. Je vous met en communication dès que possible !";
        coroutine = StartCoroutine(ShowDialog(line));
    }

    /// <summary>
    /// Shows a string char by char
    /// </summary>
    /// <param name="dialogLine">The string to show</param>
    /// <returns></returns>
    IEnumerator ShowDialog(string dialogLine)
    {
        tmpInfos.text = "";
        foreach (char letter in dialogLine.ToCharArray())
        {
            tmpInfos.text += letter;
            yield return null;
        }
        EndCoroutine(dialogLine);
    }

    void EndCoroutine(string line)
    {
        StopCoroutine(coroutine);
        tmpInfos.text = line;
    }

    public void CloseInfos()
    {
        gameObject.SetActive(false);
    }
}
