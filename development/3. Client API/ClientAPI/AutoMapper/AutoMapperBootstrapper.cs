using AutoMapper;
using ClientAPI.AutoMapper.Profiles;

namespace ClientAPI.AutoMapper
{
    public class AutoMapperBootstrapper
    {
        public void Bootstrap()
        {
            Mapper.AddProfile(new ClientAPIProfile());
        }
    }
}