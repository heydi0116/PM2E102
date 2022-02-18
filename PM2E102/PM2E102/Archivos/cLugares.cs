using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2E102.Archivos
{
    public class cLugares
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string latitudC { get; set; }
        public string longitudC { get; set; }
        public string descripcionC { get; set; }
        public string imageC { get; set; }

    }
}
