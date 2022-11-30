using System.Runtime.InteropServices;
using UnityEngine;

namespace EVM
{
    public class ERC1155 : MonoBehaviour
    {
        /// <summary>Returns the URI for token type id. If the {id} substring is present in the URI, it must be replaced by clients with the actual token type ID.</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        ///  <paam name="id">Tokens' id.</param>
        [DllImport("__Internal")]
        public static extern void RequestERC1155Uri(string contract,int id);
        
        /// <summary>Returns the amount of tokens of token type id owned by account.Requirements: account cannot be the zero address.</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        /// <paam name="account">account  of Token owner.</param>
        ///  <paam name="id">Token's id.</param>
        [DllImport("__Internal")]
        public static extern void RequestERC1155BalanceOf(string contract, string account,int id);
        
        /// <summary>Batched version of balanceOf.Requirements:accounts and ids must have the same length.</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        /// <paam name="account">Array account  of Token owner.</param>
        ///  <paam name="id">Array Token's id.</param>
        [DllImport("__Internal")]
        public static extern void RequestERC1155BalanceOfBatch(string contract, string[] account,int[] id);
        
        /// <summary>Grants or revokes permission to operator to transfer the caller’s tokens, according to approved.Emits an ApprovalForAll event. Requirements: operator cannot be the caller.</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        /// <param name="_operator">contract address that may or may not use the tokens.</param>
        /// <param name="approved">False or True if want other contract use the tokens</param>
        [DllImport("__Internal")]
        public static extern void SendERC1155SetApprovalForAll(string contract,string _operator,bool approved);
        
        /// <summary>Returns true if operator is approved to transfer account's tokens. See setApprovalForAll.</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        /// <param name="account">Address of owner token.</param>
        /// <param name="_operator">contract address that may or may not use the tokens.</param>
        [DllImport("__Internal")]
        public static extern void RequestERC1155IsApprovedForAll(string contract,string account, string _operator);
        
        /// <summary>Transfers amount tokens of token type id from from to to.Emits a TransferSingle event.Requirements:to cannot be the zero address.If the caller is not from, it must have been approved to spend from's tokens via setApprovalForAll.from must have a balance of tokens of type id of at least amount.If to refers to a smart contract, it must implement</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        [DllImport("__Internal")]
        public static extern void SendERC1155SafeTransferFrom(string contract,string from, string to, int id, long amount,string data);
       
        /// <summary>Batched version of safeTransferFrom.Emits a TransferBatch event.Requirements:ids and amounts must have the same length.If to refers to a smart contract, it must implement IERC1155Receiver.onERC1155BatchReceived and return the acceptance magic value.</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        [DllImport("__Internal")]
        public static extern void SendERC1155SafeBatchTransferFrom(string contract,string from, string to, int id, long amount,string data);
        
        /// <summary>Emitted when value tokens of token type id are transferred from from to to by operator.</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        [DllImport("__Internal")]
        public static extern void SendERC1155TransferSingle(string contract,string _operator, string from, string to , int id, long amount,string data);
        
        /// <summary>Equivalent to multiple TransferSingle events, where operator, from and to are the same for all transfers.</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        [DllImport("__Internal")]
        public static extern void SendERC1155TransferBatch(string contract,string _operator, string from, string to , int[] id, long[] amount,string data);
       
        /// <summary>Emitted when account grants or revokes permission to operator to transfer their tokens, according to approved.</summary>
        /// <param name="contract">Address of contract you want to use.</param>
        [DllImport("__Internal")]
        public static extern void SendERC1155ApprovalForAll(string contract,string account,string _operator,bool approved);

        /// <summary>Returns last url of the contract tokens.</summary>
        public static string getUri = "";
        /// <summary>Returns last  balance of token.</summary>
        public static string getBalanceOf = "";
        /// <summary>Returns last array balance of tokens.</summary>
        public static string getBalanceOfBatch = "";
        /// <summary>Returns last contract allows to use the token.</summary>
        public static string getIsApprovedForAll = "";
        public void Uri(string value)
        {
            getUri = value;
        }
        
        public void BalanceOf(string value)
        { 
            getBalanceOf = value;
        }

        public void BalanceOfBatch(string value)
        {
            getBalanceOfBatch = value;
        }

        public void IsApprovedForAll(string value)
        {
            getIsApprovedForAll = value;
        }
    }
}