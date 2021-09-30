using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    [SerializeField] private GameObject _points;
    [SerializeField] private GameObject[] spawnPointsBuffs;
    [SerializeField] private GameObject[] spawnPointsDebuffs;
    [SerializeField] private GameObject[] spawnPointsEgg;
    [SerializeField] private GameObject[] mapPointsBuffs;
    [SerializeField] private GameObject[] mapPointsDebuffs;
    [SerializeField] private GameObject[] mapPointsEgg;
    private Dictionary<GameObject, GameObject> correspondingPoints;
    private List<GameObject> spawnedPoints;
    GameObject emptyPoint;
    void Awake()
    {
        correspondingPoints = new Dictionary<GameObject, GameObject>();
        FillBuffs();
        FillDebuffs();
        FillEggs();
    }
    void Start()
    {
        spawnedPoints = _points.GetComponent<Spawn>().Points;

        for (int i = 0; i < spawnedPoints.Count; i++) 
        {
            correspondingPoints.TryGetValue(spawnedPoints[i], out emptyPoint);
            if(emptyPoint != null)
            {
                emptyPoint.transform.GetComponent<Image>().enabled = true;
                emptyPoint = null;
            }
        }
    }

    private void FillEggs()
    {
        for (int i = 0; i < spawnPointsEgg.Length; i++)
        {
            correspondingPoints.Add(spawnPointsEgg[i], mapPointsEgg[i]);
        }
    }

    private void FillDebuffs()
    {
        for (int i = 0; i < spawnPointsDebuffs.Length; i++)
        {
            correspondingPoints.Add(spawnPointsDebuffs[i], mapPointsDebuffs[i]);
        }
    }

    private void FillBuffs()
    {
        for (int i = 0; i < spawnPointsBuffs.Length; i++)
        {
            correspondingPoints.Add(spawnPointsBuffs[i], mapPointsBuffs[i]);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
