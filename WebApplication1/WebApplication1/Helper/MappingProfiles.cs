using AutoMapper;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Helper
{
    public class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
            CreateMap<ThanhPho, ThanhPhoDTO>();
            CreateMap<QuanHuyen, QuanHuyenDTO>();
            CreateMap<ThanhPhoDTO, ThanhPho>();
            CreateMap<QuanHuyenDTO, QuanHuyen>();
        }
    }
}
