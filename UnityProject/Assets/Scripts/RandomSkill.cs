using UnityEngine;
using UnityEngine.UI;
using System.Collections;




public class RandomSkill : MonoBehaviour
{
    public Sprite[] SpritesBlur;
    public Sprite[] SpritesSkill;
    private string[] NamesSkill = {"連續射擊","正向箭","背向箭","側向箭","血量增加","攻擊增加","攻速增加","爆擊增加",};
    

    public float speed=0.02f;
    [Header("捲動次數"),Range(1,30)]
    public int counts=5;

    private AudioSource aud;
    public AudioClip sound;
    public AudioClip soundskill;

    private Image imageSkill;
    private Button btn;
    private Text Textname;
    private GameObject skillsplane;
    private int index;





    private IEnumerator RandomEffect()
    {
        btn.interactable = false;
        for (int j = 0; j < counts; j++)
        {

            

            for (int i = 0; i < SpritesBlur.Length; i++)
            {
                aud.PlayOneShot(sound, 0.5f);
                imageSkill.sprite = SpritesBlur[i];
                yield return new WaitForSeconds(speed);


            }
        }


        btn.interactable = true;

        index = Random.Range(0, SpritesSkill.Length);
        imageSkill.sprite = SpritesSkill[index];
        aud.PlayOneShot(soundskill, 0.5f);

        Textname.text = NamesSkill[index];

        
    }




    private void Start()
    {
        aud = gameObject.GetComponent<AudioSource>();
        imageSkill = GetComponent<Image>();
        btn = GetComponent<Button>();
        Textname = transform.GetChild(0).GetComponent<Text>();
        skillsplane = GameObject.Find("隨機");
        btn.onClick.AddListener(choeseskill);





        StartCoroutine(RandomEffect());
        

    }


    private void choeseskill()
    {
        skillsplane.SetActive(false);
        print(NamesSkill[index]);

    }






}
