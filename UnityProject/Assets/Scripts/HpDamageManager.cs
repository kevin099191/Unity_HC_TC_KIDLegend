using UnityEngine.UI;
using UnityEngine;

public class HpDamageManager : MonoBehaviour
{
    private Image Hpbar;


    private void Start()
    {
        Hpbar = transform.GetChild(1).GetComponent<Image>();
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





}
