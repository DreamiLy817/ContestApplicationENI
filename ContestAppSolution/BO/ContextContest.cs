namespace BO
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ContextContest : DbContext
    {
        // Votre contexte a été configuré pour utiliser une chaîne de connexion « ContextContest » du fichier 
        // de configuration de votre application (App.config ou Web.config). Par défaut, cette chaîne de connexion cible 
        // la base de données « BO.ContextContest » sur votre instance LocalDb. 
        // 
        // Pour cibler une autre base de données et/ou un autre fournisseur de base de données, modifiez 
        // la chaîne de connexion « ContextContest » dans le fichier de configuration de l'application.
        public ContextContest()
            : base("name=ContextContest")
        {
        }

        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<PointOfInterest> PointOfInterest { get; set; }
        public virtual DbSet<Ville> Ville { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<DisplayConfiguration> DisplayConfiguration { get; set; }
    

        public System.Data.Entity.DbSet<BO.Models.Epreuve> Epreuves { get; set; }

        // Ajoutez un DbSet pour chaque type d'entité à inclure dans votre modèle. Pour plus d'informations 
        // sur la configuration et l'utilisation du modèle Code First, consultez http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}