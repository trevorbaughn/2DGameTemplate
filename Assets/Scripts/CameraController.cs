using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject followTarget;

    private Vector3 _followTargetPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float followZ = this.transform.position.z;
        _followTargetPos = followTarget.transform.position;
        _followTargetPos.z = followZ;

        this.transform.SetPositionAndRotation(Vector3.Lerp(this.transform.position, _followTargetPos, Time.deltaTime * speed), Quaternion.identity);
    }
    
    
}
