using UnityEngine;
using Bot;
using System.Collections;

public class RangedWeapon : Weapon
{
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected Transform barrel;
    [SerializeField] protected int magazineSize = 20;
    private int _restOfBulletInMagazine;

    protected void Start()
    {
        base.Start();

        _restOfBulletInMagazine = magazineSize;
    }

    public override void Attack(GameObject targetObj)
    {
        if (_isPostShotDelay) return;

        if (_isReloading) return;

        if (_restOfBulletInMagazine < 1) StartCoroutine(Reloading());

        var targetAttack = targetObj.transform.position + 
            new Vector3(0f, targetObj.GetComponent<CapsuleCollider>().height * 0.85f, 0f) - barrel.transform.position;

        Instantiate(bullet, barrel.position, Quaternion.LookRotation(targetAttack));

        _animator.SetTrigger("Attack");

        _restOfBulletInMagazine--;

        StartCoroutine(WaitPostShotDelay());
    }

    protected IEnumerator Reloading()
    {
        if (_animator != null) _animator.SetTrigger("Reload");
        _isReloading = true;

        yield return new WaitUntil(() => _animator.GetCurrentAnimatorStateInfo(0).IsName("Reload"));
        yield return new WaitForSecondsRealtime(_animator.GetCurrentAnimatorStateInfo(0).length);

        _isReloading = false;
        _restOfBulletInMagazine = magazineSize;
    }
}
