using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Seller seller;

    public List<Item> itemList = new();
    public Collider2D Curseller;
    public GameObject questionPanel;
    
    public float moneyCount;
    public bool canSell;

    [SerializeField] private List<ItemVisual> itemVisuals;
    [SerializeField] private TMP_Text moneyText;

    
    private void Start()
    {
        moneyText.text = moneyCount.ToString();
    }

    public void UseItem(Item item)
    {
        if (canSell)
        {
            if (!itemList.Contains(item)) //buy
            {
                if (moneyCount >= item.price)
                {
                    moneyCount -= item.price;
                    moneyText.text = moneyCount.ToString();

                    seller.itemList.Remove(item);
                    itemList.Add(item);
                    inventoryManager.ListItems();
                }
            }
            else //sell
            {
                moneyCount += item.price;
                moneyText.text = moneyCount.ToString();

                itemList.Remove(item);
                seller.itemList.Add(item);
                inventoryManager.ListItems();
            }
        }
        else
        {
            //ToDo: dressUp
            DressUp(item);
        }
    }


    void DressUp(Item item)
    {
        if (item.type == ItemTypes.types.Body)
        {
            foreach (var itemVisual in itemVisuals)
            {
                if (itemVisual.type == ItemTypes.types.Body)
                    itemVisual.gameObject.SetActive(item.id == itemVisual.id);
            }
        }
        else if (item.type == ItemTypes.types.Weapon)
        {
            foreach (var itemVisual in itemVisuals)
            {
                if (itemVisual.type == ItemTypes.types.Weapon)
                    itemVisual.gameObject.SetActive(item.id == itemVisual.id);
            }
        }
        else if (item.type == ItemTypes.types.Head)
        {
            foreach (var itemVisual in itemVisuals)
            {
                if (itemVisual.type == ItemTypes.types.Head)
                    itemVisual.gameObject.SetActive(item.id == itemVisual.id);
            }
        }
         
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Seller"))
        {
            questionPanel.SetActive(true);
            Curseller = col;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Seller"))
        {
            questionPanel.SetActive(false);
            Curseller = null;
            inventoryManager.CloseTradingPanel();
        }
    }
}