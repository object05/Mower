using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public GameObject[] grass;
    public GameObject mower;
    public Text endText;
    public int grassNum;
    int health;
    int score;
    public float halfHeight;
    public float halfWidth;
    public bool ended;
    Vector3 startPos;
    Quaternion startRotation;
    HUDSystem HUD;


    public void resetGame()
    {
        ended = false;
        health = 50;
        score = 0;
        endText.text = "";
        foreach(GameObject item in grass)
        {
            if (!item.activeSelf)
            {
                item.SetActive(true);
            }
        }

        mower.transform.position = startPos;
        mower.transform.rotation = startRotation;
        HUD.high.text = getBestScore().ToString();

    }

    public void damage()
    {
        if (health <= 0)
        {
            ended = true;
            if (score > getBestScore())
            {
                setBestScore(score);
            }
            endText.color = Color.red;
            endText.text = "GAME OVER, you lost";
        }
        else
        {
            health--;
        }
    }

    public int getHealth()
    {
        return health;
    }

    public void incScore()
    {
        score++;
        if(score >= grassNum && !ended)
        {
            ended = true;
            if(score > getBestScore())
            {
                setBestScore(score);
            }
            endText.color = Color.yellow;
            endText.text = "GAME OVER, you won";
        }
    }

    public int getScore()
    {
        return score;
    }

    void setBestScore(int result)
    {
        PlayerPrefs.SetInt("best", result);
    }

    private int getBestScore()
    {
        return PlayerPrefs.GetInt("best", 0);
    }

    void Awake()
    {
        HUD = gameObject.GetComponent<HUDSystem>();
        MakeSingleton();
        resetGame();
        startPos = mower.transform.position;
        startRotation = mower.transform.rotation;
    }

    void Start()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = Camera.main.aspect * halfHeight;

        grass = GameObject.FindGameObjectsWithTag("Grass");
        grassNum = grass.Length;
    }

    void Update()
    {
        if (ended)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                resetGame();
            }
        }
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
