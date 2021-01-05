using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Ecole", order = 1)]
public class EcoleScriptableObject : ScriptableObject
{
    
    public string Nom;
    public string Lieu;
    public object Brochure;
    [TextArea]
    public string Description;
    public string DateJPO;
    public int NombreDePresentateurs;
}
