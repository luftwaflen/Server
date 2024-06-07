using Application.Services;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infrastructure.Repositories;

namespace API;

public static class DependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAdminRepository, AdminRepository>();
        services.AddScoped<IDoctorRepository, DoctorRepository>();
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IDiaryRepository, DiaryRepository>();
        services.AddScoped<IDiaryNoteRepository, DiaryNoteRepository>();
        services.AddScoped<IRecipeRepository, RecipeRepository>();
        services.AddScoped<IRecipeRelationRepository, RecipeRelationRepository>();
        services.AddScoped<IFamilyRepository, FamilyRepository>();
        services.AddScoped<IFamilyRolesRepository, FamilyRolesRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<IChatRepository, ChatRepository>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IDoctorService, DoctorService>();
        services.AddScoped<IPatientService, PatientService>();
        services.AddScoped<IChatService, ChatService>();

        return services;
    }
}