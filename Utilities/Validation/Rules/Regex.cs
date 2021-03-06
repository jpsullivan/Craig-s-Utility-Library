﻿/*
Copyright (c) 2012 <a href="http://www.gutgames.com">James Craig</a>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/

#region Usings
using System;
using Utilities.Validation.BaseClasses;
using Utilities.Validation.Exceptions;

#endregion

namespace Utilities.Validation.Rules
{
    /// <summary>
    /// This item is equal to the regex string
    /// </summary>
    /// <typeparam name="ObjectType">Object type that the rule applies to</typeparam>
    public class Regex<ObjectType> : Rule<ObjectType, string>
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ItemToValidate">Item to validate</param>
        /// <param name="RegexString">Regex string</param>
        /// <param name="ErrorMessage">Error message</param>
        public Regex(Func<ObjectType, string> ItemToValidate,string RegexString, string ErrorMessage)
            : base(ItemToValidate, ErrorMessage)
        {
            ValidationRegex = new System.Text.RegularExpressions.Regex(RegexString);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Regex used to validate the object
        /// </summary>
        protected virtual System.Text.RegularExpressions.Regex ValidationRegex { get; set; }

        #endregion

        #region Functions

        /// <summary>
        /// Validates an object
        /// </summary>
        /// <param name="Object">Object to validate</param>
        public override void Validate(ObjectType Object)
        {
            if(string.IsNullOrEmpty(ItemToValidate(Object)))
                throw new NotValid(ErrorMessage);
            if(!ValidationRegex.IsMatch(ItemToValidate(Object)))
                throw new NotValid(ErrorMessage);
        }

        #endregion
    }

    /// <summary>
    /// Regex attribute
    /// </summary>
    public class Regex : BaseAttribute
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ErrorMessage">Error message</param>
        /// <param name="RegexString">Regex string value</param>
        public Regex(string RegexString, string ErrorMessage = "")
            : base(ErrorMessage)
        {
            this.RegexString = RegexString;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Regex string value
        /// </summary>
        public string RegexString { get; set; }

        #endregion
    }
}
