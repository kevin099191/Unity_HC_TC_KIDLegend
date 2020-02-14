
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
    private HpDamageManager hpdamageManager;
    private float hp;
    public GameObject coin;


    private void Start()
    {
        ani = GetComponent<Animator>();
        nma = GetComponent<NavMeshAgent>();

        ///T_bone = GameObject.Find("骨頭").transform;
        bone = GameObject.Find("骨頭");
        nma.speed = data.speed;
        nma.stoppingDistance = data.stopdistance;
        hp = data.Hp;
        hpdamageManager = GetComponentInChildren<HpDamageManager>();
        
    }

    private void Move()
    {
        if (ani.GetBool("死亡開關")) return;
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

    public void Hit(float damage)
    {
        hp -= damage;
        hpdamageManager.UpdateHpbar(hp, data.HpMax);

        StartCoroutine(hpdamageManager.ShowValue(damage, "-", Vector3.one, Color.red));

        if (hp <= 0) Dead();

    }

    private void Dead()
    {
        ani.SetBool("死亡開關", true);
        nma.isStopped = true;
        Destroy(this);
        Destroy(gameObject, 1.3f);
        Drop();
    }

    private void Drop()
    {
        int r = (int)Random.Range(data.coinRandom.x, data.coinRandom.y);

        for (int i = 0; i < r; i++)
        {
            Instantiate(coin, transform.position + transform.up * 0.2f, Quaternion.identity);
        }
        

    }



    private void Update()
    {
        Move();
    }








































}
