using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolTest : MonoBehaviour
{
    public ObjectPool pool;

    private void Awake()
    {
        if (pool == null)
        {
            pool = GetComponent<ObjectPool>();
        }
    }

    // ��Ʈ�߼� ȣ���� public �Լ�
    public void SpawnSphere()
    {
        GameObject obj = pool.GetObject();

        // insideUnitSphere : Vector3�� ��ȯ�Ǵ� ������Ƽ, xyz���� ��� -1~1 ����
        obj.transform.position = Random.insideUnitSphere * 5;
        StartCoroutine(DespawnCoroutine(obj));
    }

    // 2~5�� �Ŀ� ������Ʈ�� Ǯ�� �ǵ����ִ� �ڷ�ƾ
    IEnumerator DespawnCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        pool.ReturnObject(obj);
    }
}
