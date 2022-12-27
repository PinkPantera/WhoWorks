using ClientDataService.Interfaces;
using ClientDataService.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ClientDataService.Services
{
    public class ResidenceService : IResidenceService
    {
        public Task<ResidenceModel> CreateAsync(ResidenceModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ResidenceModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ResidenceModel>> GetAllAsync()
        {
            IList<ResidenceModel> list = new List<ResidenceModel>();
            list.Add(new ResidenceModel { Id = 1, Name = "Auteuil", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });
            list.Add(new ResidenceModel { Id = 2, Name = "Bagatelle", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });
            list.Add(new ResidenceModel { Id = 3, Name = "Breteuil", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });
            list.Add(new ResidenceModel { Id = 4, Name = "Chaillot", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });
            list.Add(new ResidenceModel { Id = 5, Name = "Concorde", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });
            list.Add(new ResidenceModel { Id = 6, Name = "Dauphine", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });
            list.Add(new ResidenceModel { Id = 7, Name = "Etoile", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });
            list.Add(new ResidenceModel { Id = 8, Name = "Foch", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });
            list.Add(new ResidenceModel { Id = 9, Name = "Saint Germain dés Près", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });

            return Task.FromResult(list);
        }


        public Task<ResidenceModel> UpdateAsync(ResidenceModel model)
        {
            throw new NotImplementedException();
        }
    }
}
