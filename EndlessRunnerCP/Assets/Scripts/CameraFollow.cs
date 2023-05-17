using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    #region Definitions
    public Transform target;
    public float followSpeed = 2.0f;
    public Vector3 followDistance = new Vector3(0, 5, -10);
    public float followRotation = 45.0f;
    #endregion
    private void LateUpdate()
    {
        followTarget();
    }

    private void followTarget() // karakteri biraz arkadan biraz üstten birazda sağ çaprazdan takip et.
    {
        if (target == null)
            return;

        Quaternion rotation = Quaternion.Euler(0, followRotation, 0);
        Vector3 offsetPosition = rotation * followDistance;
        Vector3 newPosition = target.position + offsetPosition;

        transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);
        transform.LookAt(target);
    }
}
