using UnityEngine;

public class Par : MonoBehaviour
{

    public Transform[] ts;

    public GameObject[] fa = new GameObject[5];

    public string[] s = new string[4];

    public GameObject[] player;


    private void Start()
    {
       



        int Ca = 100;

        while (Ca > 60)
        {
            Ca-=10;
            print("whilec迴圈次數:"+ Ca);
        }


        player = GameObject.FindGameObjectsWithTag("Player");




    }





}
