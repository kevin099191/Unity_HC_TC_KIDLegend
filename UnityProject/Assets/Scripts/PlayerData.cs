
using UnityEngine;
[CreateAssetMenu(fileName = "玩家名稱" , menuName = "Ray/玩家資料")]
public class PlayerData : ScriptableObject
{
    [Header("血量"), Range(200, 3000)]
    public int Hp = 200;
    public int HpMax;




}
