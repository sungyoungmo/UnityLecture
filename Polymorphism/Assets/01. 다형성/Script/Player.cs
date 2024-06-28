using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHitable
{

    public Bullet bulletPrefab;
    public Transform shotPoint;

    public float damage = 10;

    public float maxHP = 100;
    public float currentHP = 100;

    public LayerMask targetLayer;

    float moveSpeed = 3;

    Rigidbody rb;
    CharacterController cController;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cController = GetComponent<CharacterController>();
    }


    public void Hit(float damage)
    {
        currentHP -= damage;

        print($"Player take damage : {damage}, currentHP : {currentHP}");
    }

    void Update()
    {
        float xmove = Input.GetAxisRaw("Horizontal");
        float zmove = Input.GetAxisRaw("Vertical");

        Vector3 moveVector = new Vector3(xmove,0,zmove);


        cController.Move(moveVector * moveSpeed * Time.deltaTime);


        if (Input.GetButtonDown("Fire1"))
        {

            Shot();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Interact();
            
        }


    }

    public void Shot()
    {
        Bullet bullet = Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);

        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 10.0f, ForceMode.Impulse);

        bullet.damage = damage;

        //bullet에게 맞아야 할 대상 레이어 지정
        // 원래 아래와 같이 사용한다.
        //bullet.targetLayer = 1 << LayerMask.NameToLayer("Monster");
        
        // 여러 개를 원한다면 이렇게
        bullet.targetLayer = (1 << LayerMask.NameToLayer("Box")) + (1 << LayerMask.NameToLayer("Monster"));
        


        Destroy(bullet, 3.0f);
    }


    public void Interact()
    {

        Ray ray = new Ray(transform.position, Vector3.forward);

        RaycastHit hitinfo;

        if (Physics.Raycast(ray, out hitinfo, 3f, targetLayer))
        {
            //Debug.Log(hitinfo.collider.gameObject.name);

            hitinfo.collider.gameObject.GetComponent<IInteractable>().Interact();

            if (hitinfo.collider.gameObject.GetComponent<Box2>())
            {

            }

        }




    }

}
