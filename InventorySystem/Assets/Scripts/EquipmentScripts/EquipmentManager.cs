using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] InventoryManager inventory;
    [SerializeField] EquipmentPlace helmet;
    [SerializeField] EquipmentPlace chestplate;
    [SerializeField] EquipmentPlace boots;
    [SerializeField] EquipmentPlace weapon;

    void Start()
    {
        helmet.itemPlace += GetItemToPlace;
        chestplate.itemPlace += GetItemToPlace;
        boots.itemPlace += GetItemToPlace;
        weapon.itemPlace += GetItemToPlace;
    }
    private void OnDisable()
    {
        helmet.itemPlace -= GetItemToPlace;
        chestplate.itemPlace -= GetItemToPlace;
        boots.itemPlace -= GetItemToPlace;
        weapon.itemPlace -= GetItemToPlace;
    }

    public void ReciveItem(ref Item _itemIn){
        if(_itemIn.itemType != Item.ItemType.Armor || _itemIn.itemType != Item.ItemType.Weapon){
            inventory.ReciveItemToInventory(_itemIn);
        }
        else{
            switch (_itemIn.itemType) {
                case Item.ItemType.Weapon:
                    weapon.ChangeData(ref _itemIn);
                break;
                case Item.ItemType.Armor:
                    switch (_itemIn.subType)
                    {
                        case Item.SubType.Chestplate:
                            chestplate.ChangeData(ref _itemIn);
                            break;
                        case Item.SubType.Boots:
                            boots.ChangeData(ref _itemIn);
                            break;
                        case Item.SubType.Helmet:
                            helmet.ChangeData(ref _itemIn);
                            break;
                    }
                break;
            }
        }
    }

    void GetItemToPlace(ref Item _itemIn){
        inventory.ReciveItemToInventory(_itemIn);
    }
}
