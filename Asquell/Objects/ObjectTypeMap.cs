using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asquell.Objects
{
    class ObjectTypeMap
    {
        private Dictionary<AsquellObjectType,Type> _types;
        public ObjectTypeMap()
        {
            _types = new Dictionary<AsquellObjectType,Type>();
        }
        public Type GetTypeForObj(AsquellObj obj)
        {
            Type t = null;
            if (_types.ContainsKey(obj.Type))
            {
                t = _types[obj.Type];
            }
            return t;
        }
        public void MapType(AsquellObjectType toMap, Type from)
        {
            _types[toMap] = from;
        }
    }
}
