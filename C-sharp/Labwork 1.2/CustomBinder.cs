using System;
using System.Runtime.Serialization;
using Labwork_1_2;

namespace Labwork_1._2
{
    sealed class CustomBinder : SerializationBinder
    {
        public override Type BindToType(string assemblyName, string typeName)
        {
            if (typeName == "Labwork_1_2.Product")
            {
                return typeof(Product);
            }

            return null;
        }
    }
}
