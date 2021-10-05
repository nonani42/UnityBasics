using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private Animator _anim;
    [SerializeField] GameObject _loseScreen;
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
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>()._hasLost = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _loseScreen.SetActive(true);
    }

    public void Load()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        DontDestroyOnLoad(player);
        player.transform.position = new Vector3(22, 0, 3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
