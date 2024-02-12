using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ź���� ���� ������
    public float spawnRateMin = 0.5f; // �ּ� ���� �ֱ�
    public float spawnRateMax = 3f; // �ִ� ���� �ֱ�

    private Transform target; // �߻� ���
    private float spawnRate; // �����ֱ�
    private float timeAfterSpawn; // �ֱ� ���� �������� ���� �ð�

    private void Start()
    {
        // �ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;

        //ź�� ���� ������ �ּҿ� �ִ� ���̿� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        // �÷��̾� ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���
        target = FindObjectOfType<PlayerController>().transform;
    }

    private void Update()
    {
        // ���� �������� ���� �ð��� ����
        timeAfterSpawn += Time.deltaTime;

        // �ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
        if(timeAfterSpawn >= spawnRate)
        {
            // ������ �ð��� ����
            timeAfterSpawn = 0;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
            spawnRate = Random.Range(spawnRateMin , spawnRateMax);
        }

    }
}
