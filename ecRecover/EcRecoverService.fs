namespace Itm_objection.Contracts.ecRecover

open System
open System.Threading.Tasks
open System.Collections.Generic
open System.Numerics
open Nethereum.Hex.HexTypes
open Nethereum.ABI.FunctionEncoding.Attributes
open Nethereum.Web3
open Nethereum.RPC.Eth.DTOs
open Nethereum.Contracts.CQS
open Nethereum.Contracts.ContractHandlers
open Nethereum.Contracts
open System.Threading
open Itm_objection.Contracts.ecRecover.ContractDefinition


    type EcRecoverService (web3: Web3, contractAddress: string) =
    
        member val Web3 = web3 with get
        member val ContractHandler = web3.Eth.GetContractHandler(contractAddress) with get
    
        static member DeployContractAndWaitForReceiptAsync(web3: Web3, ecRecoverDeployment: EcRecoverDeployment, ?cancellationTokenSource : CancellationTokenSource): Task<TransactionReceipt> = 
            let cancellationTokenSourceVal = defaultArg cancellationTokenSource null
            web3.Eth.GetContractDeploymentHandler<EcRecoverDeployment>().SendRequestAndWaitForReceiptAsync(ecRecoverDeployment, cancellationTokenSourceVal)
        
        static member DeployContractAsync(web3: Web3, ecRecoverDeployment: EcRecoverDeployment): Task<string> =
            web3.Eth.GetContractDeploymentHandler<EcRecoverDeployment>().SendRequestAsync(ecRecoverDeployment)
        
        static member DeployContractAndGetServiceAsync(web3: Web3, ecRecoverDeployment: EcRecoverDeployment, ?cancellationTokenSource : CancellationTokenSource) = async {
            let cancellationTokenSourceVal = defaultArg cancellationTokenSource null
            let! receipt = EcRecoverService.DeployContractAndWaitForReceiptAsync(web3, ecRecoverDeployment, cancellationTokenSourceVal) |> Async.AwaitTask
            return new EcRecoverService(web3, receipt.ContractAddress);
            }
    
        member this.OwnerQueryAsync(ownerFunction: OwnerFunction, ?blockParameter: BlockParameter): Task<string> =
            let blockParameterVal = defaultArg blockParameter null
            this.ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameterVal)
            
        member this.RecoverQueryAsync(recoverFunction: RecoverFunction, ?blockParameter: BlockParameter): Task<string> =
            let blockParameterVal = defaultArg blockParameter null
            this.ContractHandler.QueryAsync<RecoverFunction, string>(recoverFunction, blockParameterVal)
            
        member this.RenounceOwnershipRequestAsync(renounceOwnershipFunction: RenounceOwnershipFunction): Task<string> =
            this.ContractHandler.SendRequestAsync(renounceOwnershipFunction);
        
        member this.RenounceOwnershipRequestAndWaitForReceiptAsync(renounceOwnershipFunction: RenounceOwnershipFunction, ?cancellationTokenSource : CancellationTokenSource): Task<TransactionReceipt> =
            let cancellationTokenSourceVal = defaultArg cancellationTokenSource null
            this.ContractHandler.SendRequestAndWaitForReceiptAsync(renounceOwnershipFunction, cancellationTokenSourceVal);
        
        member this.SetSignerRequestAsync(setSignerFunction: SetSignerFunction): Task<string> =
            this.ContractHandler.SendRequestAsync(setSignerFunction);
        
        member this.SetSignerRequestAndWaitForReceiptAsync(setSignerFunction: SetSignerFunction, ?cancellationTokenSource : CancellationTokenSource): Task<TransactionReceipt> =
            let cancellationTokenSourceVal = defaultArg cancellationTokenSource null
            this.ContractHandler.SendRequestAndWaitForReceiptAsync(setSignerFunction, cancellationTokenSourceVal);
        
        member this.SplitSignatureQueryAsync(splitSignatureFunction: SplitSignatureFunction, ?blockParameter: BlockParameter): Task<SplitSignatureOutputDTO> =
            let blockParameterVal = defaultArg blockParameter null
            this.ContractHandler.QueryDeserializingToObjectAsync<SplitSignatureFunction, SplitSignatureOutputDTO>(splitSignatureFunction, blockParameterVal)
            
        member this.TransferOwnershipRequestAsync(transferOwnershipFunction: TransferOwnershipFunction): Task<string> =
            this.ContractHandler.SendRequestAsync(transferOwnershipFunction);
        
        member this.TransferOwnershipRequestAndWaitForReceiptAsync(transferOwnershipFunction: TransferOwnershipFunction, ?cancellationTokenSource : CancellationTokenSource): Task<TransactionReceipt> =
            let cancellationTokenSourceVal = defaultArg cancellationTokenSource null
            this.ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationTokenSourceVal);
        
    

