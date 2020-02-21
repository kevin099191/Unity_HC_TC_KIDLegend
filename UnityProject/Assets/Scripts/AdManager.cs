
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour,IUnityAdsListener
{
    private string GooglePlay = "3457928";
    private string PlacementRevival = "revival";
    private Player player;

    private void Start()
    {
        Advertisement.Initialize(GooglePlay, false);
        Advertisement.AddListener(this);
        player = FindObjectOfType<Player>();
    }


    public void ShowRevivalAd()
    {
        if (Advertisement.IsReady(PlacementRevival))
        {
            Advertisement.Show(PlacementRevival);
        }


    }

    void IUnityAdsListener.OnUnityAdsReady(string placementId)
    {
        
    }

    void IUnityAdsListener.OnUnityAdsDidError(string message)
    {
        
    }

    void IUnityAdsListener.OnUnityAdsDidStart(string placementId)
    {
      
    }

    void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == PlacementRevival)
        {
            switch (showResult)
            {
                case ShowResult.Failed:
                    print("廣告失敗");
                    break;
                case ShowResult.Skipped:
                    print("廣告掠過");
                    break;
                case ShowResult.Finished:
                    print("廣告完成");
                    player.Revival();
                    
                    break;
                
            }
        }







    }









}


