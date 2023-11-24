using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Contracts;
using System.Threading.Tasks;

public class SmartContractInteraction : MonoBehaviour
{
    private string contractAddress = "demo(contractAddress)";
    private string privateKey = "demo(privateKey)";
    private string nodeUrl = "demo(nodeUrl)";

    private Web3 web3;
    private Account account;
    private Contract peerToPeerContract;

    // Start is called before the first frame update
    async void Start()
    {
        account = new Account(privateKey);
        web3 = new Web3(account, nodeUrl);
        peerToPeerContract = web3.Eth.GetContract("demo(ABI)", contractAddress);
    }

    public async Task SetUserID(uint256 userID)
    {
        var setUserIDFunction = peerToPeerContract.GetFunction("setUserID");
        var gas = new HexBigInteger(21000);
        var gasPrice = new HexBigInteger(20000000000);

        var transactionInput = setUserIDFunction.CreateTransactionInput(account.Address, gas, gasPrice, new HexBigInteger(0), userID);

        var transactionHash = await web3.Eth.Transactions.SendTransaction.SendRequest.SendRequestAsync(transactionInput);
        Debug.Log("Transaction Hash: " + transactionHash);
    }

    public async Task RequestConnection(string toAddress)
    {
        var requestConnectionFunction = peerToPeerContract.GetFunction("requestConnection");
        var gas = new HexBigInteger(21000);
        var gasPrice = new HexBigInteger(20000000000);

        var transactionInput = requestConnectionFunction.CreateTransactionInput(account.Address, gas, gasPrice, new HexBigInteger(0), toAddress);

        var transactionHash = await web3.Eth.Transactions.SendTransaction.SendRequest.SendRequestAsync(transactionInput);
        Debug.Log("Transaction Hash: " + transactionHash);
    }
}
