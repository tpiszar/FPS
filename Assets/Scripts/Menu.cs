using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    public GameObject[] pages;

    public Animator animator;

    public AudioSource click;

    string sceneName;

    public void SelectPage(int page)
    {
        click.Play();
        pages[0].SetActive(false);
        pages[page].SetActive(true);
    }

    public void Back(int curPage)
    {
        click.Play();
        pages[curPage].SetActive(false);
        pages[0].SetActive(true);
    }

    public void SelectScene(string name)
    {
        click.Play();
        animator.Play("FadeOut");
        Time.timeScale = 1f;
        sceneName = name;
        Invoke("LoadScene", 1f);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnApplicationQuit()
    {
        click.Play();
        Application.Quit();
    }
}
