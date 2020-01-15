
using UnityEngine;
using System.Collections;

public class EnemyNear : Enemy
{
    protected override void Attack()
    {
        base.Attack();
        StartCoroutine(DelayAttack());
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position + data.nearAttackpos, transform.forward * data.nearAttackLength);
        



    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(data.AttackDelay);

        RaycastHit hit;

        if (Physics.Raycast(transform.position + data.nearAttackpos, transform.forward ,out hit,data.nearAttackLength))
        {
            print("打到的物件" + hit.collider.name);
        }




    }

























}
