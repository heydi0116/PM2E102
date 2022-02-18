using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PM2E102.Archivos;
using System.Threading.Tasks;


namespace PM2E102.Archivos
{
    public class baseDatos
    {
        readonly SQLiteAsyncConnection db;

        public baseDatos()
        {
        }
        public baseDatos(String pathbasedatos)
        {
            db = new SQLiteAsyncConnection(pathbasedatos);
            db.CreateTableAsync<cLugares>();
        }

        public Task<List<cLugares>> listaempleados()
        {
            return db.Table<cLugares>().ToListAsync();
        }

        public Task<cLugares> ObtenerEmpleado(Int32 pcodigo)
        {
            return db.Table<cLugares>().Where(i => i.id == pcodigo).FirstOrDefaultAsync();
        }

        public Task<Int32> EmpleadoGuardar(cLugares emple)
        {
            if (emple.id != 0)
            {
                return db.UpdateAsync(emple);
            }
            else
            {
                return db.InsertAsync(emple);
            }
        }

        public Task<Int32> EmpleadoBorrar(cLugares emple)
        {
            return db.DeleteAsync(emple);
        }
    }
}
