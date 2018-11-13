using AppIO;
using PurchaseBizz;
using PurchaseIO;
using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows;

namespace UnitTest
{
    [TestClass]
    public class Test1
    {
        public const string stringConnection = "Data Source=10.205.44.39,49172;Initial Catalog=GrainBarrel.Gywerd;User ID=Aspit;Password=Server2012";
        Supplyer CSP = new Supplyer();
        User CUS = new User();
        Bizz CBZ = new Bizz();
        Executor executor = new Executor(stringConnection);
        BizzDbAccess BDA = new BizzDbAccess();

        [TestMethod]
        /// <summary>
        /// Tests Executing a sqlQuery and receiving a DataSet
        /// </summary>
        public void TestMethod1()
        {
            // arrange
            //BDA.AddUser("Afdelingsleder", "B. Stem", new ContactInfo() { Email = "user@domain.tld", Phone = "12345679", Mobile = "2345678", Url = "https://domain.tld" }, new Credential() { UserName = "boss", PassWord = "login" });
            bool expected = false;

            // act  
            bool ds = BDA.AddUser("Afdelingsleder", "B. Stem", new ContactInfo() { Email = "user@domain.tld", Phone = "12345679", Mobile = "2345678", Url = "https://domain.tld" }, new Credential() { UserName = "boss", PassWord = "login" });
            //string d = Convert.ToString(ds);
            // assert  
            bool actual = ds;//.Equals(null);
            Assert.AreEqual(expected, actual, "NOT EQUAL");
        }

    }
}
