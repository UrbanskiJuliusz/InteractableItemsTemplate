using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractionItems", menuName = "Items/InteractionItems")]
public class InteractionItemsSO : ScriptableObject
{
    public List<InteractionItem> interactionObjects;
}

[Serializable]
public struct InteractionItem
{
    public InteractionItemNames name;
    public AudioClip audioClipDescription;
    [TextArea] public string desc;
}

public enum InteractionItemNames
{
    Fish,
    Stick
}

public enum RotationDirection
{
    XRotation,
    YRotation,
    XYRotation
}
