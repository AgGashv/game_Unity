using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{

    [SerializeField] private float coinCount;
    
    [SerializeField] private Text CoinT;
    [SerializeField] private Text loadingText;
    
    [SerializeField] private Image bar;

    [SerializeField] private GameObject youWinText;
    [SerializeField] private GameObject loadingScreen;

    [SerializeField] private AudioClip coinTake;
    
    [SerializeField] private AudioSource musicStop;
    [SerializeField] private AudioSource coinSource;

    void Update()
    {
        CoinT.text = "" + coinCount + "/5";

        if (coinCount == 5)
        {
            youWinText.SetActive(true);
            musicStop.Stop();

            StartCoroutine(LoadingScreen());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coinSource.PlayOneShot(coinTake);
            coinCount++;
        }
    }

    private IEnumerator LoadingScreen()
    {
        yield return new WaitForSecondsRealtime(10f);
        loadingScreen.SetActive(true);
        
        StartCoroutine(NextLevel());
    }

    IEnumerator NextLevel()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("2");

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
