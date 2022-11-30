using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace EVM
{
    public class ERC20: MonoBehaviour
    {
        /// <summary>Returns the name of the token.</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        [DllImport("__Internal")]
        private static extern void RequestERC20Name(string contract);
       
        /// <summary>Returns the symbol of the token.</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        [DllImport("__Internal")]
        private static extern void RequestERC20Symbol(string contract);
        
        /// <summary>Returns the decimals places of the token.</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        [DllImport("__Internal")]
        private static extern void RequestERC20Decimals(string contract);
        
        /// <summary>Returns the amount of tokens in existence.</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        [DllImport("__Internal")]
        private static extern void RequestERC20TotalSupply(string contract);
        
        /// <summary>Returns the amount of tokens owned by account</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        /// <param name="account">Address of user balance.</param>
        [DllImport("__Internal")]
        private static extern void RequestERC20BalanceOf(string contract,string account);
        
        /// <summary>Moves amount tokens from the caller’s account to to. Returns a boolean value indicating whether the operation succeeded.Emits a transfer event.</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        /// <param name="to">address to transfer the token.</param>
        /// <param name="amount">Amount of token to transfer</param>
        [DllImport("__Internal")]
        private static extern void SendERC20Transfer(string contract,string to,long amount);
        
        /// <summary>Returns the remaining number of tokens that spender will be allowed to spend on behalf of owner through transferFrom. This is zero by default. This value changes when approve or transferFrom are called.</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        /// <param name="owner">Owner of token.</param>
        /// <param name="spender">Contract allowed to use its token.</param>
        [DllImport("__Internal")]
        private static extern void SendERC20Allowance(string contract,string owner,string spender); 
        
        /// <summary>Sets amount as the allowance of spender over the caller’s tokens. Returns a boolean value indicating whether the operation succeeded.</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        /// <param name="contract">Contract allowed to use its token.</param>
        /// <param name="contract">Amount of tokens allowed to use is the contract.</param>
        [DllImport("__Internal")]
        private static extern void SendERC20Approve(string contract,string sender,long amount);

        /// <summary>Returns the name of the Last contract called token.</summary>
        public static string getName = "";
        /// <summary>Returns the name of the Last contract called Symbol.</summary>
        public static string getSymbo = "";
        /// <summary>Returns the name of the Last contract called Decimals.</summary>
        public static string getDecimals = "";
        /// <summary>Returns the name of the Last contract called Total Supply.</summary>
        public static string getTotalSupply = "";
        /// <summary>Returns the name of the Last contract called Balance.</summary>
        public static string getBalanceOf = "";
        
        void ERC20Name(string value)
        {
            getName = value;
        }
        
        void ERC20Symbol(string value)
        {
            getSymbo = value;
        }
        
        void ERC20Decimals(string value)
        {
            getDecimals = value;
        }
        
        void ERC20TotalSupply(string value)
        {
            getTotalSupply = value;
        }
        
        void ERC20BalanceOf(string value)
        {
            getBalanceOf = value;
        }
    }
}