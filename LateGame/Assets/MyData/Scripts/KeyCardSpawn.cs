using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCardSpawn : MonoBehaviour
{
    [SerializeField] private GameObject keyCardPrefab;
    [SerializeField] private Transform[] spawnPointskeyCard;
    System.Random rand;
    Transform keycardPoint;

    void Start()
    {
        rand = new System.Random();
        GenerateKeyCard();
    }
    private void GenerateKeyCard()
    {
        keycardPoint = spawnPointskeyCard[rand.Next(spawnPointskeyCard.Length)];
        Instantiate(keyCardPrefab, keycardPoint.transform.position, keyCardPrefab.transform.rotation);
    }
}
