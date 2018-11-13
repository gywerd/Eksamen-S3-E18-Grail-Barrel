using AppIO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseBizz
{
    public class Bizz : BizzDbAccess
    {
        //public const string stringConnection = "Data Source=10.205.44.39,49172;Initial Catalog=GrainBarrel.Gywerd;User ID=Aspit;Password=Server2012";
        //public DataBaseAccess CDA = new DataBaseAccess(stringConnection);
        public GrainBarrelContext GBC = new GrainBarrelContext();

        public Bizz()
        {

        }


    }
}
