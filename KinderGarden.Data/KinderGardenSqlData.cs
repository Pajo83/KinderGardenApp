using KinderGarden.Core;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Kindergarden Create(Kindergarden kindergarden)
        {
            kindergardenDb.Kindergardens.Add(kindergarden);
            return kindergarden;
        }

        public Kindergarden Delete(int kinderGardenId)
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

        public Kindergarden GetKindergardenById(int kinderGardenId)
        {
            throw new NotImplementedException();
        }

        public Kindergarden GetKindergardenByName(string kindergardenName)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Kindergarden> GetKindergardens()
        {
            throw new NotImplementedException();
        }

        public Kindergarden Update(Kindergarden kindergarden)
        {
            throw new NotImplementedException();
        }
        

    }
}
