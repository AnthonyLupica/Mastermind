﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mastermind.ResourseStrings {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class GameStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal GameStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Mastermind.ResourseStrings.GameStrings", typeof(GameStrings).Assembly);
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
        ///   Looks up a localized string similar to Thanks for playing!!!
        ///.
        /// </summary>
        internal static string GamePrint_Exit {
            get {
                return ResourceManager.GetString("GamePrint_Exit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Welcome to the &quot;Mastermind Challenge&quot;, where your wits will be put to the test. 
        ///See if you can decipher my secret code before time runs out! 
        ///.
        /// </summary>
        internal static string GamePrint_Introduction {
            get {
                return ResourceManager.GetString("GamePrint_Introduction", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Guess {0} of {1}: .
        /// </summary>
        internal static string Guess_Prompt {
            get {
                return ResourceManager.GetString("Guess_Prompt", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to I have generated a secret code which is:
        ///   - {0} numbers long
        ///   - Composed only of numbers in the range [{1}, {2}]
        ///
        ///Enter &apos;h&apos; at any time to view the rules menu, or &apos;q&apos; to quit the game.
        ///
        ///The question remains ... Can you break the code within {3} guesses? 
        ///
        ///
        ///.
        /// </summary>
        internal static string RoundPrint_Introduction {
            get {
                return ResourceManager.GetString("RoundPrint_Introduction", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your guess contains numbers that are out of range ... Recall the secet code contains only numbers in the range [{0}, {1}].
        ///.
        /// </summary>
        internal static string Validation_DigitNotInSecretCharSet {
            get {
                return ResourceManager.GetString("Validation_DigitNotInSecretCharSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your guess was empty ... You cannot run from the Mastermind!
        ///.
        /// </summary>
        internal static string Validation_EmptyGuess {
            get {
                return ResourceManager.GetString("Validation_EmptyGuess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your guess contains non-digit characters ... You cannot fool the Mastermind so easily!
        ///.
        /// </summary>
        internal static string Validation_NonDigit {
            get {
                return ResourceManager.GetString("Validation_NonDigit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Your guess is not equal in length with the secret code I have generated ... Recall the secret code is of length {0}.
        ///.
        /// </summary>
        internal static string Validation_SecretLength {
            get {
                return ResourceManager.GetString("Validation_SecretLength", resourceCulture);
            }
        }
    }
}
