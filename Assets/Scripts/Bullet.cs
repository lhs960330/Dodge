using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    private void Start()
    {
        // 게임 오브젝트에 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();

        // 리지드바디의 속도  =앞쪽 속도* 이동 속력
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(bulletRigidbody, 3f);
    }
    private void OnTriggerEnter(Collider other)
    {
        // 상대가 태그가 다음 과같은 경우
        if(other.tag == "player")
        {
            // 상대방으로 부터 이 컴포넌트를 가져온다
            PlayerController playerController = other.GetComponent<PlayerController>();
            // 상대방 으로부터 성공했으면
            if (playerController != null)
            {
                // 상대방 컴포넌트의 DIe()메서드 실행
                playerController.Die();
            }
        }

        
    }
}
