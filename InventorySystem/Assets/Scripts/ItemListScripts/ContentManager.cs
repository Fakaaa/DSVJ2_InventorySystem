using System.Collections.Generic;
using UnityEngine;

public class ContentManager : MonoBehaviour
{
    [SerializeField] ItemManager itemOfInstanciate;
    public List<ItemManager> itemList;

    [SerializeField] public bool persistData;

    public delegate void ReturnedItem(ref Item _item);
    public ReturnedItem returnedItem;

    private Item dataLoaded = null;

    private void Awake()
    {
        if (!persistData)
            SaveSystem.ResetAllData();
    }

    void Start() {
        itemList = new List<ItemManager>();
        dataLoaded = new Item();
        if(persistData)
        {
            Debug.Log("entro");
            for(int i = 0; i < SaveSystem.GetPreviusCountItemsSaved(); i++)
            {
                SaveSystem.LoadItem(dataLoaded, i);
                SetItemToList(dataLoaded);
            }
        }
    }

    public void SetItemToList(Item _item){
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

    public List<Item> CatchItemList()
    {
        List<Item> _items = new List<Item>();
        for (int i = 0; i < itemList.Count; i++)
        {
            _items.Add(itemList[i].item);
        }
        return _items;
    }

    private void OnDisable()
    {
        //SaveSystem.SaveItem(CatchItemList());
        for(int i = 0; i < itemList.Count; i++)
        {
            SaveSystem.SaveItem(itemList[i].item, i);
            Debug.Log("name " + itemList[i].name);
        }
    }
}
