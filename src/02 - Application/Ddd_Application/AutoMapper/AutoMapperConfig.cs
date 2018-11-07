using AutoMapper;

namespace Ddd.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            var configuration = new MapperConfiguration(cfg =>
           {
               cfg.AddProfile(new DomainToViewModelMappingProfile());
               cfg.AddProfile(new ViewModelToDomainMappingProfile());
           });

            configuration.AssertConfigurationIsValid();

            return configuration;
        }
    }
}