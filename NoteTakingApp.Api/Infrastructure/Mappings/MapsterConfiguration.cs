using Mapster;
using NoteTakingApp.Application.Note;
using NoteTakingApp.Application.User;
using NoteTakingApp.Domain.Note;
using NoteTakingApp.Domain.User;

namespace NoteTakingApp.Api.Infrastructure.Mappings
{
    public static class MapsterConfiguration
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<UserRequestModel, UserEntity>
            .NewConfig()
            .TwoWays();

            TypeAdapterConfig<UserRequestModel, UserResponseModel>
            .NewConfig()
            .TwoWays();

            TypeAdapterConfig<NoteRequestModel, NoteEntity>
            .NewConfig()
            .Map(dest => dest.CreatedAt, src => DateTime.UtcNow)
            .Map(dest => dest.UpdatedAt, src => DateTime.UtcNow)
            .TwoWays();

            TypeAdapterConfig<NoteEntity, NoteResponseModel>
                .NewConfig()
                .TwoWays();
        }
    }
}