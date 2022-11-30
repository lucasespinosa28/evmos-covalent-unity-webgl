# evmos-covalent-unity-webgl

![Game](https://user-images.githubusercontent.com/52639395/204915702-7d663013-c2d2-470f-bcaf-f3a114c2f7dc.jpg)

# Wallet
# covalent

### Covalent.Settings
Set aa api key to access covalent Api.
```Csharp
  public static string Apikey;
```
Get or Set chain id, default is EVMOS Testnet 9000.
```Csharp
   public static string ChainId;
```
Use mainnet to get EVMOS mainnet id or Testnet for it id.
```Csharp
  public static void SetChainId(string id)
```
### Covalent.Balance
#### Get ERC20 token transfers for address
Given chain_id, wallet address and contract-address , return all ERC20 token contract transfers along with their historical prices at the time of their transfer.\

**[address]:** Passing in an ENS resolves automatically.\
**[contract]:** Smart contract address.\
**[pageNumber]:** The specific page to be returned.\
**[pageSize]:** The number of results per page.\
**[startingBlock]:** Starting block to define a block range.\
**[endingBlock]:** Ending block to define a block range.

```Csharp
  public static async Task<ERC20TokenTransfers.Request> AsyncGetERC20TokenTransfers(string address, string contract,int pageNumber, int pageSize, long startingBlock, long endingBlock1)
```
#### Get historical portfolio value over time
Given chain_id and wallet address, return wallet value for the last 30 days at 24 hour interval timestamps.

**[address:]** Passing in an ENS resolves automatically.
```Csharp
  public static async Task<HistoricalPortfoliValue.Request> AsyncGetHistoricalPortfoliValue(string address)
```
### Get token balances for address
Given chain_id and wallet address , return current token balances along with their spot prices. This endpoint supports a variety of token standards like ERC20, ERC721 and ERC1155. As a special case, network native tokens like ETH on Ethereum are also returned even though it's not a token contract.

**[address]:** Passing in an ENS resolves automatically.\
**[nft]:** Set to true to return ERC721 and ERC1155 assets. Defaults to false.\
**[noNftFetch]:** Set to true to skip fetching NFT metadata, which can result in faster responses. Defaults to false and only applies when nft=true.
```Csharp
  public static async Task<TokenBalancesAddres.Request> AsyncGetTokenBalancesAddress(string address, bool nft, bool noNftFetch)
```
### Get token holders as of any block height
Given chain_id and wallet address, return a paginated list of token holders. If block-height  is omitted, the latest block is used.

**[address]:** Passing in an ENS resolves automatically.\
**[blockHeight]:** Ending block to define a block range. Passing in latest uses the latest block height.\
**[startingBlock]:** Starting block to define a block range.\
**[endingBlock]:** Ending block to define a block range
```Csharp
  public static async Task<TokenHoldersBlockHeight.Request> AsyncGetTokenHoldersBlockHeight(string address,string blockHeight, long startingBlock,long endingBlock)
```
### Covalent.Transactions
#### Get a transaction
Given chain_id and tx_hash, return the transaction data with their decoded event logs.

**[txHash]:** Hex encoded transaction hash.\
**[noLogs]:** Setting this to true will omit decoded event logs, resulting in lighter and faster responses. By default it's set to false.\
**[pageNumber]:** The specific page to be returned.\
**[pageSize]:** The number of results per page.
```Csharp
public static async Task<GetTransactions.Request> AsyncGetTransactions(string txHash, bool noLogs, int pageNumber, int pageSize)
```
#### Get transactions for address
Given chain_id and wallet address, return all transactions along with their decoded log events. This endpoint does a deep-crawl of the blockchain to retrieve all kinds of transactions that references the address including indexed topics within the event logs.

**[address]:** Passing in an ENS resolves automatically.\
**[noLogs]:** Setting this to true will omit decoded event logs, resulting in lighter and faster responses. By default it's set to false.\
**[blockSignedAtAsc]:** Sort the transactions in chronological ascending order. By default, it's set to false and returns transactions in chronological descending order.\
**[pageNumber]:** The specific page to be returned.\
**[pageSize]:** The number of results per page.
```Csharp
 public static async Task<TransactionsAddress.Request> AsyncGetTransactionsAddress(string address, bool noLogs, bool blockSignedAtAsc,int pageNumber, int pageSize)
```
