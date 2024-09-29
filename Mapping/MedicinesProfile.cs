using AutoMapper;
using EMedicineBE.Models;
using EMedicineBE.ModelsDTO;

namespace EMedicineBE.Mapping
{
    public class MedicinesProfile:Profile
    {
        public MedicinesProfile()
        {
            CreateMap<Medicines, MedicinesDTO>();
            CreateMap<MedicinesDTO, Medicines>();
        }
    }
}
