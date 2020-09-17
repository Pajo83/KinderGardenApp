using KinderGarden.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace KinderGarden.Data
{
    public interface IKindergardenData
    {
        IEnumerable<Kindergarden> GetKindergardens();
        int Count();
        Kindergarden GetKindergardenById(int kinderGardenId);
        Kid GetKidById(int kidId);
        Kindergarden GetKindergardenByName(string kindergardenName);
        Kindergarden Update(Kindergarden kindergarden);
        int Commit();
        Kindergarden Create(Kindergarden kindergarden);
        Kindergarden Delete(int kinderGardenId);
        Kid DeleteKid(int kidId);
    }
}
