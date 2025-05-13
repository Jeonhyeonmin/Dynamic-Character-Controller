using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CameraController))]
public class CameraController_Editor : Editor
{
    CameraController cameraController;

    public override void OnInspectorGUI()
    {
        cameraController = (CameraController)target;
        base.OnInspectorGUI();
    }

    public void OnSceneGUI()
    {
        if (!cameraController || !cameraController.PlayerTransform)
        {
            return;
        }

        Transform playerTarget = cameraController.PlayerTransform;
        Vector3 targetPosition = playerTarget.position;
        targetPosition.y += cameraController.cameraHeightOffset;

        // Draw distance circle
        Handles.color = new Color(1f, 0f, 0f, 0.15f);
        Handles.DrawSolidDisc(targetPosition, Vector3.up, cameraController.cameraDistance);

        Handles.color = new Color(0, 1f, 0f, 0.5f);
        Handles.DrawWireDisc(targetPosition, Vector3.up, cameraController.cameraDistance);

        Handles.color = new Color(1f, 0f, 0f, 0.5f);
        cameraController.cameraDistance = Handles.ScaleSlider(cameraController.cameraDistance, targetPosition, -playerTarget.forward, Quaternion.identity, cameraController.cameraDistance, 0.01f);
        cameraController.cameraDistance = Mathf.Clamp(cameraController.cameraDistance, 0.1f, 100f);

        Handles.color = new Color(0f, 1f, 0f, 0.5f);
        cameraController.cameraHeight = Handles.ScaleSlider(cameraController.cameraHeight, targetPosition, playerTarget.up, Quaternion.identity, cameraController.cameraHeight, 0.01f);
        cameraController.cameraHeight = Mathf.Clamp(cameraController.cameraHeight, 0.1f, 100f);

        GUIStyle labelStyle = new GUIStyle();
        labelStyle.fontSize = 15;
        labelStyle.normal.textColor = Color.white;
        labelStyle.alignment = TextAnchor.UpperCenter;

        Handles.Label(targetPosition + (-playerTarget.forward * cameraController.cameraDistance), "Distance", labelStyle);

        labelStyle.alignment = TextAnchor.MiddleCenter;

        Handles.Label(targetPosition + (playerTarget.up * cameraController.cameraHeight), "Height", labelStyle);

        cameraController.CameraHandle();
    }
}
