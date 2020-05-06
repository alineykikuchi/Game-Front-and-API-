using System;
using System.Collections.Generic;

namespace Games.Tools.Extensions
{
    [AttributeUsage(AttributeTargets.Field)]
    public class DataValueAttribute : Attribute
    {
        private readonly List<string> _Value;
        public List<string> Value
        {
            get { return _Value; }
        }

        public DataValueAttribute(params string[] Valores)
        {
            this._Value = new List<string>();

            foreach (string Valor in Valores)
            {
                this._Value.Add(Valor);
            }

        }
    }
}
