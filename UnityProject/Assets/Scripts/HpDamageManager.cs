using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class HpDamageManager : MonoBehaviour
{
    private Image Hpbar;
    private RectTransform rtValue;
    private Text textValue;

    private void Start()
    {
        Hpbar = transform.GetChild(1).GetComponent<Image>();
        rtValue = transform.GetChild(2).GetComponent<RectTransform>();
        textValue = transform.GetChild(2).GetComponent<Text>();




    }


    private void Update()
    {
        FixedAngle();
    }

    private void FixedAngle()
    {
        ///eulerAngles:0~360;
        transform.eulerAngles = new Vector3(30, 0, 0);


    }

    public void UpdateHpbar(float HpCurrent , float HpMax)
    {
        Hpbar.fillAmount = HpCurrent / HpMax; 
    }

    public IEnumerator ShowValue(float value , string mark , Vector3 size , Color Valuecolor)
    {
        rtValue.anchoredPosition = new Vector2(0, 30);
        textValue.text = mark + value;
        Valuecolor.a = 0;
        textValue.color = Valuecolor;
        rtValue.localScale = size;

        for (int i = 0; i < 30; i++)
        {
            textValue.color += new Color(0, 0, 0, 0.03f);
            rtValue.anchoredPosition += Vector2.up*3;
            yield return new WaitForSeconds(0.005f);

        }
        textValue.color = new Color(0, 0, 0, 0);

    }




}
