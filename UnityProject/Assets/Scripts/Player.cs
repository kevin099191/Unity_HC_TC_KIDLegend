
using UnityEngine;

public class Player : MonoBehaviour
{
    private Joystick joystick;
    private Rigidbody rig;
    public float speed=25;
    private Animator ani;
    private Transform target;

    private LevelManager levelManager;



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





    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "傳送區域")
        {
            StartCoroutine(levelManager.NextLevel());
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


    }

    


}
