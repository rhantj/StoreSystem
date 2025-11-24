using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject storePanel;
    [SerializeField] private GameObject invenPanel;

    private void Start()
    {
        storePanel.SetActive(false);
        invenPanel.SetActive(false);
    }

    private void OnEnable()
    {
        IUIToggleable.OnInventoryToggled += ToggleInvenPanel;
        IUIToggleable.OnFullViewToggled += ToggleFullPanel;
    }

    private void OnDisable()
    {
        IUIToggleable.OnInventoryToggled -= ToggleInvenPanel;
        IUIToggleable.OnFullViewToggled -= ToggleFullPanel;
    }

    private void ToggleInvenPanel()
    {
        invenPanel.SetActive(!invenPanel.activeSelf);

        if(invenPanel.activeSelf)
            StartCoroutine(Co_FadeIn(invenPanel.GetComponent<Image>()));
    }

    private void ToggleFullPanel()
    {
        bool isActive = storePanel.activeSelf;

        storePanel.SetActive(!isActive);
        invenPanel.SetActive(!isActive);

        var storeImg = storePanel.GetComponent<Image>();
        var invenImg = invenPanel.GetComponent<Image>();

        if (storePanel.activeSelf)
        {
            StartCoroutine(Co_FadeIn(storeImg));
            StartCoroutine(Co_FadeIn(invenImg));
        }
    }

    IEnumerator Co_FadeIn(Image img)
    {
        var color = img.color;
        color.a = 0f;
        img.color = color;

        float duration = 0.5f;
        float time = 0f;
        while(time < duration)
        {
            time += Time.deltaTime;
            color.a = Mathf.Clamp(time / duration * 0.5f, 0f, 0.5f);
            img.color = color;

            yield return null;
        }

        color.a = 0.5f;
        img.color = color;
    }
    
}
