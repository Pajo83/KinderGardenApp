using KinderGarden.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace KinderGarden.Data
{
    public interface IKindergardenData
    {
        IEnumerable<Kindergardens> GetKindergardens();
        int Count();
        Kindergardens GetKindergardenById(int kinderGardenId);
        Kid GetKidById(int kidId);
        Parents GetParentById(int parentId);
        Kindergardens GetKindergardenByName(string kindergardenName);
        Kindergardens Update(Kindergardens kindergarden);
        int Commit();
        Kindergardens Create(Kindergardens kindergarden);
        Kindergardens Delete(int kinderGardenId);
        Kid DeleteKid(int kidId);
        bool CheckLogIn(string username, string password);
    }
}
