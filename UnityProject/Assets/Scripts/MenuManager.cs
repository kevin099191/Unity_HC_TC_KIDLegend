
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("玩家資料")]
    public PlayerData data;



    public void StartGame()
    {
        data.Hp = data.HpMax;
        SceneManager.LoadScene(1);

    }




}
