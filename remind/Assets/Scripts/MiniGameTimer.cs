using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MiniGameTimer : MonoBehaviour
{
    [SerializeField] private float time;
    private TMP_Text timerText;
    [SerializeField] GameObject gameOverScreen;
    

    private float _timeLeft = 0f;

    private IEnumerator StartTimer()
    {
        while (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;
            UpdateTimeText();
            yield return null;
        }
    }

    private void Start()
    {
        timerText = GetComponent<TMP_Text>();
        _timeLeft = time;
        StartCoroutine(StartTimer());
    }

   

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
        {
            _timeLeft = 0;
            GameOver();
        }
            

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        timerText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("MiniGame Protottype");
    }
}