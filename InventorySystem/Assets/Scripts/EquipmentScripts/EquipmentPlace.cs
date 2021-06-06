using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentPlace : MonoBehaviour, IPointerClickHandler
{
    public delegate void ItemPlace(ref Item _itemIn);
    public ItemPlace itemPlace;
    Item itemAtPlace = null;
    Button itemPlaceButton;
    [SerializeField] Sprite defaultIcon;

    void Start()
    {
        itemPlaceButton = GetComponent<Button>();
    }

    public void OnPointerClick(PointerEventData pointerEventData){
        if (pointerEventData.button == PointerEventData.InputButton.Left) {
            if(itemAtPlace != null){
                itemPlace?.Invoke(ref itemAtPlace);
                itemPlaceButton.image.sprite = defaultIcon;
                itemAtPlace = null;
            }
        }
    }

    public void ChangeData(ref Item _itemIn){
        if(itemAtPlace == null){
            itemAtPlace = _itemIn;
            itemPlaceButton.image.sprite = _itemIn.icon;
        }
        else if(itemAtPlace == _itemIn){
            itemPlace?.Invoke(ref _itemIn);
        }
        else{
            itemPlace?.Invoke(ref itemAtPlace);
            itemAtPlace = _itemIn;
            itemPlaceButton.image.sprite = _itemIn.icon;
        }
    }
}
