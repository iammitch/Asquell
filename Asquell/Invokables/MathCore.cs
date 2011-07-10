using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Asquell.Objects;

namespace Asquell.Invokables
{
    [AsquellClass(AccessibleName = null)]
    public static class MathCore
    {
        private static NumericObj getNumericObj(AsquellObj obj, MemoryBlock memory)
        {
            obj = memory.GetRealVariable(obj);
            if (obj.Type == AsquellObjectType.Number)
                return new NumericObj(obj);
            else
                return null;
        }
        [AsquellMethod(AccessibleName = "Add", Exposed = true, NoMemoryBlock = false)]
        public static void AddNumbers(MemoryBlock memory, AsquellObj a, AsquellObj b, AsquellObj storeResult)
        {
            NumericObj NumA = getNumericObj(a,memory);
            NumericObj NumB = getNumericObj(b,memory);
            if (NumA!=null&&NumB!=null)
            {
                memory.ModifyVariable(storeResult, (NumA + NumB).BaseObj);
                return;
            }
            throw new ArgumentException("Invalid type for adding!");
        }
        [AsquellMethod(AccessibleName = "Sub", Exposed = true, NoMemoryBlock = false)]
        public static void SubtractNumbers(MemoryBlock memory, AsquellObj a, AsquellObj b, AsquellObj storeResult)
        {
            NumericObj NumA = getNumericObj(a, memory);
            NumericObj NumB = getNumericObj(b, memory);
            if (NumA != null && NumB != null)
            {
                memory.ModifyVariable(storeResult, (NumA - NumB).BaseObj);
                return;
            }
            throw new ArgumentException("Invalid type for subtracting!");
        }
        [AsquellMethod(AccessibleName = "Mply", Exposed = true, NoMemoryBlock = false)]
        public static void MultiplyNumbers(MemoryBlock memory, AsquellObj a, AsquellObj b, AsquellObj storeResult)
        {
            NumericObj NumA = getNumericObj(a, memory);
            NumericObj NumB = getNumericObj(b, memory);
            if (NumA != null && NumB != null)
            {
                memory.ModifyVariable(storeResult, (NumA * NumB).BaseObj);
                return;
            }
            throw new ArgumentException("Invalid type for multiplying!");
        }
        [AsquellMethod(AccessibleName = "Divide", Exposed = true, NoMemoryBlock = false)]
        public static void DivideNumbers(MemoryBlock memory, AsquellObj a, AsquellObj b, AsquellObj storeResult)
        {
            NumericObj NumA = getNumericObj(a, memory);
            NumericObj NumB = getNumericObj(b, memory);
            if (NumA != null && NumB != null && NumB.Value!=0)
            {
                memory.ModifyVariable(storeResult, (NumA / NumB).BaseObj);
                return;
            }
            throw new ArgumentException("Invalid type for dividing!");
        }
        [AsquellMethod(AccessibleName = "Pow", Exposed = true, NoMemoryBlock = false)]
        public static void PowerNumbers(MemoryBlock memory, AsquellObj a, AsquellObj b, AsquellObj storeResult)
        {
            NumericObj NumA = getNumericObj(a, memory);
            NumericObj NumB = getNumericObj(b, memory);
            if (NumA != null && NumB != null)
            {
                memory.ModifyVariable(storeResult, (NumA ^ NumB).BaseObj);
                return;
            }
            throw new ArgumentException("Invalid type for power!");
        }
        [AsquellMethod(AccessibleName = "Mod", Exposed = true, NoMemoryBlock = false)]
        public static void ModuloNumbers(MemoryBlock memory, AsquellObj a, AsquellObj b, AsquellObj storeResult)
        {
            NumericObj NumA = getNumericObj(a, memory);
            NumericObj NumB = getNumericObj(b, memory);
            if (NumA != null && NumB != null)
            {
                memory.ModifyVariable(storeResult, (NumA % NumB).BaseObj);
                return;
            }
            throw new ArgumentException("Invalid type for modulo operation!");
        }
    }
}
