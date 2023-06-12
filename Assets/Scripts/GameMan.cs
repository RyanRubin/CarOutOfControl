using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMan : MonoBehaviour
{
    public static GameMan inst;

    bool isPaused;
    bool isRestartLevel;
    int score;

    public GameObject mainRect;
    public GameObject gameRect;
    public Text scoreText;
    public Text pauseButtonText;
    public GameObject overRect;
    public Text overScoreText;

    public GameObject player;

    public AudioSource fxAudSrc;

    void Awake()
    {
        inst = this;
    }

    void Start()
    {
        InvokeRepeating("IncScore", 0, 1);
    }

    void Update()
    {

    }

    public void RestartLevel()
    {
        isRestartLevel = true;

        overScoreText.text = "score: " + score;

        gameRect.SetActive(false);
        overRect.SetActive(true);

        StartCoroutine(_RestartLevel());
    }

    IEnumerator _RestartLevel()
    {
        yield return new WaitForSeconds(4);
        Application.LoadLevel(Application.loadedLevel);
    }

    void IncScore()
    {
        if (!isRestartLevel)
        {
            score++;
            scoreText.text = "score: " + score;
        }
    }

    public void Pause()
    {
        isPaused = !isPaused;
        pauseButtonText.text = isPaused ? "Resume" : "Pause";
        Time.timeScale = isPaused ? 0 : 1;
    }

    public void Play()
    {
        mainRect.SetActive(false);
        gameRect.SetActive(true);

        GameObject[] vehicles = GameObject.FindGameObjectsWithTag("Vehicle");
        foreach (GameObject vehicle in vehicles)
        {
            Destroy(vehicle);
        }
        GameObject[] rls = GameObject.FindGameObjectsWithTag("RoadLine");
        foreach (GameObject rl in rls)
        {
            Destroy(rl);
        }

        Instantiate(player, player.transform.position, player.transform.rotation);
    }

    public void ExplosionAudio()
    {
        fxAudSrc.Play();
    }
}
