using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Ecole", order = 1)]
public class EcoleScriptableObject : ScriptableObject
{
    
    public string Nom;
    [TextArea(3,10)]
    public string Lieu;
    [TextArea(3, 10)]
    public string Description;
    public string DateJPO;
    [TextArea(3, 10)]
    public string Modalites;
    public string PageInscription;
    public int NombreDePresentateurs;
}
