﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataSource.DataAccess.Tests.DataProviderTests {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class TestData {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal TestData() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DataSource.DataAccess.Tests.DataProviderTests.TestData", typeof(TestData).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to [{&quot;restaurant_id&quot;: 1, &quot;name&quot;: &quot;Hawaii Pizza&quot;, &quot;address&quot;: &quot;ul.Micha\u0142a Spisaka 44\r\n02-495 Warszawa&quot;, &quot;phone_number&quot;: &quot;226684613&quot;, &quot;email_address&quot;: &quot;biuro@hawaiipizza.pl&quot;, &quot;dishes&quot;: [{&quot;dish_id&quot;: 3, &quot;restaurant_id&quot;: 1, &quot;name&quot;: &quot;Lunch dnia&quot;, &quot;price&quot;: &quot;15.50&quot;, &quot;description&quot;: &quot;Ka\u017cdego dnia w tygodniu, w godzinach 12.00-16.00, nowa oferta lunchowa. Szczeg\u00f3\u0142y na: http://www.hawaiipizza.pl/index.php/lunch.&quot;}]}].
        /// </summary>
        internal static string RestaurantsJSON {
            get {
                return ResourceManager.GetString("RestaurantsJSON", resourceCulture);
            }
        }
    }
}
