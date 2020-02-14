
using UnityEngine;

public class Item : MonoBehaviour
{
    private AudioSource aud;
    public AudioClip sound;
    [HideInInspector]
    public bool pass;
    private Transform player;

    private void Start()
    {
        Physics.IgnoreLayerCollision(10, 10,false);
        handleCollision();
        player = GameObject.Find("骨頭").transform;
        aud = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GoToPlayer();
    }

    private void handleCollision()
    {
        Physics.IgnoreLayerCollision(10, 8);
        Physics.IgnoreLayerCollision(10, 9);
    }

    private void GoToPlayer()
    {
        if (pass)
        {
          Physics.IgnoreLayerCollision(10, 10);

          transform.position = Vector3.Lerp(transform.position, player.position, 0.7f * Time.deltaTime * 10);

            if (Vector3.Distance(transform.position , player.position ) < 2 && ! aud.isPlaying)
            {
                aud.PlayOneShot(sound, 0.3f);
                Destroy(gameObject, 0.4f);


            }





        }

    }



}
