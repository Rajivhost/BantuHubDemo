using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BantuHub.Demo.Ef
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new PersonDbContext();

            db.Persons.Add(new Person{Name = "Audrey Mounguengue"});

            Console.WriteLine("Enregistrer des données");
            db.SaveChanges();

            Console.Read();
        }
    }

    public class Person
    {
        public long Id { get; set; }

        public string Name { get; set; } 
    }

    public class PersonDbContext : DbContext
    {
        public PersonDbContext()
            : base("PersonDbConnectionString")
        {
            Console.WriteLine("Initialisation de la base de données");
            Database.SetInitializer(new CreateDatabaseIfNotExists<PersonDbContext>());
            Console.WriteLine("Base de données initialisée");
        }

        public DbSet<Person> Persons { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Person>()
        //        .Property(person => person.Name)
        //        .HasColumnName("_name");
        //} 
    }

    public class PersonDbInitializer : DropCreateDatabaseAlways<PersonDbContext>
    {
        readonly List<Person> _persons = new List<Person>();
        public PersonDbInitializer()
        {
            _persons.Add(new Person { Name = "Rajiv Mounguengue"});
            _persons.Add(new Person { Name = "Geert van Horrik" });
        }

        public override void InitializeDatabase(PersonDbContext context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }

        protected override void Seed(PersonDbContext context)
        {
            foreach (var person in _persons)
            {
                context.Persons.Add(person);
            }

            context.SaveChanges();
            base.Seed(context);
        }
    }




}
