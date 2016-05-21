using UnityEngine;
using System.Collections;
#if UNITY_ANDROID
using UnityEngine.Advertisements;
#endif

public class AdsBehaviourScript : MonoBehaviour {
	/*
#if UNITY_ANDROID

	public string AdsUnitId;

	public bool ShowOnStart = false, isTeste = false;

	public int IntervaloDeMortes;

	private static int QuantidadeDeMortes = 0;

	private static AdsBehaviourScript ads = null;

	public delegate void CallBackDoVideo();


	void Awake() {

		if (ads == null) {
			ads = this;
		}

	}

	public static AdsBehaviourScript GetInstance(){
	
		return ads;
			
	}


	
	// Use this for initialization
	void Start () {

		if (!Advertisement.isInitialized && Advertisement.isSupported) {
			Advertisement.Initialize (AdsUnitId,isTeste);
		} else {
			Debug.Log("Platform not supported");
		}

		QuantidadeDeMortes ++;
		if (ShowOnStart) {
			Show ();
		}

		Debug.Log (QuantidadeDeMortes);

		if (QuantidadeDeMortes > 20) {
			QuantidadeDeMortes = 0;
			Debug.Log ("mahoi");
			Show();
		}

	}
	
	// Update is called once per frame
	void Update () {


	}

	public void Show(){
		if (Advertisement.IsReady()) {
			Advertisement.Show (null, new ShowOptions {
			resultCallback = result => {
				Debug.Log(result.ToString());
				}
			});	
		}
	}

	public void Show(CallBackDoVideo callBack){

		if (Advertisement.IsReady()) {
			Advertisement.Show (null, new ShowOptions {
				resultCallback = result => {
					callBack();
					Debug.Log(result.ToString());
				}
			});	
		}
	}
#endif
*/
}
