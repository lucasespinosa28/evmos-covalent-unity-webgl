using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using static Covalent.Base;

namespace Covalent
{
    public partial class Base
    {
        /// <summary>Given chain_id , start_date and end_date, return all the block height(s) of a particular chain within a date range. If the end_date is set to latest, return every block height from the start_date to now.</summary>
        /// <param name="startDate">The start datetime of the block height(s). (yyyy-MM-ddTHH:mm:ssZ), eg: 2020-01-01 or 2020-01-01T03:36:50z</param>
        /// <param name="endDate">The ending datetime of the block height(s). (yyyy-MM-ddTHH:mm:ssZ), eg: 2020-01-02 or 2020-01-02T03:36:50z</param>
        /// <param name="pageNumber">The specific page to be returned.</param>
        /// <param name="pageSize">The number of results per page.</param>
        public static async Task<Block.Request> AsyncGetBlockHeight(string startDate,string endDate,int pageNumber = 0, int pageSize = 10)
        {
            string url = $"https://api.covalenthq.com/v1/{Settings.ChainId}/block_v2/{startDate}/{endDate}/?quote-currency=USD&format=JSON&page-number={pageNumber}&page-size={pageSize}&key={Settings.Apikey}";
            var result = await WebRequest.AsyncGetRquest(url);
            if (result.Item2 != 200)
            {
                return null;
            }
            return JsonUtility.FromJson<Block.Request>(result.Item1);
        }
    }
}