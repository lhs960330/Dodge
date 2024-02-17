using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // 게임오버시 활성할 텍스터 오브젝트
    public Text timeText; // 죽기전까지 타임재기
    public Text recordText; // 가장 오래 버틴 시간 저장

    private float surviveTime; // 생존 시간
    private bool isGameover; // 게임오버 상태

    private void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }
    private void Update()
    {
        // 게임오버가 아닐때
        if (!isGameover)
        {
            // 생존시간 갱신
            surviveTime += Time.deltaTime;

            timeText.text = "Time: " + (int)surviveTime;
        }
        else // 게임오버일때
        {

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }


    // 게임오버 상태의 메서드
    public void EndGame()
    {
        isGameover = true;
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