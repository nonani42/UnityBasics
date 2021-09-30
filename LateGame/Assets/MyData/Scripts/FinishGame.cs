using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    private Animator _anim;
    GameObject bossObj;
    private Boss boss;

    public void Awake()
    {
        bossObj = GameObject.FindGameObjectWithTag("Boss");
        _anim = GetComponent<Animator>();
        if(bossObj != null)
        {
            boss = bossObj.GetComponent<Boss>();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Player>()._hasKeyCard)
        {
            Debug.Log("You won.");
            _anim.SetTrigger("_open");
            boss.Stop();
            Destroy(GetComponent<BoxCollider>());
            Destroy(other.gameObject);
            SceneManager.LoadScene(0);
        }
    }
}
