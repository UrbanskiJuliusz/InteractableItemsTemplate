using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class DisplayItemController : MonoBehaviour
{
    [SerializeField] private InteractionItemsSO interactionItemsBase;
    private string itemDescText;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private TextMeshProUGUI itemNameTMP;
    [SerializeField] private TextMeshProUGUI itemDescTMP;

    private void OnEnable() => PostProcessSettings.Instance.ActiveBlurryEffect(true);
    private void OnDestroy()
    {
        PostProcessSettings.Instance.ActiveBlurryEffect(false);
        StopAllCoroutines();
    }

    private void Start()
    {
        var currentItem = CurrentItemData.currentItem;

        SetItemDataAndPlayAudioClip(currentItem);

        if (CurrentItemData.allowToRotation && GetComponent<ItemRotation>() == null)
        {
            gameObject.AddComponent(typeof(ItemRotation));
        }
    }

    private void SetItemDataAndPlayAudioClip(InteractionItem item)
    {
        itemNameTMP.text = item.name.ToString();
        itemDescText = item.desc;

        AudioClip descAudioClip = item.audioClipDescription;
        StartCoroutine(WritingDescriptionAnimation(descAudioClip));

        audioSource.clip = descAudioClip;
        audioSource.Play();
    }

    private IEnumerator WritingDescriptionAnimation(AudioClip audioClipDescription)
    {
        float audioClipDescriptionTime = (audioClipDescription != null) ? audioClipDescription.length : 0;
        float delay = audioClipDescriptionTime / itemDescText.Length;

        for (int i = 0; i <= itemDescText.Length; i++)
        {
            itemDescTMP.text = itemDescText.Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
    }

    public void TransformItemToBackpack()
    {
        StopAllCoroutines();
        itemDescTMP.text = itemDescText;
        StartCoroutine(TransformToBackpack());
    }

    private IEnumerator TransformToBackpack()
    {
        var startPos = CurrentItemData.currentGameObject.transform.position;
        var destPos = Camera.main.transform.position + (Camera.main.transform.up * -0.2f) + (Camera.main.transform.forward * -0.1f);

        var currentTimeTransform = 0f;
        while (currentTimeTransform <= 1f)
        {
            CurrentItemData.currentGameObject.transform.position = Vector3.Lerp(startPos, destPos, currentTimeTransform);
            currentTimeTransform += Time.deltaTime;
            yield return null;
        }

        CurrentItemData.DestroyAndResetCurrentValues();

        UnloadDisplayItemScene();
    }

    private void UnloadDisplayItemScene()
    {
        Camera.main.GetComponent<FreeCamera>().enabled = true;

        SceneManager.UnloadSceneAsync(CurrentItemData.uiSceneName);
    }
}
