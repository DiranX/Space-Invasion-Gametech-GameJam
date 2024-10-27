using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UID : MonoBehaviour
{
    public GameObject MainMenuUI;
    public GameObject PauseUI;
    public GameObject HUD;
    public GameObject Player;
    public GameObject Spawner;

    public float lerpSpeed;
    public Transform startingPoint;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Resume()
    {
        if(Skill.instance.health != 0)
        {
            Time.timeScale = 1;
            PauseUI.SetActive(false);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        MainMenuUI.SetActive(false);
        StartCoroutine(PlayIntro());
        Spawner.SetActive(true);
        HUD.SetActive(true);
    }

    IEnumerator PlayIntro()
    {
        Player.SetActive(true);
        Vector3 startPos = Player.transform.position;
        Vector3 endPos = startingPoint.position;
        float journeyLenght = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;

        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLenght;

        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLenght;
            Player.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            yield return null;
        }
    }
}
