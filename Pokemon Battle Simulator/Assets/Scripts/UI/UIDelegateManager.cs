﻿using System;
using System.Collections.Generic;
namespace RDUI
{
    public enum UIMessageType
    {
        RefreshParty
    }
    public delegate void UIMessageDelegate(object _args);

    public static class UIDelegateManager
    {
        private static Dictionary<UIMessageType, UIMessageDelegate> messageDelegates = new Dictionary<UIMessageType, UIMessageDelegate>();
        public static void NotifyUI(UIMessageType _messageType, object _value)
        {
            if (messageDelegates.ContainsKey(_messageType))
            {
                if (messageDelegates[_messageType] != null)
                {
                    messageDelegates[_messageType](_value);
                }
            }
        }
        public static void AddObserver(UIMessageType _messageType, UIMessageDelegate _handler)
        {
            if (!messageDelegates.ContainsKey(_messageType))
            {
                messageDelegates.Add(_messageType, null);
            }
            messageDelegates[_messageType] += _handler;
        }
        public static void RemoveObserver(UIMessageType _messageType, UIMessageDelegate _handler)
        {
            if (messageDelegates.ContainsKey(_messageType))
            {
                messageDelegates[_messageType] -= _handler;
            }
        }
        public static void RemoveAllObserver()
        {
            messageDelegates.Clear();
        }
    }

}
