using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : MonoBehaviour
{
    public InteractionItemsSO interactionItemsBase;
    [SerializeField] protected Quaternion startOffsetRotation;
    [SerializeField, Range(0.1f, 1f)] protected float distanceToCamera;
    [SerializeField] protected InteractionItemNames interactionItemName;
    public bool activeBlinkingItem;
    public bool activeRotateItem;

    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    public SkinnedMeshRenderer SkinnedMeshRenderer
    {
        get => skinnedMeshRenderer;
        private set => skinnedMeshRenderer = value;
    }

    [SerializeField] private float blinkingTime = 1.5f;
    public float BlinkingTime 
    { 
        get => blinkingTime;
        private set => blinkingTime = value;
    }

    [ColorUsage(true, true), SerializeField] private Color startColor;
    public Color StartColor
    {
        get => startColor;
        private set => startColor = value;
    }

    [ColorUsage(true, true), SerializeField] private Color highlightColor;
    public Color HighlightColor
    {
        get => highlightColor;
        private set => highlightColor = value;
    }

    [SerializeField] private RotationDirection rotationDirection;
    public RotationDirection RotationDirection
    {
        get => rotationDirection;
        private set => rotationDirection = value;
    }

    private void Awake()
    {
        if (activeBlinkingItem && gameObject.GetComponent<ItemBlinking>() == null)
        {
            gameObject.AddComponent(typeof(ItemBlinking));
        }
    }
}
