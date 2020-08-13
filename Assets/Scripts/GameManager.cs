using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    int health;
    int score;

    public void resetScore()
    {
        health = 50;
        score = 0;
    }

    public void damage()
    {
        health--;
        if (health == 0)
        {
            if (score > getBestScore()) setBestScore(score);
        }
    }

    public int getHealth()
    {
        return health;
    }

    public void incScore()
    {
        score++;
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
        MakeSingleton();
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
