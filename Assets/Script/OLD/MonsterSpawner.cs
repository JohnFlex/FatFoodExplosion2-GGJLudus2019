using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] Monsters;
    private int SelectedMonster;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMonster", 5f, 5f);
    }


    private void SpawnMonster()
    {
        SelectedMonster = Random.Range(0, 3);
        if (SelectedMonster == 3)
        {
            GameObject.Instantiate(Monsters[Monsters.Length - 1],transform);

        }
        else
        {
            GameObject.Instantiate(Monsters[0],transform);
        }

    }

    
}
