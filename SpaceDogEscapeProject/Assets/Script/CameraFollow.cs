using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject target;
    public Vector3 offset;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    
    void LateUpdate () {
     //   target = GameObject.FindGameObjectWithTag("level");
        transform.position = target.transform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, smoothTime);
        transform.LookAt(target.transform);
	}
}
