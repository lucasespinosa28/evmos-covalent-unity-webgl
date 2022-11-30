using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace EVM
{
    public  class Wallet : MonoBehaviour
    {
        /// <summary>Connect to web tallet and return the mains address of thet wallet</summary>
        [DllImport("__Internal")]
        public static extern void WalletConnect();
        /// <summary>Request the native token balance</summary>
        [DllImport("__Internal")]
        public static extern void WalletBalance();
        
        /// <summary>Get the native token balance</summary>
        public static string getBalance = "";
        /// <summary>Get the main address of thet wallet</summary>
        public static string getAddress = "";
        /// <summary>Get last transcation hash</summary>
        public static string getTxHash = "";
        void NativeAddress(string value)
        {
            getAddress = value;
        }
        void NativeBalance(string value)
        {
            getBalance = value;
            Debug.Log(getBalance);
        }
        
        void NativeTxHash(string value)
        {
            getTxHash = value;
        }
    }
}
