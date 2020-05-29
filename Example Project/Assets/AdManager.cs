using System;
using UnityEngine;
using UnityEngine.Monetization;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{ //IUnityAdsListenerを実装

  //=================================================================================
  //初期化
  //=================================================================================
    
  private void Start() {
    //ゲームIDをAndroidとそれ以外(iOS)で分ける
    #if UNITY_ANDROID
    string AppStoreID = "3620427";
    #else
    string GooglePrayStoreID = "3620426";
    #endif
    
    //広告の初期化
    Advertisement.Initialize(gameID);

    //広告関連のイベントが発生するように登録
    Advertisement.AddListener(this);
  }

  //=================================================================================
  //イベント
  //=================================================================================
  
  //広告の準備完了
  public void OnUnityAdsReady (string placementId) {
    Debug.Log($"{placementId}の準備が完了");
  }
 
  //広告でエラーが発生
  public void OnUnityAdsDidError (string message) {
    Debug.Log($"広告でエラー発生 : {message}");
  }
 
  //広告開始
  public void OnUnityAdsDidStart (string placementId) {
    Debug.Log($"{placementId}の広告が開始");
  }
  
  //広告の表示終了
  public void OnUnityAdsDidFinish (string placementId, ShowResult showResult) {
    Debug.Log($"{placementId}の表示終了");
    switch (showResult){
      //最後まで視聴完了(リワード広告ならここでリワード付与する感じ)
      case ShowResult.Finished:
        Debug.Log("広告の表示成功");
        break;
      //スキップされた
      case ShowResult.Skipped:
        Debug.Log("広告スキップ");
        break;
      //表示自体が失敗した
      case ShowResult.Failed:
        Debug.LogWarning("広告の表示失敗");
        break;
    }
  }
}