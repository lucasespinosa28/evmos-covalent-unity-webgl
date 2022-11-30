using System;
using System.Threading.Tasks;
using UnityEngine;

namespace Covalent
{
    public partial class Base
    {
        public class Block
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
                public DateTime signed_at;
                public int height;
            }
        }
        /// <summary>Given chain_id and block_height, return a single block at block_height. If block_height is set to the value latest, return the latest block available.</summary>
        /// <param name="blockHeight">The height of the block.</param>
        public static async Task<Block.Request> AsyncGetblock(string blockHeight = "latest")
        {
            string url = $"https://api.covalenthq.com/v1/{Settings.ChainId}/block_v2/{blockHeight}/?key={Settings.Apikey}";
            var result = await WebRequest.AsyncGetRquest(url);
            if (result.Item2 != 200)
            {
                return null;
            }
            return JsonUtility.FromJson<Block.Request>(result.Item1);
        }

    }
}