// -----------------------------------------------------------------------
// <copyright file="Enums.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Framework.Enums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    using System.Runtime.Serialization;

    /// <summary>
    /// Framework Enumeration class.
    /// </summary>
    public static class Enums
    {
        /// <summary>
        /// Framework Enumeration ErrorLevel.
        /// </summary>
        [DataContract(Name = "ErrorLevel")]
        public enum ErrorLevel
        {
            /// <summary>
            /// ErrorLevel FATAL. 
            /// </summary>
            [EnumMember]
            FATAL = 0,

            /// <summary>
            /// ErrorLevel ERROR.
            /// </summary>
            [EnumMember]
            ERROR = 1,

            /// <summary>
            /// ErrorLevel WARN.
            /// </summary>
            [EnumMember]
            WARN = 2,

            /// <summary>
            /// ErrorLevel INFO.
            /// </summary>
            [EnumMember]
            INFO = 3,

            /// <summary>
            /// ErrorLevel DEBUG.
            /// </summary>
            [EnumMember]
            DEBUG = 4
        }
    }
}