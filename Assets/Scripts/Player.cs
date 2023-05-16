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
    public float moneyCount;

    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TMP_Text moneyText;
    public bool canSell;

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
                if (moneyCount >=item.price)
                {
                    moneyCount -= item.price;
                    moneyText.text = moneyCount.ToString();

                    seller.itemList.Remove(item);
                    itemList.Add(item);
                    inventoryManager.ListItems();
                }
            }
            else                  //sell
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
            Debug.Log("dressup");
            //ToDo: dressUp
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Seller"))
        {
            canSell = true;
            seller = col.GetComponent<Seller>();
            inventoryManager.ListItems();
            inventoryPanel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Seller"))
        {
            canSell = false;
            inventoryManager.ListItems();
            inventoryPanel.SetActive(false);
        }
    }
}