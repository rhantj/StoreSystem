using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DataView : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject storePanel;
    [SerializeField] private GameObject invenPanel;

    [Header("Buttons")]
    [SerializeField] private Button purchaseButton;
    [SerializeField] private Button sellButton;

    private void Start()
    {
        storePanel.SetActive(false);
        invenPanel.SetActive(false);
    }

    private void OnEnable()
    {
        IUIToggleable.OnInventoryToggled += ToggleInvenPanel;
        IUIToggleable.OnFullViewToggled += ToggleFullPanel;

        //purchaseButton.onClick.AddListener(() => _viewModel.PurchaseSelectedItem());
        //sellButton.onClick.AddListener(() => _viewModel.SellSelectedItem());
    }

    private void OnDisable()
    {
        IUIToggleable.OnInventoryToggled -= ToggleInvenPanel;
        IUIToggleable.OnFullViewToggled -= ToggleFullPanel;
    }

    private void ToggleInvenPanel()
    {
        invenPanel.SetActive(!invenPanel.activeSelf);

        if (invenPanel.activeSelf)
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
        while (time < duration)
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