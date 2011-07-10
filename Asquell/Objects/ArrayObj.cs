using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asquell.Objects
{
    class ArrayObj
    {
        private AsquellObj baseObj;
        public ArrayObj(object[] array)
        {
            AsquellObj[] tmp = new AsquellObj[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                tmp[i] = new AsquellObj(array[i]);
            }
            baseObj = new AsquellObj(tmp);
        }
        public ArrayObj(AsquellObj obj)
        {
            baseObj = obj;
        }
        public AsquellObj[] Value
        {
            get
            {
                return (AsquellObj[])baseObj.Value;
            }
        }
        public AsquellObj BaseObj
        {
            get { return baseObj; }
        }
    }
}
