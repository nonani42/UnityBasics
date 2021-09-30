using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private Animator _anim;
    Scene nextScene;
    public void Awake()
    {
        _anim = GetComponent<Animator>();
        nextScene = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnTriggerEnter(Collider other)
    {
        Destroy(GetComponent<BoxCollider>());
        GameObject.FindGameObjectWithTag("Colleague").GetComponent<Colleague>().Stop();
        switch (other.tag)
        {
            case "Player":
                Debug.Log("To the next level.");
                _anim.SetTrigger("_open");
                Load();
                break;
            case "Colleague":
                GameOver();
                break;
            default:
                break;
        }
    }

    public void GameOver()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>()._hasLost = true;
        SceneManager.LoadScene(0);
    }

    public void Load()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        DontDestroyOnLoad(player);
        //SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
