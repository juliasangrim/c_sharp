//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrincessChoiceTest {
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
    internal class PrincessResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal PrincessResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("PrincessChoiceTest.PrincessResource", typeof(PrincessResource).Assembly);
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
        ///   Looks up a localized string similar to MyAttemptName.
        /// </summary>
        internal static string AttemptName {
            get {
                return ResourceManager.GetString("AttemptName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Current contender not visited princess!.
        /// </summary>
        internal static string NotVisitedComparisonError {
            get {
                return ResourceManager.GetString("NotVisitedComparisonError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attempt name should be not null!.
        /// </summary>
        internal static string NullAttemptNameError {
            get {
                return ResourceManager.GetString("NullAttemptNameError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to wrong attempt.
        /// </summary>
        internal static string WrongAttemptName {
            get {
                return ResourceManager.GetString("WrongAttemptName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No attempt in db with this name: wrong attempt!.
        /// </summary>
        internal static string WrongAttemptNameError {
            get {
                return ResourceManager.GetString("WrongAttemptNameError", resourceCulture);
            }
        }
    }
}
