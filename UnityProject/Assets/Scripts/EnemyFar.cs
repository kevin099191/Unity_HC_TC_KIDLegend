using System.Collections;
using UnityEngine;

public class EnemyFar : Enemy
{
    public GameObject bullert;


    protected override void Attack()
    {
        base.Attack();
        StartCoroutine(FarAttack());
    }


    private IEnumerator FarAttack()
    {
        yield return new WaitForSeconds(data.AttackDelay);

        Vector3 pos = transform.position + new Vector3(data.nearAttackpos.x, data.nearAttackpos.y, 0);
        pos += transform.forward * data.nearAttackpos.z;

        /// forward = (0 , 0 , 1) unity把Z軸設作為前方

       GameObject temp =  Instantiate(bullert, pos, transform.rotation);
        temp.GetComponent<Rigidbody>().AddForce(transform.forward * data.FarPower);

        temp.AddComponent<Bullet>();
        temp.GetComponent<Bullet>().damage = data.attack;
        temp.GetComponent<Bullet>().playerBullet = true;

    }













}
