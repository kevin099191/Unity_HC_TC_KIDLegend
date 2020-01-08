using UnityEngine;



[CreateAssetMenu(fileName ="怪物名稱",menuName ="Ray/怪物")]
public class EnemyData : ScriptableObject
{
    [Header("血量"), Range(10, 3000)]
    public float hp;
    [Header("攻擊"), Range(0, 1000)]
    public float attack;
    [Header("攻擊冷卻時間"), Range(0, 10)]
    public float cd;
    [Header("移動速度"), Range(0, 1000)]
    public float speed;

















}
