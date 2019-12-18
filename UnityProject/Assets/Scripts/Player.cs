
using UnityEngine;

public class Player : MonoBehaviour
{
    private Joystick joystick;
    private Rigidbody rig;
    public float speed=25;






    private void Move()
    {
        float v = joystick.Vertical;
        float h = joystick.Horizontal;






        rig.AddForce(h * speed, 0, v * speed);        




    }



    private void FixedUpdate()
    {
        Move();
    }


    private void Start()
    {


        rig = GetComponent<Rigidbody>();
        joystick = GameObject.Find("虛擬搖桿").GetComponent<Joystick>();






    }




}
