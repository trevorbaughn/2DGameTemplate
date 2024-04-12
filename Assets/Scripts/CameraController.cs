using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    public float currentSpeed;
    public float maxSpeed;
    [SerializeField] private GameObject followTarget;

    private Vector3 _followTargetPos;
    

    // Update is called once per frame
    void Update()
    {
        float followZ = this.transform.position.z;
        _followTargetPos = followTarget.transform.position;
        _followTargetPos.z = followZ;

        this.transform.SetPositionAndRotation(Vector3.Lerp(this.transform.position, _followTargetPos, Time.deltaTime * currentSpeed), Quaternion.identity);
    }
    
    
}
