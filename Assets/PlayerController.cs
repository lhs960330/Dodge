using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        // 수평과 수직축의 입력값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // 실제 이동속도를 입력값과 이동 속력을 사용해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 속도를 생성
        Vector3 newVelocity = new Vector3 (xSpeed, 0f,zSpeed);

        // 리지드바디의 속도에 velocity에 할당
        playerRigidbody.velocity = newVelocity;


       /* if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            playerRigidbody.AddForce(0f, 0f, speed);
        }
        if(Input.GetKey(KeyCode.DownArrow)== true)
        {
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        if(Input.GetKey (KeyCode.LeftArrow)== true)
        {
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
        if(Input.GetKey(KeyCode.RightArrow)== true)
        {
            playerRigidbody.AddForce(speed, 0f, 0f);
        }*/
    }
    public void Die()
    {
        gameObject.SetActive(false);
    }
}
