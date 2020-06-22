using AutoMapper;
using CBA.Training.Talmate.Web.Models;
using CBA.Training.Talmate.Web.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CBA.Training.Talmate.Web
{
    public class DemandProfile:Profile
    {
        public DemandProfile()
        {
            CreateMap<Demand, DemandDTO>();
        }
        
    }
}
