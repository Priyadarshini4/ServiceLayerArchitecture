﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceProxies.AuthenticateService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="AuthenticateService.IAuthenticateService")]
    public interface IAuthenticateService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IAuthenticateService/AuthenticateUser", ReplyAction="http://tempuri.org/IAuthenticateService/AuthenticateUserResponse")]
        int AuthenticateUser(string userName, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IAuthenticateServiceChannel : ServiceProxies.AuthenticateService.IAuthenticateService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class AuthenticateServiceClient : System.ServiceModel.ClientBase<ServiceProxies.AuthenticateService.IAuthenticateService>, ServiceProxies.AuthenticateService.IAuthenticateService {
        
        public AuthenticateServiceClient() {
        }
        
        public AuthenticateServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public AuthenticateServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticateServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public AuthenticateServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int AuthenticateUser(string userName, string password) {
            return base.Channel.AuthenticateUser(userName, password);
        }
    }
}
