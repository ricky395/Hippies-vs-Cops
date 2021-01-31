using UnityEngine;
using System.Collections;

public class TouchNSlide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

/*#if UNITY_ANDROID
        if (Input.touchCount == 1 || Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

            Debug.DrawRay(ray.origin, ray.direction * 20, Color.red);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                hitTransform = hit.transform.GetComponent<Transform>();

            }
        }
#endif*/
    }
}
