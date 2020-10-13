using KinderGarden.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace KinderGarden.Data
{
    public class KinderGardenSqlData : IKindergardenData
    {
        private readonly KindergardenDbContext kindergardenDb;

        public KinderGardenSqlData(KindergardenDbContext kindergardenDb)
        {
            this.kindergardenDb = kindergardenDb;
        }
        public int Commit()
        {
            return kindergardenDb.SaveChanges();
        }

        public int Count()
        {
            return kindergardenDb.Kindergardens.Count();
        }

        public Kindergardens Create(Kindergardens kindergarden)
        {
            kindergardenDb.Kindergardens.Add(kindergarden);
            return kindergarden;
        }

        public Kindergardens Delete(int kinderGardenId)
        {
            throw new NotImplementedException();
        }

        public Kid DeleteKid(int kidId)
        {
            var tempKid = kindergardenDb.Kids.Where(k => k.Id == kidId).Single();
            if (tempKid != null)
            {
                kindergardenDb.Kids.Remove(tempKid);
            }
            return tempKid;
        }

        public Kid GetKidById(int kidId)
        {
            return kindergardenDb.Kids.Where(k => k.Id == kidId).Single();
        }

        public Parents GetParentById(int parentId)
        {
            return kindergardenDb.Parents.Where(p => p.Id == parentId).Single();
        }

        public Kindergardens GetKindergardenById(int kinderGardenId)
        {
            throw new NotImplementedException();
        }

        public Kindergardens GetKindergardenByName(string kindergardenName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Kindergardens> GetKindergardens()
        {
            throw new NotImplementedException();
        }

        public Kindergardens Update(Kindergardens kindergarden)
        {
            throw new NotImplementedException();
        }

        public bool CheckLogIn(string username, string password )
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                byte[] bytes = Encoding.ASCII.GetBytes(password);
                password = mySHA256.ComputeHash(bytes).ToString();
                   
            }
            var user = kindergardenDb.Users.Where(u => u.Email == username && u.Password == password).Any();
            return user == null ? false : true;
        }
    }
}
