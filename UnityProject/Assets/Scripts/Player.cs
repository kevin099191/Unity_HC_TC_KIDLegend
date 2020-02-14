
using UnityEngine;
using System.Linq;

public class Player : MonoBehaviour
{
    private Joystick joystick;
    private Rigidbody rig;
    public float speed=40;
    private Animator ani;
    private Transform target;
    public PlayerData data;
    private LevelManager levelManager;
    private HpDamageManager hpdamageManager;
    public GameObject bullet;
    private float timer;
    private Enemy[] enemys;
    private float[] enemysDistance;




    private void Move()
    {
        float v = joystick.Vertical;
        float h = joystick.Horizontal;






        rig.AddForce(h * speed, 0, v * speed);

        ani.SetBool("跑步開關", v != 0 || h != 0);
        Vector3 posplayer = transform.position;
        Vector3 postarget = new Vector3(posplayer.x +h*2, 0.26f, posplayer.z +v*2);

        target.position = postarget;
        postarget.y = posplayer.y;

        transform.LookAt(postarget);


        if (v == 0 && h == 0) Attack();


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "傳送區域")
        {
            StartCoroutine(levelManager.NextLevel());
        }




    }

      public void Hit(float damage)
    {
        data.Hp -= damage;
        hpdamageManager.UpdateHpbar(data.Hp , data.HpMax);

        StartCoroutine(hpdamageManager.ShowValue(damage, "-", Vector3.one, Color.red));

        if (data.Hp <= 0) Dead();
        

    }

    private void Dead()
    {
        ani.SetBool("死亡開關", true);
        this.enabled = false;

        StartCoroutine(levelManager.ShowRevival());
    }

    public void Revival()
    {
        this.enabled = true;
        ani.SetBool("死亡開關", false);
        data.Hp = data.HpMax;
        hpdamageManager.UpdateHpbar(data.Hp, data.HpMax);
        levelManager.CloseRevival();
    }

    private void Attack()
    {
        if (timer<data.cd)
        {
            timer += Time.deltaTime;

        }

        else
        {
            enemys = FindObjectsOfType<Enemy>();
            enemysDistance = new float[enemys.Length];

            if (enemys.Length == 0)
            {
                levelManager.Pass();

                return;
            }

         
            timer = 0;
            ani.SetTrigger("攻擊觸發");
            
            for (int i = 0; i < enemys.Length; i++)
            {
                enemysDistance[i] = Vector3.Distance(transform.position, enemys[i].transform.position);
            }

            float min = enemysDistance.Min();

            int index = enemysDistance.ToList().IndexOf(min);

            Vector3 posEnemy = enemys[index].transform.position;
            posEnemy.y = transform.position.y;
            transform.LookAt(posEnemy);




            Vector3 pos = transform.position + transform.up * 2f + transform.forward * 1.1f;

            GameObject temp = Instantiate(bullet, pos, transform.rotation);

            temp.GetComponent<Rigidbody>().AddForce(transform.forward * data.power);
            temp.AddComponent<Bullet>();
            temp.GetComponent<Bullet>().damage = data.Attack;
            temp.GetComponent<Bullet>().playerBullet = true;
        }





    }


        private void FixedUpdate()
    {
        Move();
    }


    private void Start()
    {


        rig = GetComponent<Rigidbody>();

        joystick = GameObject.Find("虛擬搖桿").GetComponent<Joystick>();

        ani = GetComponent<Animator>();

        //target = GameObject.Find("目標").GetComponent<Transform>();
        target = GameObject.Find("目標").transform;


        levelManager = FindObjectOfType<LevelManager>();
        hpdamageManager = GetComponentInChildren<HpDamageManager>();

    }

    


}
