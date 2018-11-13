using AppIO;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseBizz
{
    public class BizzDbAccess
    {
        private GrainBarrelContext GBC = new GrainBarrelContext();
        public User user = new User();

        public bool AddAddress(string road, string zip, string town, string place = "")
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                Address adr = new Address() { Road = road, Place = place, ZipTown = new ZipTown() { Zip = zip, Town = town } };
                gbc.Addresses.Add(adr);
                gbc.SaveChanges();
            }
            result = true;
            return result;
        }
        public bool AddBaseRate(string currencyCode, string currencyName)
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                BaseRate baseRate = new BaseRate() { CurrencyCode = currencyCode, CurrencyName = currencyName };
                gbc.BaseRates.Add(baseRate);
                gbc.SaveChanges();
            }
            result = true;
            return result;
        }
        public bool AddContactInfo(string email = "", string phone = "", string mobile = "", string url = "")
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                ContactInfo info = new ContactInfo() { Email = email, Phone = phone, Mobile = mobile, Url = url };
                gbc.ContactInfolist.Add(info);
                gbc.SaveChanges();
            }
            result = true;
            return result;
        }
        public bool AddCredential(string userName, string passWord, bool active = false)
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                Credential cred = new Credential() { UserName = userName, PassWord = passWord, Active = active };
                gbc.Credentials.Add(cred);
                gbc.SaveChanges();
            }
            result = true;
            return result;
        }
        public bool AddDollarRate(List<Rate> rateList, string Disclaimer, string Licence, string Timestamp, string Base, Dictionary<string, decimal> Rates)
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                DollarRate dollarRate = new DollarRate() { RateList = rateList, disclaimer = Disclaimer, licence = Licence, timestamp = Timestamp, @base = Base, rates = Rates };
                gbc.DollarRates.Add(dollarRate);
                gbc.SaveChanges();
            }
            result = true;
            return result;
        }
        public bool AddGrain(string name, string itemNumber, string itemGroup, decimal pricePerTon)
        {
            bool result = false;
                using (GrainBarrelContext gbc = new GrainBarrelContext())
                {
                    Grain grain = new Grain() { Name = name, ItemNumber = itemNumber, ItemGroup = itemGroup, PricePerTon = pricePerTon };
                gbc.Grains.Add(grain);
                gbc.SaveChanges();
            }
            result = true;
            return result;
        }
        public bool AddRate(string currencyCode, decimal value)
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                Rate rate = new Rate() { CurrencyCode = currencyCode, Value = value };
                gbc.Rates.Add(rate);
                gbc.SaveChanges();
            }
            result = true;
            return result;
        }
        public bool AddSupplier(string supplierId, string cvr, string name, Address address, ContactInfo contactInfo)
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                Supplyer sup = new Supplyer() { SupplierId = supplierId, Cvr = cvr, Name = name, Address = address, ContactInfo = contactInfo };
                gbc.Suppliers.Add(sup);
                gbc.SaveChanges();
            }
            result = true;
            return result;
        }
        public bool AddUser(string role, string name, ContactInfo contactInfo, Credential credential)
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                User user = new User() { Role = role, Name = name, ContactInfo = contactInfo, Credential = credential };
                gbc.Users.Add(user);
                gbc.SaveChanges();
            }
            result = true;
            return result;
        }
        public bool AddZipTown(string zip, string town)
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                ZipTown zipTown = new ZipTown() { Zip = zip, Town = town };
                gbc.ZipTownList.Add(zipTown);
                gbc.SaveChanges();
            }
            result = true;
            return result;
        }

        public bool CheckCredentials(string userName, string passWord)
        {
            bool result = false;
            try
            {
                foreach (Credential credential in this.GBC.Credentials)
                {
                    if (credential.Active == false)
                    {
                        break;
                    }
                    else if (credential.UserName == userName && credential.PassWord == passWord)
                    {
                        result = true;
                        SetUser(credential);
                        break;
                    }
                }
            }
            catch (Exception)
            {

                result = false;
                ;
            }
            return result;
        }

        private void SetUser(Credential credential)
        {
            user = new User();
            foreach (User item in GBC.Users)
            {
                if (item.Credential == credential)
                {
                    user = item;
                    break;
                }
            }
        }

        public bool UpdateAddress(string road, string zip, string town, string place = "")
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                Address adr = new Address() { Road = road, Place = place, ZipTown = new ZipTown() { Zip = zip, Town = town } };
                gbc.Addresses.Add(adr);
                gbc.SaveChanges();
                result = true;
            }
            return result;
        }
        public bool UpdateBaseRate(string currencyCode, string currencyName)
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                var target = gbc.BaseRates.SingleOrDefault(b => b.CurrencyCode == currencyCode);
                BaseRate baseRate = new BaseRate() { CurrencyCode = currencyCode, CurrencyName = currencyName };
                if (target != null)
                {
                    target = baseRate;
                    gbc.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
        public bool UpdateContactInfo(string email = "", string phone = "", string mobile = "", string url = "")
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                var target = gbc.ContactInfolist.SingleOrDefault(b => b.Email == email);
                ContactInfo info = new ContactInfo() { Email = email, Phone = phone, Mobile = mobile, Url = url };
                if (target != null)
                {
                    target = info;
                    gbc.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
        public bool UpdateCredential(string userName, string passWord, bool active = false)
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                var target = gbc.Credentials.SingleOrDefault(b => b.UserName == userName);
                Credential cred = new Credential() { UserName = userName, PassWord = passWord, Active = active };
                if (target != null)
                {
                    target = cred;
                    gbc.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
        public bool UpdateDollarRate(List<Rate> rateList, string Disclaimer, string Licence, string Timestamp, string Base, Dictionary<string, decimal> Rates)
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                var target = gbc.DollarRates.SingleOrDefault(b => b.timestamp == Timestamp);
                DollarRate dollarRate = new DollarRate() { RateList = rateList, disclaimer = Disclaimer, licence = Licence, timestamp = Timestamp, @base = Base, rates = Rates };
                if (target != null)
                {
                    target = dollarRate;
                    gbc.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
        public bool UpdateGrain(string name, string itemNumber, string itemGroup, decimal pricePerTon)
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                var target = gbc.Grains.SingleOrDefault(b => b.Name == itemNumber);
                Grain grain = new Grain() { Name = name, ItemNumber = itemNumber, ItemGroup = itemGroup, PricePerTon = pricePerTon };
                if (target != null)
                {
                    target = grain;
                    gbc.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
        public bool UpdateRate(string currencyCode, decimal value)
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                var target = gbc.Rates.SingleOrDefault(b => b.CurrencyCode == currencyCode);
                Rate rate = new Rate() { CurrencyCode = currencyCode, Value = value };
                if (target != null)
                {
                    target = rate;
                    gbc.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
        public bool UpdateSupplier(string supplierId, string cvr, string name, Address address, ContactInfo contactInfo)
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                var target = gbc.Suppliers.SingleOrDefault(b => b.SupplierId == supplierId);
                Supplyer sup = new Supplyer() { SupplierId = supplierId, Cvr = cvr, Name = name, Address = address, ContactInfo = contactInfo };
                if (target != null)
                {
                    target = sup;
                    gbc.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
        public bool UpdateUser(string role, string name, ContactInfo contactInfo, Credential credential)
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                var target = gbc.Users.SingleOrDefault(b => b.Name == name);
                User user = new User() { Role = role, Name = name, ContactInfo = contactInfo, Credential = credential };
                if (target != null)
                {
                    target = user;
                    gbc.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
        public bool UpdateZipTown(string zip, string town)
        {
            bool result = false;
            using (GrainBarrelContext gbc = new GrainBarrelContext())
            {
                var target = gbc.ZipTownList.SingleOrDefault(b => b.Zip == town);
                ZipTown zipTown = new ZipTown() { Zip = zip, Town = town };
                if (target != null)
                {
                    target = zipTown;
                    gbc.SaveChanges();
                    result = true;
                }
            }
            return result;
        }
    }
}
