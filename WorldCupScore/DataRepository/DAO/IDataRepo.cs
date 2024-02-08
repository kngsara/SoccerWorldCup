using DataRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepo.DAO
{
    public interface IDataRepo
    {
        // fetch matches
        ISet<Matches> GetAllMatches(string championship);
        // fetch teams
        ISet<Results> GetAllResults(string championship);
    }
}
