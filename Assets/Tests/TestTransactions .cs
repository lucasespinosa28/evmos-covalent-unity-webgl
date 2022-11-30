using NUnit.Framework;
using Assets.Tests;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

public class TestTransactions
{
    public TestTransactions()
    {
        Covalent.Settings.Apikey = TestSettings.Apikey;
    }
    [Test]
    public async Task GetTransactionsAddress()
    {

        var result = await Covalent.Transactions.AsyncGetTransactionsAddress("0xa79E63e78Eec28741e711f89A672A4C40876Ebf3", false,false,0,10);
        Assert.IsNotNull(result, JsonUtility.ToJson(result));
        foreach (var item in result.data.items)
        {
            Assert.IsTrue(item.tx_hash.Contains("0x"));
        }
    }
    [Test]
    public async Task GetTransactions()
    {
        var result = await Covalent.Transactions.AsyncGetTransactions("0xbda92389200cadac424d64202caeab70cd5e93756fe34c08578adeb310bba254");
        Assert.IsNotNull(result, JsonUtility.ToJson(result));
        foreach (var item in result.data.items)
        {
            Assert.IsTrue(item.tx_hash.Contains("0x"));
        }
    }
}
