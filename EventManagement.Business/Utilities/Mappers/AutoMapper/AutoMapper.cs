using AutoMapper;
using AutoMapper.EquivalencyExpression;

namespace EventManagement.Business.Utilities.Mappers.AutoMapper
{
    public class AutoMapper : IMapperTool
    {
        private readonly Mapper _mapper;

        public AutoMapper()
        {
            var config = MapperConfiguration;

            config.CreateMapper();

            _mapper = new Mapper(config);

        }

        public THedef Map<TKaynak, THedef>(TKaynak kaynak)
        {
            return _mapper.Map<THedef>(kaynak);
        }

        public THedef Map<TKaynak, THedef>(TKaynak kaynak, THedef hedef)
        {
            return _mapper.Map(kaynak, hedef);
        }


        private static MapperConfiguration _mapperConfiguration;

        private static MapperConfiguration MapperConfiguration
        {
            get
            {
                if (_mapperConfiguration == null)
                {
                    _mapperConfiguration = new MapperConfiguration(cfg =>
                    {
                        cfg.AddCollectionMappers();

                        cfg.AddProfiles(AutoMapperProfileList.GetAllProfile());
                    });
                }
                return _mapperConfiguration;
            }
        }

    }
}
