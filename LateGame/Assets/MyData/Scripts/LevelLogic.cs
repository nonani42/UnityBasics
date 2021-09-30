using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLogic : MonoBehaviour
{

    [SerializeField] GameObject _map;
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void StartShowMap()
    {
        StartCoroutine(ShowMap());
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
    public IEnumerator ShowMap()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            _map.SetActive(false);
            Resume();
        }
    }
}
