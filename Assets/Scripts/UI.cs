using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    bool isPaused = false;
    bool end = false;

    public TextMeshProUGUI resultsTxt;
    public GameObject results;
    public GameObject menu;
    public GameObject next;
    public GameObject replay;
    public GameObject unpause;
    public GameObject endCover;
    public Animator animator;

    public AudioSource click;

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
        if (!end)
        {
            endCover.SetActive(true);
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
            end = true;
        }
    }

    public void TogglePause()
    {
        click.Play();
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
        click.Play();
        Time.timeScale = 1f;
        animator.Play("FadeOut");
        sceneName = name;
        Invoke("LoadScene", 1f);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}

