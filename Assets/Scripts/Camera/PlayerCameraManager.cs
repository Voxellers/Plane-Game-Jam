using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraManager : MonoBehaviour
{

    public GameObject targetToFollow;
    //targetToFollow's transform
    private Transform targetTransform;
    public float forwardDistance = 50f;
    public float smoothMovementSpeed = 5f;
    public float angleMovementSpeed = 0.5f;
    //비행기의 상승 높이
    public float maxHeight = 700f;
    public float minHeight = 0f;
    private float maxHeightMinusMinHeight;

    //상승 높이에 따른 카메라 오프셋
    public Vector3 maxOffset;
    public Vector3 minOffset;

    public Quaternion maxAngle = Quaternion.Euler(30,0,0);
    public Quaternion minAngle = Quaternion.Euler(0,0,0);

    // Use this for initialization
    void Start()
    {
        //baseOffset = transform.position - targetToFollow.transform.position;
        targetTransform = targetToFollow.transform;
        maxHeightMinusMinHeight = maxHeight - minHeight;
    }

    //왜 여기서 LateUpdate 썼을까?
    //Update에서 플레이어 움직임이 발생하니
    //움직임 발생된 뒤에 따라가져야하니까?
    void LateUpdate()
    {
        if (targetToFollow != null)
        {
            //확대축소 비율 구하기
            float magnitude = maxHeight - targetTransform.position.y;

            Vector3 newCameraPosition;
            newCameraPosition = targetTransform.position;
            newCameraPosition += GetCameraPositionTowardPlayersLookAt();
            newCameraPosition += GetCameraOffsetByMagnitude(magnitude);

            MoveCameraSmootly(GetCameraAngleByMagnitude(magnitude), newCameraPosition);
        }
    }

    Vector3 GetCameraPositionTowardPlayersLookAt()
    {
        return targetTransform.forward * forwardDistance;
    }

    void MoveCameraSmootly(Quaternion newAngle, Vector3 newPosition)
    {
        //부드럽게 전환
        transform.rotation = Quaternion.Lerp(transform.rotation,
            newAngle,
            angleMovementSpeed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position,
            newPosition,
            smoothMovementSpeed * Time.deltaTime);
    }


    Vector3 GetCameraOffsetByMagnitude(float magnitude)
    {
        //가수 구하기
        float minusY = (maxOffset.y - minOffset.y) / maxHeightMinusMinHeight;
        float minusZ = (maxOffset.z - minOffset.z) / maxHeightMinusMinHeight;
        Vector3 minusOffset = new Vector3(0, minusY, minusZ);

        Vector3 calculatedOffset = maxOffset - (minusOffset * magnitude);

        //클램프
        float clampedY = Mathf.Clamp(calculatedOffset.y, minOffset.y, maxOffset.y);
        float clampedZ = Mathf.Clamp(calculatedOffset.z, maxOffset.z, minOffset.z); //Z는 커질때마다 -로 뒤로 물러나므로, max와 min이 바뀌어야함.
        calculatedOffset = new Vector3(0, clampedY, clampedZ);

        return calculatedOffset;
    }
    Quaternion GetCameraAngleByMagnitude(float magnitude)
    {
        float minusXDegree = (maxAngle.x - minAngle.x) / maxHeightMinusMinHeight;
        float minusYDegree = (maxAngle.y - minAngle.y) / maxHeightMinusMinHeight;
        float minusZDegree = (maxAngle.z - minAngle.z) / maxHeightMinusMinHeight;
        float calculatedXDgree = maxAngle.x - (minusXDegree * magnitude);
        float calculatedYDgree = maxAngle.y - (minusYDegree * magnitude);
        float calculatedZDgree = maxAngle.z - (minusZDegree * magnitude);
        calculatedXDgree = Mathf.Clamp(calculatedXDgree, minAngle.x, maxAngle.x);
        calculatedYDgree = Mathf.Clamp(calculatedXDgree, minAngle.y, maxAngle.y);
        calculatedZDgree = Mathf.Clamp(calculatedXDgree, minAngle.z, maxAngle.z);

        Quaternion newQuaternion = Quaternion.Euler(calculatedXDgree, calculatedYDgree, calculatedZDgree);
        return  newQuaternion;
    }
}
