using ShoppingAPI_Jueves_2025.DAL;
using ShoppingAPI_Jueves_2025.DAL.Entities;
using WebAPI.DAL.Entities;

namespace WebAPI.DAL
{
    public class SeederDB
    {
        // Se hace la inyeccion de dependencias
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        //Se crea un metodo llamado "SeederAsync", es como una especie de metodo Main
        // Tendra la responsabilidad de prepoblar las diferentes tablas de la BD

        public async Task SeederAsync()
        {
            //primero agrega un metodo propio de Entity Framework que hace las veces del comando "update-database"
            //en otras palabras, un metodo que me creara la BD inmediatamente ponga la ejecucion la API
            await _context.Database.EnsureCreatedAsync ();

            //ahora se crean metodos para prepoblar la BD
            await PopulateCountriesAsync();
            await _context.SaveChangesAsync(); // guarda los datos en la BD

        }

        #region Private Methos
        private async Task PopulateCountriesAsync()
        {
            //el metodo Any() indica que en la tabla haya al menos 1 registro
            //el Any negado (!) indica que en la tabla no hay absolutamente nada

            if (!_context.Countries.Any()) 
            {
                // asi se crea un pais con sus respectivos estados
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State 
                        {
                            CreatedDate = DateTime.Now, 
                            Name = "Antioquia"
                        },

                        new State
                        {
                            CreatedDate = DateTime.Now, 
                            Name = "Cundinamarca"
                        }
                    }
                });

                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Argentina",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now, 
                            Name = "Buenos Aires"
                        }
                    }
                });
            }
        }
        #endregion
    }
}
