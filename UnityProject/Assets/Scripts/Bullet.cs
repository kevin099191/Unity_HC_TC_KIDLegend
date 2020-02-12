
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public bool playerBullet;

    private void OnTriggerEnter(Collider other)
    {


        if (!playerBullet)                        ///前面加一個 ! 是false 簡寫
        {
            if (other.name == "骨頭")
            {
                other.GetComponent<Player>().Hit(damage);
            }
        }
        else
        {
          if (other.tag == "敵人")
          {
            other.GetComponent<Enemy>().Hit(damage);
        }

        }
    }



}
