using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    bool isPaused = false;

    public TextMeshProUGUI resultsTxt;
    public GameObject results;
    public GameObject menu;
    public GameObject next;
    public GameObject replay;
    public GameObject unpause;
    public Animator animator;

    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && (Time.timeScale != 0 || isPaused))
        {
            TogglePause();
        }
    }

    public void End(bool win)
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        if (win)
        {
            resultsTxt.text = "Victory";
            next.SetActive(true);
        }
        else
        {
            resultsTxt.text = "You Died";
            replay.SetActive(true);
        }
        results.SetActive(true);
        menu.SetActive(true);
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            //unpause
            isPaused = false;
            results.SetActive(false);
            menu.SetActive(false);
            unpause.SetActive(false);
            Time.timeScale = 1.0f;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            //pause
            isPaused = true;
            Time.timeScale = 0.0f;
            results.SetActive(true);
            menu.SetActive(true);
            unpause.SetActive(true);
            resultsTxt.text = "Paused";
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void SelectScene(string name)
    {
        animator.Play("FadeOut");
        Time.timeScale = 1f;
        sceneName = name;
        Invoke("LoadScene", 1f);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
