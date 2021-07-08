using System;
using UnityEngine.UI;
using UnityEngine;

//this script is only to add custom click evennt to [BUY] buttons
public static class ButtonExtension 
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick) {
        button.onClick.AddListener(delegate ()
        {
            OnClick(param);
        });
    }
}
