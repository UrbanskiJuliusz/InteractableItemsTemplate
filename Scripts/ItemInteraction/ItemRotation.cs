using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    private Vector2? prevMousePos;
    private Vector2? currentMousePos;

    private Vector2 diffMousePos;

    private Transform currentGameObjectTransform;

    private void Start()
    {
        currentGameObjectTransform = CurrentItemData.currentGameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Cursor.visible = false;

            currentMousePos = new Vector2(Input.mousePosition.x * 0.5f, Input.mousePosition.y * 0.5f);

            diffMousePos = (prevMousePos.HasValue) ? (Vector2)prevMousePos - (Vector2)currentMousePos : Vector2.zero;

            switch (CurrentItemData.rotationDirection)
            {
                case RotationDirection.XRotation:
                    currentGameObjectTransform.Rotate(new Vector3(0, diffMousePos.x, 0));
                    break;
                case RotationDirection.YRotation:
                    currentGameObjectTransform.Rotate(new Vector3(0, 0, diffMousePos.y));
                    break;
                case RotationDirection.XYRotation:
                    currentGameObjectTransform.Rotate(new Vector3(0, diffMousePos.x, diffMousePos.y));
                    break;

            }

            prevMousePos = currentMousePos;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            Cursor.visible = true;

            prevMousePos = null;
            currentMousePos = null;
        }
    }
}
