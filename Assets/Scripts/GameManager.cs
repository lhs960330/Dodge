using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // ���ӿ����� Ȱ���� �ؽ��� ������Ʈ
    public Text timeText; // �ױ������� Ÿ�����
    public Text recordText; // ���� ���� ��ƾ �ð� ����

    private float surviveTime; // ���� �ð�
    private bool isGameover; // ���ӿ��� ����

    private void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }
    private void Update()
    {
        // ���ӿ����� �ƴҶ�
        if (!isGameover)
        {
            // �����ð� ����
            surviveTime += Time.deltaTime;

            timeText.text = "Time: " + (int)surviveTime;
        }
        else // ���ӿ����϶�
        {

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }


    // ���ӿ��� ������ �޼���
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