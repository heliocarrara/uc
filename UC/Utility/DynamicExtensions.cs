using System.Dynamic;
using System.Linq;

namespace UC.Utility
{
    public static class DynamicExtensions
    {
        public static bool Has(this object obj, string propertyName)
        {
            var dynamic = obj as DynamicObject;
            if (dynamic == null) return false;
            return dynamic.GetDynamicMemberNames().Contains(propertyName);
        }
    }
}