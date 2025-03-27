namespace EventManagement.Business.Utilities.Mappers
{
    public static class MapperTool<Type> where Type : class, IMapperTool, new()
    {
        private static IMapperTool _mapperTool => new Type();

        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapperTool.Map<TSource, TDestination>(source);
        }

        public static THedef Map<TKaynak, THedef>(TKaynak kaynak, THedef hedef)
        {
            return _mapperTool.Map(kaynak, hedef);
        }
    }
}
