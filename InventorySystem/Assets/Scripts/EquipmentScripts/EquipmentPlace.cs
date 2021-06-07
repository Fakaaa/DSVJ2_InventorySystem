using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentPlace : MonoBehaviour, IPointerClickHandler
{
    public delegate void ItemPlace(ref Item _itemIn);
    public ItemPlace itemPlace;
    Item itemAtPlace = null;
    ItemArmor itemPlaceArmor = null;
    ItemWeapon itemPlaceWapon = null;

    Button itemPlaceButton;
    [SerializeField] Sprite defaultIcon;

    void Start()
    {
        itemPlaceButton = GetComponent<Button>();
    }

    //DESEQUIPA
    public void OnPointerClick(PointerEventData pointerEventData){
        if (pointerEventData.button == PointerEventData.InputButton.Left) {
            if(itemAtPlace != null){
                itemPlace?.Invoke(ref itemAtPlace);
                itemPlaceButton.image.sprite = defaultIcon;
                itemAtPlace = null;
                itemPlaceWapon = null;
                itemPlaceArmor = null;
            }
        }
    }

    //EQUIP ITEM
    public void ChangeData(ref Item _itemIn){

        if (itemAtPlace == null)
        {
            itemAtPlace = _itemIn;
            itemPlaceButton.image.sprite = _itemIn.icon;
        }
        else if (itemAtPlace == _itemIn)
        {
            itemPlace?.Invoke(ref _itemIn);
        }
        else
        {
            itemPlace?.Invoke(ref itemAtPlace);
            itemAtPlace = _itemIn;
            itemPlaceButton.image.sprite = _itemIn.icon;
        }

        switch (_itemIn.itemType)
        {
            case Item.ItemType.Weapon:
                itemPlaceWapon = (ItemWeapon)itemAtPlace;
                break;
            case Item.ItemType.Armor:
                itemPlaceArmor = (ItemArmor)itemAtPlace;
                break;
        }
    }
}
