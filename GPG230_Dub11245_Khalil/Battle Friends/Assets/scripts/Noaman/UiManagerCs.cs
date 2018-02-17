using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManagerCs : MonoBehaviour {

    public GameObject AndroidObj;
	// Use this for initialization
	void Start ()
    {
#if UNITY_ANDROID || UNITY_IOS
     AndroidObj.enabled(true);
#endif
      
    }
}
