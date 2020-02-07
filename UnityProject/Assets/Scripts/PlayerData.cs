
using UnityEngine;
[CreateAssetMenu(fileName = "玩家名稱" , menuName = "Ray/玩家資料")]
public class PlayerData : ScriptableObject
{
    [Header("血量"), Range(200, 3000)]
    public float Hp = 200;
    public float HpMax;


    [Header("冷卻時間"), Range(0,1)]
    public float cd = 0.5f;
    [Header("武器飛行速度"), Range(100, 5000)]
    public float power = 500;
}
