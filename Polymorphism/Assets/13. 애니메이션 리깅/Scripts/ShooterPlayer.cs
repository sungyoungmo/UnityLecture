using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ShooterPlayer : MonoBehaviour
{
    public Gun[] guns;      // 총 배열
    private int currentGun; // 현재 장착중인 총의 index

    public TargetFollower subHandTarget;    // Two Bone IK의 Target이 따라다닐 대상
    public TargetFollower subHandHint;      // Two Bone IK의 Hint가 따라다닐 대상

    public float moveSpeed;

    private Animator animator;
    public AnimationClip[] reloadClip;

    public Rig rig;
    private bool isReloading = false;
    private bool granadeIsReloading = false;
    public float granadeCooltime = 3;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    float a = 0;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) // 탭 버튼 누를 때마다 수행
        {
            if (currentGun == 0)
            {
                ChangeWeapon(1);
            }
            else
            {
                ChangeWeapon(0);
            }

            // == ChangeWeapon(currentGun == 0 ? 1 : 0);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            GranadeReload();
        }

        //Vector3 moveDir = new();
        //moveDir.x = Input.GetAxis("Horizontal");
        //moveDir.z = Input.GetAxis("Vertical");

        Vector3 moveDir =  new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Run(moveDir);
        }
        else
        {
            Walk(moveDir);
        }

        a += Time.deltaTime / 4;

    }



    public void ChangeWeapon(int index)
    {
        guns[currentGun].gameObject.SetActive(false);


        currentGun = index;
        guns[currentGun].gameObject.SetActive(true);

        subHandTarget.target = guns[currentGun].subHandTarget;
        subHandHint.target = guns[currentGun].subHandHint;
    }

    public void Walk(Vector3 movedir)
    {
        transform.Translate(movedir * Time.deltaTime * moveSpeed);
        animator.SetFloat("Xposition", movedir.x);
        animator.SetFloat("Zposition", movedir.z);
        animator.SetFloat("Speed", movedir.magnitude / 4);
    }

    public void Run(Vector3 movedir)
    {
        transform.Translate(movedir * Time.deltaTime * moveSpeed);
        animator.SetFloat("Xposition", movedir.x);
        animator.SetFloat("Zposition", movedir.z);
        animator.SetFloat("Speed", movedir.magnitude);
    }




    void Reload()
    {
        if (isReloading)
            return;
        isReloading = true;
        rig.weight = 0;
        animator.SetTrigger("Reload");
        // 재장전 후 다시 isReloading  = false 해주기 위한 코루틴
        StartCoroutine(ReloadCoroutine(reloadClip[0].length));
    }

    void GranadeReload()
    {
        if (granadeIsReloading)
            return;
        print(2);
        granadeIsReloading = true;
        rig.weight = 0;
        animator.SetTrigger("Granade");
        StartCoroutine(GranadeReloadCoroutine(reloadClip[1].length));
    }
    IEnumerator ReloadCoroutine(float duration)
    {
        a = 0;

        yield return new WaitForSeconds(duration);
        isReloading = false;
        rig.weight = Mathf.Lerp(0, 1, a);

    }
    
    IEnumerator GranadeReloadCoroutine(float duration)
    {
        a = 0;
        yield return new WaitForSeconds(duration);
        granadeIsReloading = false;

        rig.weight = Mathf.Lerp(0, 1, a);
    }

    

}
