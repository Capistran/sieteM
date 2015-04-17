﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.18444
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Externo.Proxy.ServCatalogos {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SEntPaciente", Namespace="http://schemas.datacontract.org/2004/07/Procesamiento.SieteM.Entidades")]
    [System.SerializableAttribute()]
    public partial class SEntPaciente : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdPacienteField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float LatitudField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private float LongitudField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombreField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int IdPaciente {
            get {
                return this.IdPacienteField;
            }
            set {
                if ((this.IdPacienteField.Equals(value) != true)) {
                    this.IdPacienteField = value;
                    this.RaisePropertyChanged("IdPaciente");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Latitud {
            get {
                return this.LatitudField;
            }
            set {
                if ((this.LatitudField.Equals(value) != true)) {
                    this.LatitudField = value;
                    this.RaisePropertyChanged("Latitud");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public float Longitud {
            get {
                return this.LongitudField;
            }
            set {
                if ((this.LongitudField.Equals(value) != true)) {
                    this.LongitudField = value;
                    this.RaisePropertyChanged("Longitud");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombre {
            get {
                return this.NombreField;
            }
            set {
                if ((object.ReferenceEquals(this.NombreField, value) != true)) {
                    this.NombreField = value;
                    this.RaisePropertyChanged("Nombre");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServCatalogos.ISieteMarias")]
    public interface ISieteMarias {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISieteMarias/RegresaPacientesPorRuta", ReplyAction="http://tempuri.org/ISieteMarias/RegresaPacientesPorRutaResponse")]
        System.Collections.Generic.List<Externo.Proxy.ServCatalogos.SEntPaciente> RegresaPacientesPorRuta(int idruta, int idTransp);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISieteMarias/RPacientes", ReplyAction="http://tempuri.org/ISieteMarias/RPacientesResponse")]
        System.Collections.Generic.List<Externo.Proxy.ServCatalogos.SEntPaciente> RPacientes();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISieteMariasChannel : Externo.Proxy.ServCatalogos.ISieteMarias, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SieteMariasClient : System.ServiceModel.ClientBase<Externo.Proxy.ServCatalogos.ISieteMarias>, Externo.Proxy.ServCatalogos.ISieteMarias {
        
        public SieteMariasClient() {
        }
        
        public SieteMariasClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SieteMariasClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SieteMariasClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SieteMariasClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Collections.Generic.List<Externo.Proxy.ServCatalogos.SEntPaciente> RegresaPacientesPorRuta(int idruta, int idTransp) {
            return base.Channel.RegresaPacientesPorRuta(idruta, idTransp);
        }
        
        public System.Collections.Generic.List<Externo.Proxy.ServCatalogos.SEntPaciente> RPacientes() {
            return base.Channel.RPacientes();
        }
    }
}
