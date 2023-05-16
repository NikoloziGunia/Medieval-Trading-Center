using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public Player player;
    public TMP_Text price;
    public Image icon;
    public GameObject blocker;

     public Item item;

    private void Start()
    {
        price.text = item.price.ToString();
        icon.sprite = item.icon;
        if (player.moneyCount >= item.price) blocker.SetActive(false);
        else blocker.SetActive(true);
    }

    public void Sell()
    {
        player.UseItem(item);
    }
}