using UnityEditor;

[CustomEditor(typeof(ItemInteractableController))]
public class ItemInteractableControllerEditor : Editor
{
    public SerializedProperty interactionItemsBase;
    public SerializedProperty blinkingActive;
    public SerializedProperty rotateActive;

    private ItemInteractableController objectInteractableController;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        objectInteractableController = target as ItemInteractableController;

        interactionItemsBase = serializedObject.FindProperty("interactionItemsBase");
        EditorGUILayout.PropertyField(interactionItemsBase);

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Item Settings", EditorStyles.boldLabel);
        
        SerializedProperty startOffsetRotation = serializedObject.FindProperty("startOffsetRotation");
        EditorGUILayout.PropertyField(startOffsetRotation);

        SerializedProperty distanceToCamera = serializedObject.FindProperty("distanceToCamera");
        EditorGUILayout.PropertyField(distanceToCamera);

        if (objectInteractableController.interactionItemsBase)
        {
            SerializedProperty interactionObjectName = serializedObject.FindProperty("interactionItemName");
            EditorGUILayout.PropertyField(interactionObjectName);
        }

        #region Item Blinking

        EditorGUILayout.Space();
        if (objectInteractableController.activeBlinkingItem)
        {
            EditorGUILayout.LabelField("Blinking Settings", EditorStyles.boldLabel);
        }

        blinkingActive = serializedObject.FindProperty("activeBlinkingItem");
        EditorGUILayout.PropertyField(blinkingActive);

        if (objectInteractableController.activeBlinkingItem)
        {
            SerializedProperty blinkingTime;
            SerializedProperty skinnedMeshRenderer;
            SerializedProperty startColor;
            SerializedProperty highlightColor;

            blinkingTime = serializedObject.FindProperty("blinkingTime");
            skinnedMeshRenderer = serializedObject.FindProperty("skinnedMeshRenderer");
            startColor = serializedObject.FindProperty("startColor");
            highlightColor = serializedObject.FindProperty("highlightColor");

            EditorGUILayout.PropertyField(blinkingTime);
            EditorGUILayout.PropertyField(skinnedMeshRenderer);
            EditorGUILayout.PropertyField(startColor);
            EditorGUILayout.PropertyField(highlightColor);
        }

        #endregion

        #region Item Rotation

        EditorGUILayout.Space();
        if (objectInteractableController.activeRotateItem)
        {
            EditorGUILayout.LabelField("Rotate Settings", EditorStyles.boldLabel);
        }

        rotateActive = serializedObject.FindProperty("activeRotateItem");
        EditorGUILayout.PropertyField(rotateActive);

        if (objectInteractableController.activeRotateItem)
        {
            SerializedProperty rotationDirection;

            rotationDirection = serializedObject.FindProperty("rotationDirection");

            EditorGUILayout.PropertyField(rotationDirection);
        }

        #endregion

        serializedObject.ApplyModifiedProperties();
    }
}
