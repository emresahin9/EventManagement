namespace EventManagement.Business.Utilities.Mappers
{
    public interface IMapperTool
    {
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}
