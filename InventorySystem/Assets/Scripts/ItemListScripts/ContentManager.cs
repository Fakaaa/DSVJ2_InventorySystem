using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentManager : MonoBehaviour
{
    [SerializeField] ItemManager itemOfInstanciate;
    public List<ItemManager> itemList;

    public delegate void ReturnedItem(ref Item _item);
    public ReturnedItem returnedItem;

    void Start(){
        itemList = new List<ItemManager>();
    }

    public void SetItemToList(ref Item _item){
        itemList.Add(Instantiate(itemOfInstanciate, new Vector3(0f, 0f, 0f), Quaternion.identity, transform));
        for(int i = 0; i < itemList.Count; i++){
            if(!itemList[i].imSetItem){
                itemList[i].returnItem += GetItemToList;
                itemList[i].item = _item;
                itemList[i].isGetItem = true;
                itemList[i].imSetItem = true;
                itemList[i].UpdateData();
                break;
            }
        }
    }

    void GetItemToList(){
        for(int i = 0; i < itemList.Count; i++){
            if(itemList[i].isReturnData){
                returnedItem?.Invoke(ref itemList[i].item);
                Destroy(itemList[i].transform.gameObject);
                itemList.Remove(itemList[i]);
                break;
            }
        }
    }
}
