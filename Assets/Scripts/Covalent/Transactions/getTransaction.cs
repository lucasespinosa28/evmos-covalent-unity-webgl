using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using static Covalent.Base;

namespace Covalent
{
    public partial class Transactions
    {
        public class GetTransactions
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
                public int sender_contract_decimals;
                public string sender_name;
                public string sender_contract_ticker_symbol;
                public string sender_address;
                public object sender_address_label;
                public string sender_logo_url;
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
                public string value;
            }

        }
        /// <summary>Given chain_id and tx_hash, return the transaction data with their decoded event logs.</summary>
        /// <param name="txHash">Hex encoded transaction hash.</param>
        /// <param name="noLogs">Setting this to true will omit decoded event logs, resulting in lighter and faster responses. By default it's set to false.</param>
        /// <param name="pageNumber">The specific page to be returned.</param>
        /// <param name="pageSize">The number of results per page.</param>
        public static async Task<GetTransactions.Request> AsyncGetTransactions(string txHash, bool noLogs = false, int pageNumber = 0, int pageSize = 10)
        {
            string url = $"https://api.covalenthq.com/v1/{Settings.ChainId}/transaction_v2/{txHash}/?quote-currency=USD&format=JSON&no-logs={noLogs}&page-number={pageNumber}&page-size={pageSize}&key={Settings.Apikey}";
            var result = await WebRequest.AsyncGetRquest(url);
            if (result.Item2 != 200)
            {
                return null;
            }
            return JsonUtility.FromJson<GetTransactions.Request>(result.Item1);
        }
    }
}