﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SneakerBot.WebScraping.Service {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class WebURLs : global::System.Configuration.ApplicationSettingsBase {
        
        private static WebURLs defaultInstance = ((WebURLs)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new WebURLs())));
        
        public static WebURLs Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("http://www.rebelsport.com.au/store/footwear/1?page=1&pageSize=12&sort=-ProductSum" +
            "maryPurchasesWeighted%2C-ProductSummaryPurchases&gclid=EAIaIQobChMI3JjU_L781wIVE" +
            "CQrCh07uQbGEAAYASACEgJO1vD_BwE&gclsrc=aw.ds")]
        public string Rebel {
            get {
                return ((string)(this["Rebel"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://aiobot.com/releases")]
        public string AIOBot {
            get {
                return ((string)(this["AIOBot"]));
            }
        }
    }
}