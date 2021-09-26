using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Destroy(GetComponent<BoxCollider>());
        switch (other.tag)
        {
            case "Player":
                Debug.Log("To the next level.");
                //Load();
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
        GameObject.FindGameObjectWithTag("Colleague").GetComponent<Animator>().runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load("Assets/Import/Kevin Iglesias/Basic Motions/AnimationControllers/BasicMotions@Idle.controller");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>()._hasLost = true;
        Debug.Log("Game over.");
    }

    private static void Load()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            Scene nextScene = SceneManager.GetSceneByPath(@"Assets\MyData\Scenes\Level2.unity");
            Debug.Log($"Next level is {nextScene.name}");
            SceneManager.LoadScene(nextScene.name);
            SceneManager.MoveGameObjectToScene(player, nextScene);
        }
    }
}
