using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public LayerMask targetLayer;

    private void OnTriggerEnter(Collider other)
    {
        // Ʈ���� �ȿ� ���� �ٸ� ��ü�� Layer�� targetLayer�� �ٸ� ���̾�� ����
        if ((targetLayer | (1 << other.gameObject.layer)) != targetLayer)
        {
            return;
        }



        // interface�� Ȱ���� ���
        //if (other.TryGetComponent<IHitable>(out IHitable hitable))
        //{
        //    hitable.Hit(damage);
        //}

        // ȥ���� ���� ��������� ���� ������ ���� ���� ����
        // ����Ƽ ���α׷��ӽ����� ���
        // ������ ���� �ִ� ���
        // �ǵ���� �۵��� �ϸ� �Ǳ� ������ �� ����� ����ص� ��
        other.SendMessage("Hit", damage, SendMessageOptions.DontRequireReceiver);


        Destroy(gameObject);
    }
}
