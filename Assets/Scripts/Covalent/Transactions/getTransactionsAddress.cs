using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using static Covalent.Base;

namespace Covalent
{
    public partial class Transactions
    {
        public class TransactionsAddress
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
                public string address;
                public string updated_at;
                public string next_update_at;
                public string quote_currency;
                public int chain_id;
                public Item[] items;
                public Pagination pagination;
            }
            [Serializable]
            public class Pagination
            {
                public bool has_more;
                public int page_number;
                public int page_size;
                public object total_count;
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
                public int? sender_contract_decimals;
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
                public object value;
            }

        }
        /// <summary>Given chain_id and wallet address, return all transactions along with their decoded log events. This endpoint does a deep-crawl of the blockchain to retrieve all kinds of transactions that references the address including indexed topics within the event logs.</summary>
        /// <param name="address">Passing in an ENS resolves automatically.</param>
        /// <param name="noLogs">Setting this to true will omit decoded event logs, resulting in lighter and faster responses. By default it's set to false.</param>
        /// <param name="blockSignedAtAsc">Sort the transactions in chronological ascending order. By default, it's set to false and returns transactions in chronological descending order.</param>
        /// <param name="pageNumber">The specific page to be returned.</param>
        /// <param name="pageSize">The number of results per page.</param>
        public static async Task<TransactionsAddress.Request> AsyncGetTransactionsAddress(
                string address, 
                bool noLogs = false, 
                bool blockSignedAtAsc = false, 
                int pageNumber = 0,
                int pageSize = 100)
        {
            string url = $"https://api.covalenthq.com/v1/{Settings.ChainId}/address/{address}/transactions_v2/?quote-currency=USD&format=JSON&block-signed-at-asc={blockSignedAtAsc}&no-logs={noLogs}&page-number={pageNumber}&page-size={pageSize}&key={Settings.Apikey}";
            var result = await WebRequest.AsyncGetRquest(url);
            if (result.Item2 != 200)
            {
                return null;
            }
            return JsonUtility.FromJson<TransactionsAddress.Request>(result.Item1);
        }
    }
}