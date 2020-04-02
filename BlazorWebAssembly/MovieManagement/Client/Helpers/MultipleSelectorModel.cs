using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieManagement.Client.Helpers
{
    public struct MultipleSelectorModel
    {
        public MultipleSelectorModel(string key, string value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Enthält z.B. die Id von dem Objekt
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Enthält den Inhalt von dem Objekt, welcher für das anzeigen benötigt wird
        /// </summary>
        public string Value { get; set; }
    }
}
