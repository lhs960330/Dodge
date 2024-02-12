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
        // ����� �������� �Է°��� �����Ͽ� ����
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        // ���� �̵��ӵ��� �Է°��� �̵� �ӷ��� ����� ����
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        // Vector3 �ӵ��� ����
        Vector3 newVelocity = new Vector3 (xSpeed, 0f,zSpeed);

        // ������ٵ��� �ӵ��� velocity�� �Ҵ�
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
