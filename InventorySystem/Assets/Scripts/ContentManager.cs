using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentManager : MonoBehaviour
{
    public Item randomItem;
    [HideInInspector] public bool getItem = false;

    [SerializeField] GameObject itemOfInstanciate;
    List<GameObject> itemList;

    void Start(){
        itemList = new List<GameObject>();
    }

    void Update()
    {
        SetItemToList();
    }

    void SetItemToList(){
        if(getItem){
            itemList.Add(Instantiate(itemOfInstanciate, new Vector3(0f, 0f, 0f), Quaternion.identity, transform));
            for(int i = 0; i < itemList.Count; i++){
                if(!itemList[i].GetComponent<ItemManager>().imSetItem){
                    itemList[i].GetComponent<ItemManager>().item = randomItem;
                    itemList[i].GetComponent<ItemManager>().isGetItem = true;
                    itemList[i].GetComponent<ItemManager>().imSetItem = true;
                    getItem = false;
                    break;
                }
            }
        }
    }
}
