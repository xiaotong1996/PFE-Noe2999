using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	void Awake(){
		StartCoroutine("moja");
	}
	IEnumerator moja(){
		yield return new WaitForSeconds(1);
		
		MyNotifications.CallNotification("", 4);
		//MyNotifications.CallNotification("", 4);

		
	}
}
