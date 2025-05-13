using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public Camera MainCamera { get { return mainCamera; } private set { } }
    [SerializeField] private Transform playerTransform;
    public Transform PlayerTransform { get { return playerTransform; } private set { } }

    public float cameraDistance;
    public float cameraHeight;
    public float cameraHeightOffset;

    public float cameraAngle;
    public float smoothLerp;

    private Vector3 refVelocity;

    private void LateUpdate()
    {
        CameraHandle();
    }

    public void CameraHandle()
    {
        if (playerTransform == null)
        {
            return;
        }

        Vector3 worldDistance = (Vector3.forward * -cameraDistance) + (Vector3.up * cameraHeight);
        Vector3 worldRotation = Quaternion.AngleAxis(cameraAngle, Vector3.up) * worldDistance;
        Vector3 finalTargetPosition = playerTransform.position;
        finalTargetPosition.y += cameraHeightOffset;

        Vector3 fianlPosition = finalTargetPosition + worldRotation;

        transform.position = Vector3.SmoothDamp(transform.position, fianlPosition, ref refVelocity, smoothLerp);

        transform.LookAt(playerTransform.position);

        Debug.DrawLine(playerTransform.position, fianlPosition, Color.red);
    }
}
