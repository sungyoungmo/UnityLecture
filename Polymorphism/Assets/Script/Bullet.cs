using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public LayerMask targetLayer;

    private void OnTriggerEnter(Collider other)
    {
        // 트리거 안에 들어온 다른 객체의 Layer가 targetLayer와 다른 레이어면 무시
        if ((targetLayer | (1 << other.gameObject.layer)) != targetLayer)
        {
            return;
        }



        // interface를 활용한 방법
        //if (other.TryGetComponent<IHitable>(out IHitable hitable))
        //{
        //    hitable.Hit(damage);
        //}

        // 혼자할 때는 상관없지만 같이 개발할 때는 좋지 않음
        // 유니티 프로그래머스럽게 사용
        // 정석은 위에 있는 방법
        // 의도대로 작동만 하면 되기 때문에 이 방법을 사용해도 됨
        other.SendMessage("Hit", damage, SendMessageOptions.DontRequireReceiver);


        Destroy(gameObject);
    }
}
