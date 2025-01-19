using DAL.Entities;
using HubTask.Models;
using AutoMapper;
namespace HubTask.Mapper
{
    public class MappingProfile:Profile
    {
        public  MappingProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Job, JobDto>().ReverseMap();  
        }
    }
}
