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
            list.Add(new ResidenceModel { Name = "Auteuil", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });
            list.Add(new ResidenceModel { Name = "Bagatelle", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });
            list.Add(new ResidenceModel { Name = "Breteuil", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });
            list.Add(new ResidenceModel { Name = "Chaillot", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });
            list.Add(new ResidenceModel { Name = "Concorde", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });
            list.Add(new ResidenceModel { Name = "Dauphine", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });
            list.Add(new ResidenceModel { Name = "Etoile", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });
            list.Add(new ResidenceModel { Name = "Foch", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });
            list.Add(new ResidenceModel { Name = "Saint Germain dés Près", Phone1 = "01 39 54 40 26", Phone2 = "06 60 03 63 28" });
            
            return Task.FromResult(list);
        }


        public Task<ResidenceModel> UpdateAsync(ResidenceModel model)
        {
            throw new NotImplementedException();
        }
    }
}
