using NUnit.Framework;
using Assets.Tests;
using System.Threading.Tasks;
using System.Collections;
using UnityEngine;

public class TestBase
{
    public TestBase()
    {
        Covalent.Settings.Apikey = TestSettings.Apikey;
    }
    [Test]
    public async Task Getblock()
    {
        var result = await Covalent.Base.AsyncGetblock();
        Assert.IsNotNull(result, JsonUtility.ToJson(result));
        Assert.IsTrue(result.data.items[0].height > 16049970);
    }
    [Test]
    public async Task GetBlockHeight()
    {
        var result = await Covalent.Base.AsyncGetBlockHeight("2021-01-01", "2021-01-03");
        Assert.IsNotNull(result, JsonUtility.ToJson(result));
        Assert.IsTrue(result.data.items[0].height == 11565019);
    }
    [Test]
    public async Task GetLogEventsContract()
    {
        var result = await Covalent.Base.AsyncGetLogEventsContract("0xc0da01a04c3f3e0be433606045bb7017a7323e38", 12115107, 12240004);
        Assert.IsNotNull(result, JsonUtility.ToJson(result));
        Assert.IsTrue(result.data.items[0].block_height == 12115107);
    }
    [Test]
    public async Task GetLogEventsTopic()
    {
        var result = await Covalent.Base.AsyncGetLogEventsTopic("0x804c9b842b2748a22bb64b345453a3de7ca54a6ca45ce00d415894979e22897a", 12500000, 12500100);
        Assert.IsNotNull(result, JsonUtility.ToJson(result));
        Assert.IsTrue(result.data.items[0].block_height == 12500001);
    }
    [Test]
    public async Task GetAllChains()
    {
        var result = await Covalent.Base.AsyncGetAllChains();
        Assert.IsNotNull(result, JsonUtility.ToJson(result));
        Assert.IsTrue(result.data.items[0].name.Contains("eth-mainnet"));
    }
    [Test]
    public async Task GetAllChainStatuses()
    {
        var result = await Covalent.Base.AsyncGetAllChainStatuses();
        Assert.IsNotNull(result, JsonUtility.ToJson(result));
        Assert.IsTrue(result.data.items[0].name.Contains("eth-mainnet"));
    }
}
