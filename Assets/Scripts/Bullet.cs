using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    private void Start()
    {
        // ���� ������Ʈ�� Rigidbody ������Ʈ�� ã�� bulletRigidbody�� �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();

        // ������ٵ��� �ӵ�  =���� �ӵ�* �̵� �ӷ�
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(bulletRigidbody, 3f);
    }
    private void OnTriggerEnter(Collider other)
    {
        // ��밡 �±װ� ���� ������ ���
        if(other.tag == "player")
        {
            // �������� ���� �� ������Ʈ�� �����´�
            PlayerController playerController = other.GetComponent<PlayerController>();
            // ���� ���κ��� ����������
            if (playerController != null)
            {
                // ���� ������Ʈ�� DIe()�޼��� ����
                playerController.Die();
            }
        }

        
    }
}
