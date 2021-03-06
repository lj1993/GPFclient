﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameSystem.fs {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="fs.IUploadFile")]
    public interface IUploadFile {
        
        // CODEGEN: 操作 UploadFileMethod 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUploadFile/UploadFileMethod", ReplyAction="http://tempuri.org/IUploadFile/UploadFileMethodResponse")]
        GameSystem.fs.UploadFileMethodResponse UploadFileMethod(GameSystem.fs.FileUploadMessage request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUploadFile/UploadFileMethod", ReplyAction="http://tempuri.org/IUploadFile/UploadFileMethodResponse")]
        System.Threading.Tasks.Task<GameSystem.fs.UploadFileMethodResponse> UploadFileMethodAsync(GameSystem.fs.FileUploadMessage request);
        
        // CODEGEN: 消息 DownFile 的包装名称(DownFile)以后生成的消息协定与默认值(DownLoadFile)不匹配
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUploadFile/DownLoadFile", ReplyAction="http://tempuri.org/IUploadFile/DownLoadFileResponse")]
        GameSystem.fs.DownFileResult DownLoadFile(GameSystem.fs.DownFile request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUploadFile/DownLoadFile", ReplyAction="http://tempuri.org/IUploadFile/DownLoadFileResponse")]
        System.Threading.Tasks.Task<GameSystem.fs.DownFileResult> DownLoadFileAsync(GameSystem.fs.DownFile request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUploadFile/vlenup", ReplyAction="http://tempuri.org/IUploadFile/vlenupResponse")]
        void vlenup(int vlen);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUploadFile/vlenup", ReplyAction="http://tempuri.org/IUploadFile/vlenupResponse")]
        System.Threading.Tasks.Task vlenupAsync(int vlen);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUploadFile/GetFilesList", ReplyAction="http://tempuri.org/IUploadFile/GetFilesListResponse")]
        string[] GetFilesList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUploadFile/GetFilesList", ReplyAction="http://tempuri.org/IUploadFile/GetFilesListResponse")]
        System.Threading.Tasks.Task<string[]> GetFilesListAsync();
        
        // CODEGEN: 操作 uploadvideo 以后生成的消息协定不是 RPC，也不是换行文档。
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUploadFile/uploadvideo", ReplyAction="http://tempuri.org/IUploadFile/uploadvideoResponse")]
        GameSystem.fs.uploadvideoResponse uploadvideo(GameSystem.fs.UpFile request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUploadFile/uploadvideo", ReplyAction="http://tempuri.org/IUploadFile/uploadvideoResponse")]
        System.Threading.Tasks.Task<GameSystem.fs.uploadvideoResponse> uploadvideoAsync(GameSystem.fs.UpFile request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUploadFile/getvnum", ReplyAction="http://tempuri.org/IUploadFile/getvnumResponse")]
        int[] getvnum();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUploadFile/getvnum", ReplyAction="http://tempuri.org/IUploadFile/getvnumResponse")]
        System.Threading.Tasks.Task<int[]> getvnumAsync();
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="FileUploadMessage", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class FileUploadMessage {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string FileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream FileData;
        
        public FileUploadMessage() {
        }
        
        public FileUploadMessage(string FileName, System.IO.Stream FileData) {
            this.FileName = FileName;
            this.FileData = FileData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UploadFileMethodResponse {
        
        public UploadFileMethodResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DownFile", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class DownFile {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string FileName;
        
        public DownFile() {
        }
        
        public DownFile(string FileName) {
            this.FileName = FileName;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DownFileResult", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class DownFileResult {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public long FileSize;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public bool IsSuccess;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string Message;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream FileStream;
        
        public DownFileResult() {
        }
        
        public DownFileResult(long FileSize, bool IsSuccess, string Message, System.IO.Stream FileStream) {
            this.FileSize = FileSize;
            this.IsSuccess = IsSuccess;
            this.Message = Message;
            this.FileStream = FileStream;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="UpFile", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class UpFile {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public string FileName;
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public long FileSize;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream FileStream;
        
        public UpFile() {
        }
        
        public UpFile(string FileName, long FileSize, System.IO.Stream FileStream) {
            this.FileName = FileName;
            this.FileSize = FileSize;
            this.FileStream = FileStream;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class uploadvideoResponse {
        
        public uploadvideoResponse() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUploadFileChannel : GameSystem.fs.IUploadFile, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UploadFileClient : System.ServiceModel.ClientBase<GameSystem.fs.IUploadFile>, GameSystem.fs.IUploadFile {
        
        public UploadFileClient() {
        }
        
        public UploadFileClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UploadFileClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UploadFileClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UploadFileClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GameSystem.fs.UploadFileMethodResponse GameSystem.fs.IUploadFile.UploadFileMethod(GameSystem.fs.FileUploadMessage request) {
            return base.Channel.UploadFileMethod(request);
        }
        
        public void UploadFileMethod(string FileName, System.IO.Stream FileData) {
            GameSystem.fs.FileUploadMessage inValue = new GameSystem.fs.FileUploadMessage();
            inValue.FileName = FileName;
            inValue.FileData = FileData;
            GameSystem.fs.UploadFileMethodResponse retVal = ((GameSystem.fs.IUploadFile)(this)).UploadFileMethod(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GameSystem.fs.UploadFileMethodResponse> GameSystem.fs.IUploadFile.UploadFileMethodAsync(GameSystem.fs.FileUploadMessage request) {
            return base.Channel.UploadFileMethodAsync(request);
        }
        
        public System.Threading.Tasks.Task<GameSystem.fs.UploadFileMethodResponse> UploadFileMethodAsync(string FileName, System.IO.Stream FileData) {
            GameSystem.fs.FileUploadMessage inValue = new GameSystem.fs.FileUploadMessage();
            inValue.FileName = FileName;
            inValue.FileData = FileData;
            return ((GameSystem.fs.IUploadFile)(this)).UploadFileMethodAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GameSystem.fs.DownFileResult GameSystem.fs.IUploadFile.DownLoadFile(GameSystem.fs.DownFile request) {
            return base.Channel.DownLoadFile(request);
        }
        
        public long DownLoadFile(string FileName, out bool IsSuccess, out string Message, out System.IO.Stream FileStream) {
            GameSystem.fs.DownFile inValue = new GameSystem.fs.DownFile();
            inValue.FileName = FileName;
            GameSystem.fs.DownFileResult retVal = ((GameSystem.fs.IUploadFile)(this)).DownLoadFile(inValue);
            IsSuccess = retVal.IsSuccess;
            Message = retVal.Message;
            FileStream = retVal.FileStream;
            return retVal.FileSize;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GameSystem.fs.DownFileResult> GameSystem.fs.IUploadFile.DownLoadFileAsync(GameSystem.fs.DownFile request) {
            return base.Channel.DownLoadFileAsync(request);
        }
        
        public System.Threading.Tasks.Task<GameSystem.fs.DownFileResult> DownLoadFileAsync(string FileName) {
            GameSystem.fs.DownFile inValue = new GameSystem.fs.DownFile();
            inValue.FileName = FileName;
            return ((GameSystem.fs.IUploadFile)(this)).DownLoadFileAsync(inValue);
        }
        
        public void vlenup(int vlen) {
            base.Channel.vlenup(vlen);
        }
        
        public System.Threading.Tasks.Task vlenupAsync(int vlen) {
            return base.Channel.vlenupAsync(vlen);
        }
        
        public string[] GetFilesList() {
            return base.Channel.GetFilesList();
        }
        
        public System.Threading.Tasks.Task<string[]> GetFilesListAsync() {
            return base.Channel.GetFilesListAsync();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GameSystem.fs.uploadvideoResponse GameSystem.fs.IUploadFile.uploadvideo(GameSystem.fs.UpFile request) {
            return base.Channel.uploadvideo(request);
        }
        
        public void uploadvideo(string FileName, long FileSize, System.IO.Stream FileStream) {
            GameSystem.fs.UpFile inValue = new GameSystem.fs.UpFile();
            inValue.FileName = FileName;
            inValue.FileSize = FileSize;
            inValue.FileStream = FileStream;
            GameSystem.fs.uploadvideoResponse retVal = ((GameSystem.fs.IUploadFile)(this)).uploadvideo(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<GameSystem.fs.uploadvideoResponse> GameSystem.fs.IUploadFile.uploadvideoAsync(GameSystem.fs.UpFile request) {
            return base.Channel.uploadvideoAsync(request);
        }
        
        public System.Threading.Tasks.Task<GameSystem.fs.uploadvideoResponse> uploadvideoAsync(string FileName, long FileSize, System.IO.Stream FileStream) {
            GameSystem.fs.UpFile inValue = new GameSystem.fs.UpFile();
            inValue.FileName = FileName;
            inValue.FileSize = FileSize;
            inValue.FileStream = FileStream;
            return ((GameSystem.fs.IUploadFile)(this)).uploadvideoAsync(inValue);
        }
        
        public int[] getvnum() {
            return base.Channel.getvnum();
        }
        
        public System.Threading.Tasks.Task<int[]> getvnumAsync() {
            return base.Channel.getvnumAsync();
        }
    }
}
