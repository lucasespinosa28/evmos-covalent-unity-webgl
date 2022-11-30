using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Covalent
{
    public partial class NFT
    {
        public class GetNFTTransactions
        {
            [Serializable]
            public class Request
            {
                public Data data;
                public bool error;
                public object error_message;
                public object error_code;
            }
            [Serializable]
            public class Data
            {
                public string updated_at;
                public Item[] items;
                public object pagination;
            }
            [Serializable]
            public class Item
            {
                public int contract_decimals;
                public string contract_name;
                public string contract_ticker_symbol;
                public string contract_address;
                public string[] supports_erc;
                public string logo_url;
                public string type;
                public Nft_Transactions[] nft_transactions;
            }
            [Serializable]
            public class Nft_Transactions
            {
                public DateTime block_signed_at;
                public int block_height;
                public string tx_hash;
                public int tx_offset;
                public bool successful;
                public string from_address;
                public object from_address_label;
                public string to_address;
                public object to_address_label;
                public string value;
                public float value_quote;
                public int gas_offered;
                public int gas_spent;
                public long gas_price;
                public string fees_paid;
                public float gas_quote;
                public float gas_quote_rate;
                public Log_Events[] log_events;
            }
            [Serializable]
            public class Log_Events
            {
                public DateTime block_signed_at;
                public int block_height;
                public int tx_offset;
                public int log_offset;
                public string tx_hash;
                public string[] raw_log_topics;
                public object sender_contract_decimals;
                public object sender_name;
                public object sender_contract_ticker_symbol;
                public string sender_address;
                public object sender_address_label;
                public object sender_logo_url;
                public string raw_log_data;
                public Decoded decoded;
            }
            [Serializable]
            public class Decoded
            {
                public string name;
                public string signature;
                public Param[] _params;
            }
            [Serializable]
            public class Param
            {
                public string name;
                public string type;
                public bool indexed;
                public bool decoded;
                public object value;
            }


        }
        /// <summary>Given chain_id, contract_address and token_id, return a list of transactions.</summary>
        /// <param name="contract">Smart contract address.</param>
        /// <param name="tokenId">The token ID</param>
        /// <param name="pageNumber">The specific page to be returned.</param>
        /// <param name="pageSize">The number of results per page.</param>
        public static async Task<GetNFTTransactions.Request> AsyncGetNFTTransactionsContract(
            string contract, 
            int tokenId,
            int pageNumber = 0,
            int pageSize = 100)
        {
            string url = $"https://api.covalenthq.com/v1/{Settings.ChainId}/tokens/{contract}/nft_transactions/{tokenId}/?quote-currency=USD&format=JSON&page-number={pageNumber}&page-size={pageSize}&key={Settings.Apikey}";
            var result = await WebRequest.AsyncGetRquest(url);
            if (result.Item2 != 200)
            {
                return null;
            }
            return JsonUtility.FromJson<GetNFTTransactions.Request>(result.Item1);
        }
    }
}