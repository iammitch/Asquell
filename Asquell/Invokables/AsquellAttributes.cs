using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asquell.Invokables
{
    [AttributeUsage(
        AttributeTargets.Method,
        AllowMultiple = false,
        Inherited = false)]
    public sealed class AsquellMethod : Attribute
    {
        private bool _exposed = false;
        /// <summary>
        /// Determines whether or not this method is exposed to the script.
        /// </summary>
        public bool Exposed
        {
            get { return _exposed; }
            set { _exposed = value; }
        }

        private string _name = null;
        /// <summary>
        /// The accessible name from within the script. Null values result in the name discovered from Reflection.
        /// </summary>
        public string AccessibleName
        {
            get { return _name; }
            set { _name = value; }
        }

        private bool _noMem = false;
        /// <summary>
        /// The status of whether or not the method needs access to the MemoryBlock of the script.
        /// </summary>
        public bool NoMemoryBlock
        {
            get { return _noMem; }
            set { _noMem = value; }
        }
    }
    [AttributeUsage(
        AttributeTargets.Class,
        AllowMultiple = false,
        Inherited = false)]
    public sealed class AsquellClass : Attribute
    {
        private string _name = null;
        /// <summary>
        /// The accessible name from within the script. TODO: Null value makes it global
        /// </summary>
        public string AccessibleName
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
