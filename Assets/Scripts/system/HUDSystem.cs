using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDSystem : MonoBehaviour
{
    public Text high;
    public Text score;
    public Text life;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
        high.text = PlayerPrefs.GetInt("high").ToString();
        score.text = gm.getScore().ToString();
        life.text = gm.getHealth().ToString();

    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: "+ gm.getScore().ToString();
        life.text = "Health: "+ gm.getHealth().ToString();
    }
}
