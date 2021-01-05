using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowInfosEcoleManager : MonoBehaviour
{
    enum Stade { Question1, InfosSupp, QuestionsSupp, Lieu, Modalites, Brochure};

    Stade stade = Stade.Question1;
    
    public TextMeshProUGUI tmpInfos;
    Coroutine coroutine;
    EcoleScriptableObject obj;

    [SerializeField]
    Sprite[] BtnBckg;

    [SerializeField]
    TextMeshProUGUI TxtBtn1;
    [SerializeField]
    TextMeshProUGUI TxtBtn2;


    

    public void ShowInfosEcole(EcoleScriptableObject ecoleScriptableObject)
    {
        stade = Stade.Question1;
        obj = ecoleScriptableObject;
        string line = "Bonjour et bienvenue à " + ecoleScriptableObject.Nom + ". Est-ce que vous connaissez l'école ?";
        coroutine = StartCoroutine(ShowDialog(line));
    }


    public void FirstButton() {
        
        switch (stade)
        {
           
            case Stade.Question1:
                stade = Stade.QuestionsSupp;
                TxtBtn1.text = "Où êtes vous situés ?";
                TxtBtn2.text = "Quelles sont les modalités d'inscription ?";
                
                coroutine = StartCoroutine(ShowDialog("Que voulez-vous savoir ?"));

                break;
            case Stade.InfosSupp:
                stade = Stade.QuestionsSupp;
                TxtBtn1.text = "Où êtes vous situés ?";
                TxtBtn2.text = "Quelles sont les modalités d'inscription ?";
                coroutine = StartCoroutine(ShowDialog("Que voulez-vous savoir ?"));

                break;
            case Stade.QuestionsSupp:
                stade = Stade.Lieu;
                coroutine = StartCoroutine(ShowDialog(obj.Lieu));
                break;
            case Stade.Lieu:
                stade = Stade.Lieu;
                coroutine = StartCoroutine(ShowDialog(obj.Lieu));
                break;
            case Stade.Modalites:
                Application.OpenURL(obj.PageInscription);
                stade = Stade.Brochure;
                coroutine = StartCoroutine(ShowDialog("Avant de partir, souhaitez-vous recevoir une brochure sur votre boite mail ?"));
                break;
            case Stade.Brochure:
                CloseInfos();
                break;
            default:
                break;
        }
        Debug.Log(stade);
    }

    public void SecondButton()
    {
        
        switch (stade)
        {
            case Stade.Question1:
                stade = Stade.InfosSupp;
                coroutine = StartCoroutine(ShowDialog(obj.Description));
                break;
            case Stade.InfosSupp:
                stade = Stade.Brochure;
                TxtBtn1.text = "Oui";
                TxtBtn2.text = "Non";
                coroutine = StartCoroutine(ShowDialog("Avant de partir, souhaitez-vous recevoir une brochure sur votre boite mail ?"));
                break;
            case Stade.QuestionsSupp:
                stade = Stade.Modalites;
                TxtBtn1.text = "Oui";
                TxtBtn2.text = "Non";
                coroutine = StartCoroutine(ShowDialog(obj.Modalites));
                break;
            case Stade.Lieu:
                stade = Stade.Modalites;
                TxtBtn1.text = "Oui";
                TxtBtn2.text = "Non";
                coroutine = StartCoroutine(ShowDialog(obj.Modalites));
                break;
            case Stade.Modalites:
                stade = Stade.Brochure;
                coroutine = StartCoroutine(ShowDialog("Avant de partir, souhaitez-vous recevoir une brochure sur votre boite mail ?"));
                break;
            case Stade.Brochure:
                CloseInfos();
                break;
            default:
                break;
        }
        Debug.Log(stade);
    }

    public void DirectConnection()
    {
        Application.OpenURL("http://2orm.com/SALON/PHP/COMM/Reunion.php?stand=5&ID_User=104");
        stade = Stade.InfosSupp;
        SecondButton();


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
