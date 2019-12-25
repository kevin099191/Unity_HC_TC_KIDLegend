using UnityEngine;
using UnityEngine.UI;
using System.Collections;




public class RandomSkill : MonoBehaviour
{
    public Sprite[] SpritesBlur;
    public Sprite[] SpritesSkill;

    public Image imageSkill;

    public float speed=0.1f;


    private IEnumerator RandomEffect()
    {
        for (int i = 0; i < SpritesBlur.Length; i++)
        {
            imageSkill.sprite = SpritesBlur[i];
            yield return new WaitForSeconds(speed);


        }


    }




    private void Start()
    {
        StartCoroutine(RandomEffect());
    }



}
