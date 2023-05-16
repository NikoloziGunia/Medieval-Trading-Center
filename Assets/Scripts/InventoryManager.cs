using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Player player;

    [SerializeField] private Transform playerItemContent;
    [SerializeField] private GameObject playerInventoryPanel;
    
    [SerializeField] private Transform itemContent;
    [SerializeField] private Transform sellerItemContent;
    [SerializeField] private GameObject inventoryItem;

    private List<GameObject> allItems = new();


    public void ListItems()
    {
        ClearItems();

        foreach (var item in player.itemList)
        {
            var obj = Instantiate(inventoryItem, itemContent);
            obj.GetComponent<ItemController>().item = item;
            obj.GetComponent<ItemController>().player = player;
            allItems.Add(obj);
        }

        foreach (var item in player.seller.itemList)
        {
            var obj = Instantiate(inventoryItem, sellerItemContent);
            obj.GetComponent<ItemController>().item = item;
            obj.GetComponent<ItemController>().player = player;
            allItems.Add(obj);
        }
    }

    public void OpenPlayers()
    {
        if (!playerInventoryPanel.activeSelf)
        {
            foreach (var item in player.itemList)
            {
                var obj = Instantiate(inventoryItem, playerItemContent);
                obj.GetComponent<ItemController>().item = item;
                obj.GetComponent<ItemController>().player = player;
            }
            playerInventoryPanel.SetActive(true);
        }
        else
        {
            ClosePlayerInventory();
        }
        
    }

    public void ClosePlayerInventory()
    {
        playerInventoryPanel.SetActive(false);
        StartCoroutine(Close());
    }

    IEnumerator  Close()
    {
        while (playerItemContent.childCount > 0)
        {
            Destroy(playerItemContent.GetChild(0).gameObject);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void ClearItems()
    {
        foreach (var item in allItems)
        {
            Destroy(item.GameObject());
        }

        allItems.Clear();
    }
}