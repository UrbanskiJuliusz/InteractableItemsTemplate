using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ItemInteractableController : ItemInteractable
{   
    private float currentTimeTransform = 0f;

    private bool IsUISceneLoaded => SceneManager.GetSceneByName(CurrentItemData.uiSceneName).isLoaded == true;

    private void OnMouseDown()
    {
        if (Vector3.Distance(Camera.main.transform.position, gameObject.transform.position) < 3f && !IsUISceneLoaded)
        {
            Camera.main.GetComponent<FreeCamera>().enabled = false;

            StartCoroutine(TransformToCamera());

            InteractionItem currentItem = interactionItemsBase.interactionObjects.Find(x => x.name == interactionItemName);
            CurrentItemData.SetCurrentItemData(currentItem, gameObject);
            CurrentItemData.allowToRotation = activeRotateItem;
            CurrentItemData.rotationDirection = RotationDirection;

            activeBlinkingItem = false;
        }
    }

    private IEnumerator TransformToCamera()
    {
        var startPos = transform.position;
        var startRot = transform.rotation;

        var destPos = Camera.main.transform.position + (Camera.main.transform.forward * distanceToCamera);
        var destRot = Camera.main.transform.rotation * startOffsetRotation;

        while (currentTimeTransform <= 1f)
        {
            transform.position = Vector3.Lerp(startPos, destPos, currentTimeTransform);
            transform.rotation = Quaternion.Lerp(startRot, destRot, currentTimeTransform);
            currentTimeTransform += Time.deltaTime;
            yield return null;
        }

        transform.position = destPos;
        transform.rotation = destRot;

        LoadDisplayItemView();
    }

    private void LoadDisplayItemView()
    {
        if (!IsUISceneLoaded)
        {
            SceneManager.LoadSceneAsync(CurrentItemData.uiSceneName, LoadSceneMode.Additive);
        }
    }
}
