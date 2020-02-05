
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour
{
    private string GooglePlay = "3457928";

    private void Start()
    {
        Advertisement.Initialize(GooglePlay, true);
    }


}
