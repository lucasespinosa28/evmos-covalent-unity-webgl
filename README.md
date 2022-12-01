# evmos-covalent-unity-webgl

![Game](https://user-images.githubusercontent.com/52639395/204915702-7d663013-c2d2-470f-bcaf-f3a114c2f7dc.jpg)

# Wallet
### EVM.Wallet
### EVM.ERC20
Returns the name of the token.
**[contract]:** Address of contract you want to use.
```Csharp
private static extern void RequestERC20Name(string contract);
```
**[contract]:** Address of contract you want to use.
```Csharp
private static extern void RequestERC20Symbol(string contract);
```
**[contract]:** Address of contract you want to use.
```Csharp
private static extern void RequestERC20Decimals(string contract);
```
**[contract]:** Address of contract you want to use.
```Csharp
 private static extern void RequestERC20TotalSupply(string contract);
```
**[contract]:** Address of contract you want to use.
```Csharp
private static extern void RequestERC20BalanceOf(string contract,string account);
```

Returns the name of the Last contract called token.
```Csharp
public static string getName;
```
Returns the name of the Last contract called Symbol.
```Csharp
public static string getSymbo;
```
Returns the name of the Last contract called Decimals.
```Csharp
 public static string getDecimals;
```
Returns the name of the Last contract called Total Supply.
```Csharp
public static string getTotalSupply;
```
Returns the name of the Last contract called Balance.
```Csharp
  public static string getBalanceOf;
```
### EVM.ERC1155
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
### Covalent.NFT
#### Get NFT token IDs for contract
Given chain_id and contract_address, return a list of all token IDs for the NFT contract on the blockchain.

**[contract]:** Smart contract address./
**[pageNumber]:** The specific page to be returned./
**[pageSize]:** The number of results per page.
```Csharp
public static async Task<NFTTokenIDsContract.Request> AsyncGetNFTTokenIDsContract(string contract, int pageNumber, int pageSize)
```
#### Get NFT transactions for contract
Given chain_id, contract_address and token_id, return a list of transactions.

**[contract]:** Smart contract address.\
**[tokenId]:** The token ID\
**[pageNumber]:** The specific page to be returned.\
**[pageSize]:** The number of results per page.
```Csharp
public static async Task<GetNFTTransactions.Request> AsyncGetNFTTransactionsContract(string contract, int tokenId, int pageNumber, int pageSize)
```
#### Get NFT external metadata for contract
Given chain_id, contract_address and token_id, fetch and return the external metadata. Both ERC721 as well as ERC1155 standards are supported.

**[contractAddress]:** Smart contract address.\
**[tokenId]:** The token ID.
```Csharp
public static async Task<NFTExternalMetadata.Request> AsyncGetNFTExternalMetadata(string contractAddress,int tokenId)
```

## Covalent.Base
#### Get a block
Given chain_id and block_height, return a single block at block_height. If block_height is set to the value latest, return the latest block available.

**[blockHeight]:** The height of the block.
```Csharp
 public static async Task<Block.Request> AsyncGetblock(string blockHeight)
```
#### Get block heights
Given chain_id , start_date and end_date, return all the block height(s) of a particular chain within a date range. If the end_date is set to latest, return every block height from the start_date to now.

**[startDate]:** The start datetime of the block height(s). (yyyy-MM-ddTHH:mm:ssZ), eg: 2020-01-01 or 2020-01-01T03:36:50z.\
**[endDate]:** The ending datetime of the block height(s). (yyyy-MM-ddTHH:mm:ssZ), eg: 2020-01-02 or 2020-01-02T03:36:50z.\
**[pageNumber]:** The specific page to be returned.\
**[pageSize]:** The number of results per page.
```Csharp
public static asyncpageSizeck.Request> AsyncGetBlockHeight(string startDate,string endDate,int pageNumber, int pageSize)
```
#### Get log events by contract address
Given chain_id and contract address, return a paginated list of decoded log events emitted by a particular smart contract.

**[address]:** Passing in an ENS resolves automatically.\
**[startingBlock]:** Starting block to define a block range.\
**[endingBlock]:** Ending block to define a block range. Passing in latest uses the latest block height.\
**[pageNumber]:** The specific page to be returned.\
**[pageSize]:** The number of results per page.
```Csharp
public static async Task<LogEventsContract.Request> AsyncGetLogEventsContract(string address, long startingBlock, long endingBlock, int pageNumber, int pageSize)
```
#### Get log events by topic hash(es)
Given chain_id and topic hash(es), return a paginated list of decoded log events with one or more topic hashes separated by a comma.

**[topic]:** Topic hash value from log records. \
**[secondaryTopics]:** Additional topic hash(es) to filter on -- padded & unpadded address fields are supported. \
**[startingBlock]:** Starting block to define a block range.\
**[endingBlock]:** Ending block to define a block range. Passing in latest uses the latest block height.\
**[senderAddress]:** Topic hash value from log records.
**[pageNumber]:** The specific page to be returned.\
**[pageSize]:** The number of results per page.
```Csharp
 public static async Task<LogEventsTopic.Request> AsyncGetLogEventsTopic(string topic, long startingBlock, long endingBlock, string secondaryTopics, string senderAddress, int pageNumber, int pageSize )
```
#### Get all chains
Returns a list of all chains.

```Csharp
   public static async Task<AllChains.Request> AsyncGetAllChains()
```
#### Get all chain statuses
Returns a list of all chain statuses.
```Csharp
public static async Task<AllChainsStatuses.Request> AsyncGetAllChainStatuses()
```
