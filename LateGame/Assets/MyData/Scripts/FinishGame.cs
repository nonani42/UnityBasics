using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    private Animator _anim;
    GameObject bossObj;
    private Boss boss;
    [SerializeField] GameObject _winScreen;

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
            Win();
        }
    }
    public void Win()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _winScreen.SetActive(true);
    }
}
