using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentItemData : MonoBehaviour
{
    internal static string uiSceneName = "DisplayItem";

    internal static InteractionItem currentItem;
    internal static bool allowToRotation;
    internal static RotationDirection rotationDirection;
    internal static GameObject currentGameObject;

    public static void SetCurrentItemData(InteractionItem interactionItem, GameObject gameobject)
    {
        currentGameObject = gameobject;
        currentItem = interactionItem;
    }

    public static void DestroyAndResetCurrentValues()
    {
        Destroy(currentGameObject);
        allowToRotation = false;
        currentGameObject = null;
    }
}
