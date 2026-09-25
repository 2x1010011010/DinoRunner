using AnalyticsSystem;
using GUI;
using UnityEngine;

namespace AdvertisingSystem
{
  public class Advertising : MonoBehaviour
  {
    [Header("REFERENCES")] [SerializeField] private GameUIObserver _gameUIObserver;

    [Header("APPLOVIN AD UNIT IDS")] 
    [SerializeField] private string _bannerAdUnitId;
    [SerializeField] private string _interstitialAdUnitId;

    [Header("INTERSTITIAL FREQUENCY")] 
    [SerializeField] private int _playsPerInterstitial = 10;

    private int _playCount;
    private bool _sdkInitialized;
    private bool _interstitialReady;

    private void Awake()
    {
      MaxSdkCallbacks.OnSdkInitializedEvent += OnSdkInitialized;

      MaxSdkCallbacks.Interstitial.OnAdLoadedEvent += OnInterstitialLoaded;
      MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent += OnInterstitialLoadFailed;
      MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent += OnInterstitialDisplayFailed;
      MaxSdkCallbacks.Interstitial.OnAdHiddenEvent += OnInterstitialHidden;
      MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent += OnInterstitialDisplayed;

      MaxSdk.InitializeSdk();
    }

    private void OnDestroy()
    {
      MaxSdkCallbacks.OnSdkInitializedEvent -= OnSdkInitialized;

      MaxSdkCallbacks.Interstitial.OnAdLoadedEvent -= OnInterstitialLoaded;
      MaxSdkCallbacks.Interstitial.OnAdLoadFailedEvent -= OnInterstitialLoadFailed;
      MaxSdkCallbacks.Interstitial.OnAdDisplayFailedEvent -= OnInterstitialDisplayFailed;
      MaxSdkCallbacks.Interstitial.OnAdHiddenEvent -= OnInterstitialHidden;
      MaxSdkCallbacks.Interstitial.OnAdDisplayedEvent -= OnInterstitialDisplayed;
    }

    private void OnEnable()
    {
      _gameUIObserver.GameScreenOpened += ShowBanner;
      _gameUIObserver.GameScreenClosed += HideBanner;
      _gameUIObserver.StartGameRequested += RegisterPlay;
      _gameUIObserver.RestartGameRequested += RegisterPlay;
    }

    private void OnDisable()
    {
      _gameUIObserver.GameScreenOpened -= ShowBanner;
      _gameUIObserver.GameScreenClosed -= HideBanner;
      _gameUIObserver.StartGameRequested -= RegisterPlay;
      _gameUIObserver.RestartGameRequested -= RegisterPlay;
    }

    private void OnSdkInitialized(MaxSdkBase.SdkConfiguration sdkConfiguration)
    {
      _sdkInitialized = true;

      CreateBanner();
      LoadInterstitial();
    }

    private void CreateBanner()
    {
      MaxSdk.CreateBanner(_bannerAdUnitId, MaxSdkBase.BannerPosition.BottomCenter);
      MaxSdk.SetBannerBackgroundColor(_bannerAdUnitId, Color.black);
      MaxSdk.HideBanner(_bannerAdUnitId);
    }

    private void ShowBanner()
    {
      if (!_sdkInitialized) return;

      MaxSdk.ShowBanner(_bannerAdUnitId);
    }

    private void HideBanner()
    {
      if (!_sdkInitialized) return;

      MaxSdk.HideBanner(_bannerAdUnitId);
    }

    private void LoadInterstitial()
    {
      MaxSdk.LoadInterstitial(_interstitialAdUnitId);
    }

    private void RegisterPlay()
    {
      _playCount++;

      if (_playCount % _playsPerInterstitial != 0) return;

      ShowInterstitial();
    }

    private void ShowInterstitial()
    {
      if (!_interstitialReady) return;

      MaxSdk.ShowInterstitial(_interstitialAdUnitId);
      _interstitialReady = false;
    }

    private void OnInterstitialLoaded(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
      _interstitialReady = true;
    }

    private void OnInterstitialLoadFailed(string adUnitId, MaxSdkBase.ErrorInfo errorInfo)
    {
      _interstitialReady = false;
    }

    private void OnInterstitialDisplayFailed(string adUnitId, MaxSdkBase.ErrorInfo errorInfo, MaxSdkBase.AdInfo adInfo)
    {
      LoadInterstitial();
    }

    private void OnInterstitialHidden(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
      LoadInterstitial();
    }
    
    private void OnInterstitialDisplayed(string adUnitId, MaxSdkBase.AdInfo adInfo)
    {
      AnalyticsMessageSender.LogInterstitialShown(adUnitId);
    }
  }
}