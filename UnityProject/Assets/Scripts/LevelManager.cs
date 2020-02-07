
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject objLijht;
    public GameObject randomSkill;
    public Animator door;

    [Header("是否自動顯示隨機技能")]
    public bool autoshowskill;
    [Header("是否自動開門")]
    public bool autoOpendoor;

    private Image imgCross;
    public GameObject PanelRevival;


    private void Start()
    {

        door = GameObject.Find("木頭門").GetComponent<Animator>();
        imgCross = GameObject.Find("轉場效果").GetComponent<Image>();

        if (autoshowskill) ShowSkill();
        if (autoOpendoor) Invoke("OpenDoor", 7);



    }






    private void ShowSkill()
    {
        randomSkill.SetActive(true);
    }

    private void OpenDoor()
    {
        objLijht.SetActive(true);
        door.SetTrigger("開門觸發");


    }

    public IEnumerator NextLevel()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("關卡2");

        async.allowSceneActivation = false;



        for (int i = 0; i < 100; i++)
        {
            imgCross.color += new Color(1, 1, 1, 0.01f);
            yield return new WaitForSeconds(0.001f);
        }


        async.allowSceneActivation = true;

    }


    public IEnumerator ShowRevival()
    {
        PanelRevival.SetActive(true); 

        for (int i = 3; i >0; i--)
        {
           
            PanelRevival.transform.GetChild(1).GetComponent<Text>().text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        




    }


    public void CloseRevival()
    {
        StopCoroutine(ShowRevival());

        PanelRevival.SetActive(false);

    }



}
