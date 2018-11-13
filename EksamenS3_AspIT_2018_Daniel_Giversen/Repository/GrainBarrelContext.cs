using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GrainBarrelContext : DbContext, INotifyPropertyChanged
    {
        public GrainBarrelContext() : base("name=GrainBarleyDbStringConnection")
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<BaseRate> BaseRates { get; set; }
        public DbSet<ContactInfo> ContactInfolist { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<DollarRate> DollarRates { get; set; }
        public DbSet<Grain> Grains { get; set; }
        public DbSet<Supplyer> LegalPersons { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Supplyer> Suppliers
        {
            get
            {
                return Suppliers;
            }
            set
            {
                Suppliers = value;
                Notify("Name");
            }
        }
        public DbSet<User> Users
        {
            get { return Users; }
            set
            {
                Users = value;
                Notify("strMaterialThickness");
            }
        }
        public DbSet<ZipTown> ZipTownList { get; set; }

        private void Notify(string v)
        {
            {
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(v));
                }
            }
        }

    }
}
