using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScriptMissions : MonoBehaviour
{
    public TextMeshProUGUI texte;
    public GameObject Menu;
    public GameObject Fleche;
    public GameObject panelaffiche;

    private void Start()
    {
        Menu = GameObject.FindGameObjectWithTag("LevelCompleteShow");
        Menu.SetActive(false);
    }

    public void ShowMissions()
    {
        texte.text = "Ici sont répertoriées vos missions. Vous n'en avez pas encore... Cherchez des gens en costard qui vous en donneront peut-être !";
    }

    public void ShowInvenaitre()
    {
        texte.text = "Regardez les brochures que vous avez déjà prises... Vous n'en avez pas encore ? Vite, allez voir un stand qui fera volontiez sa pub !";
    }

    public void ShowMenu()
    {
        if (Menu.activeInHierarchy)
        {
            Menu.SetActive(false);
            Fleche.GetComponent<RectTransform>().anchoredPosition = new Vector2(-25, -25);
        }
        else
        {
            Menu.SetActive(true);
            Fleche.GetComponent<RectTransform>().anchoredPosition = new Vector2(-(panelaffiche.GetComponent<RectTransform>().rect.width+25),-25); 
        }
    }
}
