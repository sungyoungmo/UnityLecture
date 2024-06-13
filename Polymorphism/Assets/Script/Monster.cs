using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public abstract class 하면 컴포넌트로 추가 불가능
// 추상 클래스하려고 사용
public class Monster : MonoBehaviour, IHitable
{
    public GameObject bulletPrefab;
    public Transform shotPoint;

    public string monsterName;
    public float maxHp;
    public float currentHP;
    public float damage;

    public float shotInterval = 1f;

    void Start()
    {
        StartCoroutine(ShotCoroutine());
    }


    public virtual void Hit(float damage)
    {
        currentHP -= damage;

        print($"{name} Take Damage : { damage }, currentHP :{ currentHP }");
    }



    IEnumerator ShotCoroutine()
    {
        if (bulletPrefab == null || shotPoint == null)
        {
            yield break;
        }


        while (true)
        {
            Shot();

            yield return new WaitForSeconds(shotInterval);
        }
    }

    public void Shot()
    {

        GameObject bulletObject = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);

        bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * 10.0f, ForceMode.Impulse);

        
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.damage = damage;
        bullet.targetLayer = (1 << LayerMask.NameToLayer("Player"));


        Destroy(bulletObject, 3.0f);
    }

}
