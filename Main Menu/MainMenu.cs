using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainButtons;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject loadingScreen;

    [SerializeField] private Image bar;

    [SerializeField] private Text loadingText;

    private void Start()
    {
        Cursor.visible = true;
    }

    public void ExitGame()
    {
        Debug.Log("Game is over");
        Application.Quit();
    }

    public void Load()
    {
        loadingScreen.SetActive(true);

        StartCoroutine(LoadAssync());
    }

    IEnumerator LoadAssync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("1");

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            loadingText.text = Mathf.RoundToInt(asyncLoad.progress * 100f) + "%";
            bar.fillAmount = asyncLoad.progress;
            
            if (asyncLoad.progress >= 0.9f && !asyncLoad.allowSceneActivation)
                asyncLoad.allowSceneActivation = true;

            yield return null;
        }
    }


}
