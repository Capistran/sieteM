﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.1
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Externo.AccesoDatos.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=sietemariaslogistica.com\\MSSQLSERVER2008;User ID=siete_pruebasbaxter;" +
            "Password=pruebas@2015")]
        public string DataSourceConnectionString1 {
            get {
                return ((string)(this["DataSourceConnectionString1"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=sietemariaslogistica.com\\MSSQLSERVER2008;User ID=siete_pruebasbaxter;" +
            "Password=pruebas@2015")]
        public string DataSourceConnectionString {
            get {
                return ((string)(this["DataSourceConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ui.sietemariaslogistica.com\\MSSQLSERVER2008;Initial Catalog=sietemar_" +
            "Pruebas;User ID=siete_pruebasbaxter;Password=pruebas@2015")]
        public string sietemar_PruebasConnectionString {
            get {
                return ((string)(this["sietemar_PruebasConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=sietemariaslogistica.com;Initial Catalog=sietemar_Pruebas;User ID=sie" +
            "te_pruebasbaxter;Password=pruebas@2015")]
        public string sietemar_PruebasConnectionString1 {
            get {
                return ((string)(this["sietemar_PruebasConnectionString1"]));
            }
        }
    }
}
