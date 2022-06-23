using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ItemInteractable))]
public class ItemBlinking : MonoBehaviour
{
    private ItemInteractable itemInteractable;

    private float currentTimeAnimation;
    private int sign;
    private int emissionColorID;

    private void Awake()
    {
        emissionColorID = Shader.PropertyToID("_EmissiveColor");
        itemInteractable = GetComponent<ItemInteractable>();
    }

    private void OnEnable() => StartCoroutine(ObjectBlinkingCoroutine());
    private void OnDisable() => StopCoroutine(ObjectBlinkingCoroutine());

    private IEnumerator ObjectBlinkingCoroutine()
    {
        while (itemInteractable.activeBlinkingItem)
        {
            if (currentTimeAnimation >= itemInteractable.BlinkingTime)
                sign = -1;
            else if (currentTimeAnimation <= 0)
                sign = 1;

            currentTimeAnimation += Time.deltaTime * sign;

            var colorTemp = Color.Lerp(itemInteractable.StartColor, itemInteractable.HighlightColor, currentTimeAnimation / itemInteractable.BlinkingTime);
            itemInteractable.SkinnedMeshRenderer.material.SetColor(emissionColorID, colorTemp);

            yield return null;
        }

        itemInteractable.SkinnedMeshRenderer.material.SetColor(emissionColorID, itemInteractable.StartColor);
    }
}
