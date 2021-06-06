using UnityEngine;
using UnityEngine.UI;

public class HoverDescription : MonoBehaviour
{
    [SerializeField] GameObject panelHover;

    [SerializeField] Image icon;
    [SerializeField] Text itemName;
    [SerializeField] Text itemType;
    [SerializeField] Text itemSubtype;
    [SerializeField] Text itemWeight;
    [SerializeField] Text itemDurability;
    [SerializeField] Text itemLvlRequirement;
    private Vector3 mousePosition;

    private void Start()
    {
        ItemManager.isMouseHoveringEnter += ActivatePanel;
        ItemManager.isMouseHoveringExit += DeactivePanelHover;

        DeactivePanelHover();
    }
    private void OnDisable()
    {
        ItemManager.isMouseHoveringEnter -= ActivatePanel;
        ItemManager.isMouseHoveringExit -= DeactivePanelHover;
    }
    void DeactivePanelHover()
    {
        panelHover.GetComponent<CanvasRenderer>().SetAlpha(0);
        icon.gameObject.SetActive(false);
        itemName.gameObject.SetActive(false);
        itemType.gameObject.SetActive(false);
        itemSubtype.gameObject.SetActive(false);
        itemWeight.gameObject.SetActive(false);
        itemDurability.gameObject.SetActive(false);
        itemLvlRequirement.gameObject.SetActive(false);
    }
    void Update()
    {
        mousePosition = Input.mousePosition;

        panelHover.transform.position = new Vector2(mousePosition.x - (panelHover.GetComponent<RectTransform>().rect.xMax * 0.8f),
            mousePosition.y + (panelHover.GetComponent<RectTransform>().rect.yMin * 0.8f));
    }

    public void ActivatePanel(ref Item itemHover)
    {
        panelHover.GetComponent<CanvasRenderer>().SetAlpha(100);
        icon.gameObject.SetActive(true);
        icon.sprite = itemHover.icon;
        itemName.gameObject.SetActive(true);
        itemName.text = itemHover.name;
        itemType.gameObject.SetActive(true);
        switch (itemHover.itemType)
        {
            case Item.ItemType.Weapon:
                itemType.text = "Type: Weapon";
                break;
            case Item.ItemType.Chestplate:
                itemType.text = "Type: Chestplate";
                break;
            case Item.ItemType.Boots:
                itemType.text = "Type: Boots";
                break;
            case Item.ItemType.Helmet:
                itemType.text = "Type: Helmet";
                break;
        }
        itemSubtype.gameObject.SetActive(true);
        itemWeight.gameObject.SetActive(true);
        itemDurability.gameObject.SetActive(true);
        itemLvlRequirement.gameObject.SetActive(true);
    }
}
