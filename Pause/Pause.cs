using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private bool pause = false;

    [SerializeField] private GameObject pauseConsole;

    [SerializeField] private UsingCamera script;
    
    [SerializeField] private MainCharacter playerAnim;

    [SerializeField] private AudioSource musicSource;

    [SerializeField] private float musicVolume;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
            {
                musicSource.volume = 0f;
                playerAnim.enabled = false;
                Cursor.visible = true;
                script.enabled = false;
                pauseConsole.SetActive(true);
                pause = true;
                Time.timeScale = 0;
            }
            else
            {
                musicSource.volume = musicVolume;
                playerAnim.enabled = true;
                Cursor.visible = false;
                script.enabled = true;
                Time.timeScale = 1;
                pauseConsole.SetActive(false);
                pause = false;
            }
        }
    }

    public void Continue()
    {
        musicSource.volume = musicVolume;
        pauseConsole.SetActive(false);
        Cursor.visible = false;
        script.enabled = true;
        Time.timeScale = 1;
        pause = false;
        playerAnim.enabled = true;
    }


    public void Replay()
    {
        musicSource.volume = musicVolume;
        playerAnim.enabled = true;
        Cursor.visible = false;
        script.enabled = true;
        pause = false;
        Time.timeScale = 1;
        StartCoroutine(Wait());

    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitToMenu()
    {
        musicSource.volume = musicVolume;
        playerAnim.enabled = true;
        script.enabled = true;
        pause = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }


}
