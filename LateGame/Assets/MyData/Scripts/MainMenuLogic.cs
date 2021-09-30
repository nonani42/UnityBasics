using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLogic : MonoBehaviour
{
    [SerializeField] GameObject _menu;
    public void Start()
    {
        //_menu = gameObject;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        _menu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        _menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
