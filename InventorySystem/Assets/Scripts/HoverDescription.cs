using UnityEngine;
using UnityEngine.UI;

public class HoverDescription : MonoBehaviour
{
    [SerializeField] GameObject panelHover;

    [SerializeField] Image icon;
    [SerializeField] Image uwu;
    [SerializeField] Text itemName;
    [SerializeField] Text itemType;
    [SerializeField] Text itemSubtype;
    [SerializeField] Text itemWeight;
    [SerializeField] Text itemDurability;
    [SerializeField] Text itemLvlRequirement;
    [SerializeField] Text itemPropierty;
    private Vector3 mousePosition;
    [SerializeField] private float offsetMouseToPanel;

    private RectTransform transformPanel;

    private void Start()
    {
        ItemManager.isMouseHoveringEnter += ActivatePanel;
        ItemManager.isMouseHoveringExit += DeactivePanelHover;

        transformPanel = panelHover.GetComponent<RectTransform>();
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
        itemPropierty.gameObject.SetActive(false);
        itemWeight.gameObject.SetActive(false);
        itemDurability.gameObject.SetActive(false);
        itemLvlRequirement.gameObject.SetActive(false);
        uwu.gameObject.SetActive(false);
    }
    void Update()
    {
        mousePosition = Input.mousePosition;

        if(mousePosition.y > (Screen.height / 2))
            panelHover.transform.position = new Vector2(mousePosition.x - (transformPanel.rect.xMax * offsetMouseToPanel), mousePosition.y + (transformPanel.rect.yMin * offsetMouseToPanel));
        else if(mousePosition.y < (Screen.height / 2))
            panelHover.transform.position = new Vector2(mousePosition.x - (transformPanel.rect.xMax * offsetMouseToPanel), mousePosition.y + (transformPanel.rect.yMax * offsetMouseToPanel));
    }

    public void ActivatePanel(ref Item itemHover)
    {
        panelHover.GetComponent<CanvasRenderer>().SetAlpha(100);
        icon.gameObject.SetActive(true);
        icon.sprite = itemHover.icon;
        itemName.gameObject.SetActive(true);
        itemName.text = itemHover.name;
        itemType.gameObject.SetActive(true);
        itemSubtype.gameObject.SetActive(true);
        itemPropierty.gameObject.SetActive(true);

        if (itemHover is ItemWeapon)
        {
            ItemWeapon downCast = (ItemWeapon)itemHover;
            itemPropierty.text = "Damage:" + downCast.damage.ToString();
        }
        else if(itemHover is ItemArmor)
        {
            ItemArmor downCast = (ItemArmor)itemHover;
            itemPropierty.text = "Defense:" + downCast.defense.ToString();
        }
        else
        {
            itemPropierty.text = "Value:" + itemHover.weight * itemHover.levelRequirement;
        }

        itemType.text = "Type:" + itemHover.itemType.ToString();
        itemSubtype.text = "Subtype:" + itemHover.subType.ToString();

        itemWeight.gameObject.SetActive(true);
        itemWeight.text = "Weight:"+ itemHover.weight.ToString();
        itemDurability.gameObject.SetActive(true);
        itemDurability.text = "Durability:"+ itemHover.durability.ToString();
        itemLvlRequirement.gameObject.SetActive(true);
        itemLvlRequirement.text = "Level Required:"+ itemHover.levelRequirement.ToString();
        uwu.gameObject.SetActive(true);
    }
}
