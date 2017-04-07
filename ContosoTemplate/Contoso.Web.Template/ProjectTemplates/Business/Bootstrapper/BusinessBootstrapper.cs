using AutoMapper;
using $safeprojectname$.Models;
using $rootprojectname$.Data;
using $rootprojectname$.Data.Initializers;
using $rootprojectname$.Data.Interfaces;
using $rootprojectname$.Data.Models;
using $rootprojectname$.Data.Repositories;
using Microsoft.Practices.Unity;
using System.Data.Entity;

namespace $safeprojectname$.Bootstrapper
{
    public static class BusinessBootstrapper
    {
        public static void AddBusinessDependencies(this IUnityContainer container)
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerNameListItem>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(c => c.Id))
                    .ForMember(dest => dest.FullName, opt => opt.MapFrom(c => $"{c.FirstName} {c.LastName}"));
            });

            var mapper = new Mapper(mapperConfiguration);
            container.RegisterInstance<IMapper>(mapper);

            container.RegisterType<IDataContext, DataContext>();
            container.RegisterType<IDataRepository<Customer>, DataRepository<Customer>>();

#if DEBUG
            Database.SetInitializer(new DebugInitializer());
#endif
        }
    }
}
