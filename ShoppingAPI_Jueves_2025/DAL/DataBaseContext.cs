using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves_2025.DAL.Entities;
using WebAPI.DAL.Entities;

namespace ShoppingAPI_Jueves_2025.DAL
{
    public class DataBaseContext: DbContext
    {
        // me conecto a la base de datos mediante el metodo constructor
        public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options)
        {
            
        }

        // metodo para configurar indices de tablas en la BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(c => c.Name).IsUnique(); // creo un indice del campo Name de la tabla Countries
            modelBuilder.Entity<State>().HasIndex("Name", "CountryId").IsUnique(); // creo un indice compuesto (el nombre de un estado, puede estar en varios
                                                                                   // paises diferentes, pero nunca dos mismos estados dentro de un solo pais)
        }

        #region Dbset
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        #endregion
    }
}