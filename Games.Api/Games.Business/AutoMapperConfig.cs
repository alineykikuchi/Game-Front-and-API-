using AutoMapper;

namespace Games.Business
{
    public static class AutoMapperConfig 
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(x =>  
            {
                x.AddProfile<ModelToEntityProfile>();
                x.AddProfile<EntityToModelProfile>();
            });

        }
    }
}
