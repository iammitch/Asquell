using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Asquell.Objects;

namespace Asquell.Invokables
{
    static class Set
    {
        public static void DoOperation(AsquellObj from, string to, MemoryBlock memory)
        {
            memory.ModifyVariable(to, from);
        }
    }
}
