using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using static Covalent.Base;

namespace Covalent
{
    public partial class Base
    {
        public class LogEventsTopic
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
                public int tx_offset;
                public int log_offset;
                public string tx_hash;
                public string[] raw_log_topics;
                public int sender_contract_decimals;
                public object sender_name;
                public object sender_contract_ticker_symbol;
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
        /// <summary>Given chain_id and topic hash(es), return a paginated list of decoded log events with one or more topic hashes separated by a comma.</summary>
        /// <param name="topic">Topic hash value from log records.</param>
        /// <param name="secondaryTopics">Additional topic hash(es) to filter on -- padded & unpadded address fields are supported.</param>
        /// <param name="startingBlock">Starting block to define a block range.</param>
        /// <param name="endingBlock">Ending block to define a block range. Passing in latest uses the latest block height.</param>
        /// <param name="senderAddress">Topic hash value from log records.</param>
        /// <param name="pageNumber">The specific page to be returned.</param>
        /// <param name="pageSize">The number of results per page.</param>
        public static async Task<LogEventsTopic.Request> AsyncGetLogEventsTopic(
            string topic,
            long startingBlock,
            long endingBlock,
            string secondaryTopics = null,
            string senderAddress = null,
            int pageNumber = 0,
            int pageSize = 10)
        {
            secondaryTopics = secondaryTopics == null? "" : $"&secondary - topics ={secondaryTopics}";
            senderAddress = senderAddress == null ? "" : $"&sender-address=={senderAddress}";
            string url = $"https://api.covalenthq.com/v1/{Settings.ChainId}/events/topics/{topic}/?quote-currency=USD&format=JSON&starting-block={startingBlock}&ending-block={endingBlock}{senderAddress}{secondaryTopics}&page-number={pageNumber}&page-size={pageSize}&key={Settings.Apikey}";
            var result = await WebRequest.AsyncGetRquest(url);
            if (result.Item2 != 200)
            {
                return null;
            }
            return JsonUtility.FromJson<LogEventsTopic.Request>(result.Item1);
        }
    }
}