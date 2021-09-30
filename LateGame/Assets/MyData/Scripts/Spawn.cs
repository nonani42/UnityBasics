using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject buffPrefab;
    [SerializeField] private GameObject debuffPrefab;
    [SerializeField] private GameObject eggPrefab;
    [SerializeField] private GameObject[] spawnPointsBuffs;
    [SerializeField] private GameObject[] spawnPointsDebuffs;
    [SerializeField] private GameObject[] spawnPointsEgg;
    System.Random rand;
    GameObject point;
    List<GameObject> points;
    int buffAmount = 3;
    int debuffAmount = 3;
    List <GameObject> buffs;
    List <GameObject> debuffs;
    GameObject egg;

    public List<GameObject> Points
    {
        get
        {
            return points;
        }
    }
    void Awake()
    {
        rand = new System.Random();
        points = new List<GameObject>();
        GenerateBuffs();
        GenerateEgg();
        GenerateDebuffs();
    }
    void Start()
    {

    }
    private void GenerateEgg()
    {
        point = spawnPointsEgg[rand.Next(spawnPointsEgg.Length)];
        points.Add(point);
        egg = Instantiate(eggPrefab, point.transform.position, point.transform.rotation);
    }
    private void GenerateBuffs()
    {
        buffs = new List<GameObject>();
        do
        {
            point = spawnPointsBuffs[rand.Next(spawnPointsBuffs.Length)];
            if (buffs.Count == 0 || !buffs.Contains(point))
            {
                buffs.Add(point);
                points.Add(point);
            }
        } while (buffs.Count != buffAmount);
        for(int i = 0; i< buffs.Count; i++)
        {
            buffs[i] = Instantiate(buffPrefab, buffs[i].transform.position, buffPrefab.transform.rotation);
        }
    }
    private void GenerateDebuffs()
    {
        debuffs = new List<GameObject>();
        do 
        {
            point = spawnPointsDebuffs[rand.Next(spawnPointsDebuffs.Length)];
            if (debuffs.Count == 0 || !debuffs.Contains(point))
            {
                debuffs.Add(point);
                points.Add(point);
            }
        } while (debuffs.Count != debuffAmount);
        for (int i = 0; i < debuffs.Count; i++)
        {
            debuffs[i] = Instantiate(debuffPrefab, debuffs[i].transform.position, debuffPrefab.transform.rotation);
        }
    }

}
