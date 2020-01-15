
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("敵人資料")]
    public EnemyData data;
    private Animator ani;
    private NavMeshAgent nma;
    ///private Transform T_bone;
    private GameObject bone;
    private float timer;

    private void Start()
    {
        ani = GetComponent<Animator>();
        nma = GetComponent<NavMeshAgent>();

        ///T_bone = GameObject.Find("骨頭").transform;
        bone = GameObject.Find("骨頭");
        nma.speed = data.speed;
        nma.stoppingDistance = data.stopdistance;



    }

    private void Move()
    {
        /// nma.SetDestination(T_bone.position);
        nma.SetDestination(bone.transform.position);

        Vector3 targetPos = bone.transform.position;
        targetPos.y = transform.position.y;
        transform.LookAt(targetPos);

        if (nma.remainingDistance < nma.stoppingDistance)
        {
            Wait();
        }
        else
        {
            ani.SetBool("跑步開關", true);
        }
        


    }

    private void Wait()
    {
        ani.SetBool("跑步開關", false);

        timer += Time.deltaTime;

        if (timer >= data.cd)
        {
            Attack();
        }
    }



    protected virtual void Attack()
    {
        timer = 0;
        ani.SetTrigger("攻擊觸發");


    }

    private void Hit(float damage)
    {

    }

    private void Dead()
    {

    }

    private void Drop()
    {

    }



    private void Update()
    {
        Move();
    }








































}
