using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skill : MonoBehaviour
{
    public static Skill instance;

    public int ID;
    public GameObject[] sKill;
    public GameObject[] sKillUI;
    public int timeLimit;
    public int activeTimeLimit;
    bool isActive;

    public float health;
    public ParticleSystem particle50;
    public ParticleSystem particle25;
    Collider CC;

    public Image HealthBar;
    public float distance;
    public TextMeshProUGUI distanceUI;
    public GameObject pauseUI;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        particle50.Pause();
        particle50.Clear();
        particle25.Pause();
        particle25.Clear();
        CC = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = 0 + Time.time;
        distanceUI.text = distance.ToString();

        HealthBar.fillAmount = health / 100;

        StartCoroutine(TimeOff());

        if(timeLimit <= 0)
        {
            timeLimit = 0;
            if (ID > 0)
            {
                sKill[ID].SetActive(false);
                sKillUI[ID].SetActive(false);
                sKill[0].SetActive(true);
                sKillUI[0].SetActive(true);
                ID = 0;
            }
        }

        if (health == 50)
        {
            particle50.Play();
        }

        if (health == 25)
        {
            particle25.Play();
            particle50.Clear();
            particle50.Pause();
        }

        if(health <= 0)
        {
            health = 0;
            Destroy(gameObject);
            pauseUI.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Game Over");
        }

        if (sKill[4].activeSelf == true)
        {
            sKill[0].SetActive(true);
            CC.enabled = false;
        }
        else if (sKill[4].activeSelf == false)
        {
            CC.enabled = true;
            sKillUI[0].SetActive(true);
            sKillUI[4].SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Modifikator"))
        {
            if (ID == 0)
            {
                ID = collision.gameObject.GetComponent<Modifikator>().ID;
                sKillUI[ID].SetActive(false);
                timeLimit = activeTimeLimit;
                sKill[ID].SetActive(true);
                sKill[0].SetActive(false);
                sKillUI[ID].SetActive(true);
                isActive = true;
                Destroy(collision.gameObject);
            }
            else if (ID > 0)
            {
                sKill[ID].SetActive(false);
                sKillUI[ID].SetActive(false);
                timeLimit = activeTimeLimit;
                ID = collision.gameObject.GetComponent<Modifikator>().ID;
                sKill[ID].SetActive(true);
                sKillUI[ID].SetActive(true);
                sKill[0].SetActive(false);
                Destroy(collision.gameObject);
            }
        }
    }

    IEnumerator TimeOff()
    {
        if (timeLimit > 0 && isActive == true)
        {
            isActive = false;
            yield return new WaitForSeconds(1);
            timeLimit -= 1;
            yield return new WaitForSeconds(1);
            isActive = true;
        }
    }

    public void PlayerHealth(float damage)
    {
        health -= damage;
    }
}
