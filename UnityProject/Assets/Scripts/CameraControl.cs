
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform player;

    [Header("攝影機移動速度"), Range(1, 10)]
    public float speed = 2f;
    [Header("上方限制")]
    public float top = 5.8f;
    [Header("下方限制")]
    public float below = -2f;

    private void track()
    {
        Vector3 posplayer = player.position;
        Vector3 poscamera = transform.position;

        posplayer.x = 0;
        posplayer.z = Mathf.Clamp(posplayer.z, below, top);

        transform.position= Vector3.Lerp(posplayer, poscamera, 0.5f*Time.deltaTime*speed);



    }

    private void Start()
    {
        player = GameObject.Find("骨頭").transform;
    }

    private void LateUpdate()
    {
        track();
    }



}
