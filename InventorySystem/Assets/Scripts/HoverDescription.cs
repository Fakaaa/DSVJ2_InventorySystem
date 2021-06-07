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
        itemWeight.gameObject.SetActive(false);
        itemDurability.gameObject.SetActive(false);
        itemLvlRequirement.gameObject.SetActive(false);
    }
    void Update()
    {
        mousePosition = Input.mousePosition;

        if(mousePosition.y > (Screen.height / 2))
            panelHover.transform.position = new Vector2(mousePosition.x - (transformPanel.rect.xMax * offsetMouseToPanel), mousePosition.y + (transformPanel.rect.yMin * offsetMouseToPanel));
        else if(mousePosition.y < (Screen.height / 2))
            panelHover.transform.position = new Vector2(mousePosition.x - (transformPanel.rect.xMax * offsetMouseToPanel), mousePosition.y + (transformPanel.rect.yMax * offsetMouseToPanel));

        Debug.Log(mousePosition);
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

        switch (itemHover.itemType)
        {
            case Item.ItemType.Weapon:
                itemType.text = "Type: Weapon";
                switch (itemHover.subType)
                {
                    case Item.SubType.Spear:
                        itemSubtype.text = "Subtype: Spears";
                        break;
                    case Item.SubType.Shield:
                        itemSubtype.text = "Subtype: Shields";
                        break;
                    case Item.SubType.Sword:
                        itemSubtype.text = "Subtype: Swords";
                        break;
                    case Item.SubType.LongBow:
                        itemSubtype.text = "Subtype: Long Bows";
                        break;
                    case Item.SubType.ShortBow:
                        itemSubtype.text = "Subtype: Short Bows";
                        break;
                    case Item.SubType.Maze:
                        itemSubtype.text = "Subtype: Mazes";
                        break;
                    case Item.SubType.Axe:
                        itemSubtype.text = "Subtype: Axes";
                        break;
                    case Item.SubType.BattleAxe:
                        itemSubtype.text = "Subtype: Heavy Axes";
                        break;
                    case Item.SubType.Knife:
                        itemSubtype.text = "Subtype: Knifes";
                        break;
                    case Item.SubType.Hammer:
                        itemSubtype.text = "Subtype: Hammers";
                        break;
                }
                break;
            case Item.ItemType.Armor:
                itemType.text = "Type: Armor";
                switch (itemHover.subType)
                {
                    case Item.SubType.Chestplate:
                        itemSubtype.text = "Subtype: Chestplate";
                        break;
                    case Item.SubType.Boots:
                        itemSubtype.text = "Subtype: Boots";
                        break;
                    case Item.SubType.Helmet:
                        itemSubtype.text = "Subtype: Helmet";
                        break;
                }
                break;
        }
        itemWeight.gameObject.SetActive(true);
        itemWeight.text = "Weight:"+ itemHover.weight.ToString();
        itemDurability.gameObject.SetActive(true);
        itemDurability.text = "Durability:"+ itemHover.durability.ToString();
        itemLvlRequirement.gameObject.SetActive(true);
        itemLvlRequirement.text = "Level Required:"+ itemHover.levelRequirement.ToString();
    }
}
