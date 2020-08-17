﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText, recordText;

    private float surviveTime;
    private bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + Mathf.RoundToInt(surviveTime).ToString();
            //timeText.text = "Time : " + (int)surviveTime;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void EndGame()
    {
        isGameOver = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Time: " + (int)bestTime;
    }
}
//콜렉션 일반화
//List<T>
//Stack<T>
//Queue<T>
//Dictionary<T,U>

//PlayerPrefs.Set Int(string,int)
//PlayerPrefs.Set Float(string,f)
//PlayerPrefs.Set String(string,s)

//date가 없을 시 기본값이 저장된다.



