using UnityEngine;
using System.Collections;

public class cocote : MonoBehaviour
{

    private IEnumerator Test()
    {
        print("遊戲開始");

        yield return new WaitForSeconds(3);

        print("三秒過後");

        yield return new WaitForSeconds(3);

        print("再三秒過後");




    }
    private void Start()
    {

        StartCoroutine(Test());

    }







}
