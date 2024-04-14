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
        
        
        //add mouse cursor look
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0;
     
        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        Vector3 mouseMoveVector = _followTargetPos + (mousePos - new Vector3(Screen.width/2, Screen.height/2));
        
        _followTargetPos += mouseMoveVector.normalized;
        
        _followTargetPos.z = followZ;
        this.transform.SetPositionAndRotation(Vector3.Lerp(this.transform.position, _followTargetPos, Time.deltaTime * currentSpeed), Quaternion.identity);
    }
    
    
}
