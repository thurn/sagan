using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtProbe : MonoBehaviour {

    public Transform FollowTarget;
    private RtsCamera _rtsCamera;
    private Vector3 _offset;

	private void Start () {
        _rtsCamera = GetComponent<RtsCamera>();
        _rtsCamera.Follow(FollowTarget, true);
    }
}
