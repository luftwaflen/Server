using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure;

public class DiaryDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Diary> Diaries { get; set; }
    public DbSet<DiaryNote> DiaryNotes { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeRelation> RecipeRelations { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<FamilyRole> FamilyRoles { get; set; }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }

    public DiaryDbContext(DbContextOptions<DiaryDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<RecipeRelation>()
            .HasKey(pdr => new { pdr.PatientId, pdr.DoctorId, pdr.RecipeId });

        modelBuilder.Entity<RecipeRelation>()
            .HasOne(pdr => pdr.Patient)
            .WithMany(p => p.RecipeRelations)
            .HasForeignKey(pdr => pdr.PatientId);

        modelBuilder.Entity<RecipeRelation>()
            .HasOne(pdr => pdr.Doctor)
            .WithMany(d => d.RecipeRelations)
            .HasForeignKey(pdr => pdr.DoctorId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<RecipeRelation>()
            .HasOne(pdr => pdr.Recipe)
            .WithOne(r => r.RecipeRelation);
        //.HasForeignKey(pdr => pdr.RecipeId);

//        var users = new List<User>
//        {
//            new User("allfather", "12345678"),
//            new User("primary_admin", "111111"),
//            new User("secondary_admin", "222222"),
//            new User("doctor", "doctor"),
//            new User("dr_jones", "securePass456"),
//            new User("dr_brown", "brownPassword"),
//            new User("dr_doe", "doeSecure789"),
//            new User("patient", "patient"),
//            new User("golovach_legenda", "talant7k"),
//            new User("jane_smith", "securepass456"),
//            new User("robert_jones", "qwerty789"),
//            new User("emily_clark", "password321"),
//            new User("michael_brown", "mypassword456"),
//            new User("linda_davis", "pass123456"),
//            new User("james_moore", "password987"),
//        };

//        var patients = new List<Patient>
//        {
//            new Patient(users[7]),
//            new Patient(users[8]),
//            new Patient(users[9]),
//            new Patient(users[10]),
//            new Patient(users[11]),
//            new Patient(users[12]),
//            new Patient(users[13]),
//            new Patient(users[14]),
//        };

//        var diaries = new List<Diary>();
//        for (int i = 0; i < 8; i++)
//        {
//            diaries.Add(patients[i].Diary);
//        }

//        var doctors = new List<Doctor>
//        {
//            new Doctor(users[3], "Джон", "Смит"),
//            new Doctor(users[4], "Алиса", "Джонс"),
//            new Doctor(users[5], "Боб", "Браун"),
//            new Doctor(users[6], "Джейн", "Ду")
//        };

//        var admins = new List<Admin>
//        {
//            new Admin(users[0]),
//            new Admin(users[1]),
//            new Admin(users[2])
//        };

        
//        for (int i = 0; i < 8; i++)
//        {
//            users.Add(patients[i].User);
//        }
//        for (int i = 0; i < 4; i++)
//        {
//            users.Add(doctors[i].User);
//        }
//        for (int i = 0; i < 3; i++)
//        {
//            users.Add(admins[i].User);
//        }

//        var diaryNotes = new List<DiaryNote>
//{
//    new DiaryNote(new DateTime(2024, 6, 1, 8, 0, 0), "160", "100", "90", "Чувствую себя хорошо, никаких проблем."),
//    new DiaryNote(new DateTime(2024, 6, 2, 8, 0, 0), "165", "105", "92", "Легкая головная боль, в остальном нормально."),
//    new DiaryNote(new DateTime(2024, 6, 3, 8, 0, 0), "158", "98", "88", "Чувствую себя отлично, гулял."),
//    new DiaryNote(new DateTime(2024, 6, 4, 8, 0, 0), "170", "110", "95", "Немного устал, напряженный день."),
//    new DiaryNote(new DateTime(2024, 6, 5, 8, 0, 0), "155", "97", "85", "Чувствую себя расслабленным и спокойным."),
//    new DiaryNote(new DateTime(2024, 6, 6, 8, 0, 0), "162", "100", "90", "Никаких проблем, чувствую себя нормально."),
//    new DiaryNote(new DateTime(2024, 6, 7, 8, 0, 0), "164", "99", "91", "Легкое головокружение утром."),
//    new DiaryNote(new DateTime(2024, 6, 8, 8, 0, 0), "168", "103", "94", "Чувствую себя немного тревожно."),
//    new DiaryNote(new DateTime(2024, 6, 9, 8, 0, 0), "159", "98", "89", "Чувствую себя хорошо, занимался спортом."),
//    new DiaryNote(new DateTime(2024, 6, 10, 8, 0, 0), "161", "101", "90", "Обычный день, никаких проблем."),
//    new DiaryNote(new DateTime(2024, 6, 11, 8, 0, 0), "166", "104", "93", "Легкая головная боль вечером."),
//    new DiaryNote(new DateTime(2024, 6, 12, 8, 0, 0), "160", "100", "90", "Чувствую себя хорошо, никаких жалоб."),
//    new DiaryNote(new DateTime(2024, 6, 13, 8, 0, 0), "163", "102", "91", "Немного устал, длинный рабочий день."),
//    new DiaryNote(new DateTime(2024, 6, 14, 8, 0, 0), "157", "97", "88", "Чувствую себя энергичным и позитивным."),
//    new DiaryNote(new DateTime(2024, 6, 15, 8, 0, 0), "165", "103", "92", "Легкая тошнота утром."),
//    new DiaryNote(new DateTime(2024, 6, 16, 8, 0, 0), "158", "98", "89", "Чувствую себя хорошо, бегал."),
//    new DiaryNote(new DateTime(2024, 6, 17, 8, 0, 0), "167", "105", "94", "Немного напряжен, занятый день."),
//    new DiaryNote(new DateTime(2024, 6, 18, 8, 0, 0), "159", "99", "90", "Чувствую себя хорошо, никаких проблем."),
//    new DiaryNote(new DateTime(2024, 6, 19, 8, 0, 0), "162", "101", "91", "Легкое головокружение, позже стало лучше."),
//    new DiaryNote(new DateTime(2024, 6, 20, 8, 0, 0), "170", "108", "95", "Чувствую себя тревожно, занятый день."),
//    new DiaryNote(new DateTime(2024, 6, 21, 8, 0, 0), "155", "97", "85", "Чувствую себя спокойно и расслабленно."),
//    new DiaryNote(new DateTime(2024, 6, 22, 8, 0, 0), "164", "100", "90", "Обычный день, никаких жалоб."),
//    new DiaryNote(new DateTime(2024, 6, 23, 8, 0, 0), "168", "104", "93", "Легкая головная боль днем."),
//    new DiaryNote(new DateTime(2024, 6, 24, 8, 0, 0), "161", "100", "89", "Чувствую себя хорошо, никаких проблем."),
//    new DiaryNote(new DateTime(2024, 6, 25, 8, 0, 0), "165", "105", "92", "Легкая головная боль, в остальном нормально."),
//    new DiaryNote(new DateTime(2024, 6, 26, 8, 0, 0), "158", "98", "88", "Чувствую себя отлично, гулял."),
//    new DiaryNote(new DateTime(2024, 6, 27, 8, 0, 0), "170", "110", "95", "Немного устал, напряженный день."),
//    new DiaryNote(new DateTime(2024, 6, 28, 8, 0, 0), "155", "97", "85", "Чувствую себя расслабленным и спокойным."),
//    new DiaryNote(new DateTime(2024, 6, 29, 8, 0, 0), "162", "100", "90", "Никаких проблем, чувствую себя нормально."),
//    new DiaryNote(new DateTime(2024, 6, 30, 8, 0, 0), "164", "99", "91", "Легкое головокружение утром."),
//    new DiaryNote(new DateTime(2024, 7, 1, 8, 0, 0), "168", "103", "94", "Чувствую себя немного тревожно."),
//    new DiaryNote(new DateTime(2024, 7, 2, 8, 0, 0), "159", "98", "89", "Чувствую себя хорошо, занимался спортом."),
//    new DiaryNote(new DateTime(2024, 7, 3, 8, 0, 0), "161", "101", "90", "Обычный день, никаких проблем."),
//    new DiaryNote(new DateTime(2024, 7, 4, 8, 0, 0), "166", "104", "93", "Легкая головная боль вечером."),
//    new DiaryNote(new DateTime(2024, 7, 5, 8, 0, 0), "160", "100", "90", "Чувствую себя хорошо, никаких жалоб."),
//    new DiaryNote(new DateTime(2024, 7, 6, 8, 0, 0), "163", "102", "91", "Немного устал, длинный рабочий день."),
//    new DiaryNote(new DateTime(2024, 7, 7, 8, 0, 0), "157", "97", "88", "Чувствую себя энергичным и позитивным."),
//    new DiaryNote(new DateTime(2024, 7, 8, 8, 0, 0), "165", "103", "92", "Легкая тошнота утром."),
//    new DiaryNote(new DateTime(2024, 7, 9, 8, 0, 0), "158", "98", "89", "Чувствую себя хорошо, бегал."),
//    new DiaryNote(new DateTime(2024, 7, 10, 8, 0, 0), "167", "105", "94", "Немного напряжен, занятый день."),
//    new DiaryNote(new DateTime(2024, 7, 11, 8, 0, 0), "159", "99", "90", "Чувствую себя хорошо, никаких проблем."),
//    new DiaryNote(new DateTime(2024, 7, 12, 8, 0, 0), "162", "101", "91", "Легкое головокружение, позже стало лучше."),
//    new DiaryNote(new DateTime(2024, 7, 13, 8, 0, 0), "170", "108", "95", "Чувствую себя тревожно, занятый день."),
//    new DiaryNote(new DateTime(2024, 7, 14, 8, 0, 0), "155", "97", "85", "Чувствую себя спокойно и расслабленно."),
//    new DiaryNote(new DateTime(2024, 7, 15, 8, 0, 0), "164", "100", "90", "Обычный день, никаких жалоб."),
//    new DiaryNote(new DateTime(2024, 7, 16, 8, 0, 0), "168", "104", "93", "Легкая головная боль днем."),
//    new DiaryNote(new DateTime(2024, 7, 17, 8, 0, 0), "161", "100", "89", "Чувствую себя хорошо, никаких проблем."),
//    new DiaryNote(new DateTime(2024, 7, 18, 8, 0, 0), "165", "105", "92", "Легкая головная боль, в остальном нормально."),
//    new DiaryNote(new DateTime(2024, 7, 19, 8, 0, 0), "158", "98", "88", "Чувствую себя отлично, гулял."),
//    new DiaryNote(new DateTime(2024, 7, 20, 8, 0, 0), "170", "110", "95", "Немного устал, напряженный день."),
//    new DiaryNote(new DateTime(2024, 7, 21, 8, 0, 0), "155", "97", "85", "Чувствую себя расслабленным и спокойным."),
//    new DiaryNote(new DateTime(2024, 7, 22, 8, 0, 0), "162", "100", "90", "Никаких проблем, чувствую себя нормально."),
//    new DiaryNote(new DateTime(2024, 7, 23, 8, 0, 0), "164", "99", "91", "Легкое головокружение утром."),
//    new DiaryNote(new DateTime(2024, 7, 24, 8, 0, 0), "168", "103", "94", "Чувствую себя немного тревожно."),
//    new DiaryNote(new DateTime(2024, 7, 25, 8, 0, 0), "159", "98", "89", "Чувствую себя хорошо, занимался спортом."),
//    new DiaryNote(new DateTime(2024, 7, 26, 8, 0, 0), "161", "101", "90", "Обычный день, никаких проблем."),
//    new DiaryNote(new DateTime(2024, 7, 27, 8, 0, 0), "166", "104", "93", "Легкая головная боль вечером."),
//    new DiaryNote(new DateTime(2024, 7, 28, 8, 0, 0), "160", "100", "90", "Чувствую себя хорошо, никаких жалоб."),
//    new DiaryNote(new DateTime(2024, 7, 29, 8, 0, 0), "163", "102", "91", "Немного устал, длинный рабочий день."),
//    new DiaryNote(new DateTime(2024, 7, 30, 8, 0, 0), "157", "97", "88", "Чувствую себя энергичным и позитивным."),
//    new DiaryNote(new DateTime(2024, 7, 31, 8, 0, 0), "165", "103", "92", "Легкая тошнота утром."),
//    new DiaryNote(new DateTime(2024, 8, 1, 8, 0, 0), "158", "98", "89", "Чувствую себя хорошо, бегал."),
//    new DiaryNote(new DateTime(2024, 8, 2, 8, 0, 0), "167", "105", "94", "Немного напряжен, занятый день."),
//    new DiaryNote(new DateTime(2024, 8, 3, 8, 0, 0), "159", "99", "90", "Чувствую себя хорошо, никаких проблем."),
//    new DiaryNote(new DateTime(2024, 8, 4, 8, 0, 0), "162", "101", "91", "Легкое головокружение, позже стало лучше."),
//    new DiaryNote(new DateTime(2024, 8, 5, 8, 0, 0), "170", "108", "95", "Чувствую себя тревожно, занятый день."),
//    new DiaryNote(new DateTime(2024, 8, 6, 8, 0, 0), "155", "97", "85", "Чувствую себя спокойно и расслабленно."),
//    new DiaryNote(new DateTime(2024, 8, 7, 8, 0, 0), "164", "100", "90", "Обычный день, никаких жалоб."),
//    new DiaryNote(new DateTime(2024, 8, 8, 8, 0, 0), "168", "104", "93", "Легкая головная боль днем."),
//    new DiaryNote(new DateTime(2024, 8, 9, 8, 0, 0), "161", "100", "89", "Чувствую себя хорошо, никаких проблем."),
//    new DiaryNote(new DateTime(2024, 8, 10, 8, 0, 0), "165", "105", "92", "Легкая головная боль, в остальном нормально."),
//    new DiaryNote(new DateTime(2024, 8, 11, 8, 0, 0), "158", "98", "88", "Чувствую себя отлично, гулял."),
//    new DiaryNote(new DateTime(2024, 8, 12, 8, 0, 0), "170", "110", "95", "Немного устал, напряженный день."),
//    new DiaryNote(new DateTime(2024, 8, 13, 8, 0, 0), "155", "97", "85", "Чувствую себя расслабленным и спокойным."),
//    new DiaryNote(new DateTime(2024, 8, 14, 8, 0, 0), "162", "100", "90", "Никаких проблем, чувствую себя нормально."),
//    new DiaryNote(new DateTime(2024, 8, 15, 8, 0, 0), "164", "99", "91", "Легкое головокружение утром."),
//    new DiaryNote(new DateTime(2024, 8, 16, 8, 0, 0), "168", "103", "94", "Чувствую себя немного тревожно."),
//    new DiaryNote(new DateTime(2024, 8, 17, 8, 0, 0), "159", "98", "89", "Чувствую себя хорошо, занимался спортом."),
//    new DiaryNote(new DateTime(2024, 8, 18, 8, 0, 0), "161", "101", "90", "Обычный день, никаких проблем."),
//    new DiaryNote(new DateTime(2024, 8, 19, 8, 0, 0), "166", "104", "93", "Легкая головная боль вечером."),
//    new DiaryNote(new DateTime(2024, 8, 20, 8, 0, 0), "160", "100", "90", "Чувствую себя хорошо, никаких жалоб."),
//    new DiaryNote(new DateTime(2024, 8, 21, 8, 0, 0), "163", "102", "91", "Немного устал, длинный рабочий день."),
//    new DiaryNote(new DateTime(2024, 8, 22, 8, 0, 0), "157", "97", "88", "Чувствую себя энергичным и позитивным."),
//    new DiaryNote(new DateTime(2024, 8, 23, 8, 0, 0), "165", "103", "92", "Легкая тошнота утром."),
//    new DiaryNote(new DateTime(2024, 8, 24, 8, 0, 0), "158", "98", "89", "Чувствую себя хорошо, бегал."),
//    new DiaryNote(new DateTime(2024, 8, 25, 8, 0, 0), "167", "105", "94", "Немного напряжен, занятый день."),
//    new DiaryNote(new DateTime(2024, 8, 26, 8, 0, 0), "159", "99", "90", "Чувствую себя хорошо, никаких проблем."),
//    new DiaryNote(new DateTime(2024, 8, 27, 8, 0, 0), "162", "101", "91", "Легкое головокружение, позже стало лучше."),
//    new DiaryNote(new DateTime(2024, 8, 28, 8, 0, 0), "170", "108", "95", "Чувствую себя тревожно, занятый день."),
//    new DiaryNote(new DateTime(2024, 8, 29, 8, 0, 0), "155", "97", "85", "Чувствую себя спокойно и расслабленно."),
//    new DiaryNote(new DateTime(2024, 8, 30, 8, 0, 0), "164", "100", "90", "Обычный день, никаких жалоб."),
//    new DiaryNote(new DateTime(2024, 8, 31, 8, 0, 0), "168", "104", "93", "Легкая головная боль днем.")
//};
//        for (int i = 0; i < 8; i++)
//        {
//            for (int j = 0; j < 10; j++)
//            {
//                patients[i].Diary.DiaryNotes.Add(diaryNotes[j]);
//            }
//        }

//        var familyRoles = new List<FamilyRole>
//        {
//            new FamilyRole("invited"),
//            new FamilyRole("member"),
//            new FamilyRole("creator"),
//        };

//        var recipes = new List<Recipe>
//        {
//            new Recipe("Следите за вашим питанием, предпочитайте низкосолевую диету, ограничивайте потребление жиров."),
//            new Recipe("Умеренно занимайтесь физическими упражнениями, такими как ходьба или плавание."),
//            new Recipe("Соблюдайте режим сна, старайтесь спать не менее 7-8 часов в сутки."),
//            new Recipe("Избегайте стрессовых ситуаций и научитесь расслабляться с помощью медитации или йоги."),
//            new Recipe("Ограничьте потребление кофеина и алкоголя."),
//            new Recipe("Регулярно контролируйте ваше давление и записывайте показатели в дневник."),
//            new Recipe("Придерживайтесь рекомендаций вашего врача относительно приема лекарств."),
//            new Recipe("Избегайте курения и контакта с пассивным курением."),
//            new Recipe("Помните, что умеренное потребление соли помогает контролировать давление."),
//            new Recipe("Постарайтесь поддерживать здоровый вес."),
//            new Recipe("Пейте достаточное количество воды каждый день."),
//            new Recipe("Регулярно измеряйте ваш пульс и контролируйте его."),
//            new Recipe("Избегайте длительных периодов без движения, делайте перерывы и растяжку во время работы."),
//            new Recipe("Потребляйте больше фруктов и овощей, богатых калием."),
//            new Recipe("Ограничьте потребление продуктов, содержащих холестерин."),
//            new Recipe("Уменьшите количество потребляемого сахара."),
//            new Recipe("Следите за уровнем холестерина в вашей диете."),
//            new Recipe("Избегайте пищи, богатой насыщенными жирами."),
//            new Recipe("Регулярно проводите медицинские обследования и следите за вашими показателями."),
//            new Recipe("Постарайтесь избегать скачков кровяного давления, особенно в стрессовых ситуациях."),
//            new Recipe("Помните, что умеренное употребление алкоголя может быть допустимо, но только после консультации с вашим врачом."),
//            new Recipe("Практикуйте глубокое дыхание и релаксацию для снижения стресса."),
//            new Recipe("Учитывайте ваши индивидуальные особенности и реакции на различные ситуации."),
//            new Recipe("Поддерживайте связь с вашим врачом и сообщайте о любых изменениях в вашем состоянии."),
//            new Recipe("Избегайте излишней физической нагрузки, особенно в жаркую погоду."),
//            new Recipe("Помните, что регулярные физические упражнения могут помочь снизить давление."),
//            new Recipe("Следите за вашим весом и при необходимости консультируйтесь с диетологом."),
//            new Recipe("Помните, что ваши эмоциональные состояния могут влиять на ваше давление."),
//            new Recipe("Практикуйте методы релаксации, такие как йога или медитация."),
//            new Recipe("Пейте достаточное количество воды каждый день."),
//            new Recipe("Практикуйте глубокое дыхание и релаксацию для снижения стресса."),
//            new Recipe("Помните, что умеренное потребление соли помогает контролировать давление.")
//        };

//        var recipeRelations = new List<RecipeRelation>();
//        for (int i = 0; i < 4; i++)
//        {
//            for (int j = 0; j < 2; j++)
//            {
//                for (int k = 0; k < 4; k++)
//                {
//                    var recipeRelation = new RecipeRelation(
//                        patients[i * 2 + j].Id,
//                        doctors[i].Id,
//                        recipes[i * 2 + j * 4 + k].Id,
//                        patients[i * 2 + j],
//                        doctors[i],
//                        recipes[i * 2 + j * 4 + k]);

//                    recipeRelations.Add(recipeRelation);
//                    patients[i*2+j].RecipeRelations.Add(recipeRelation);
//                    doctors[i].RecipeRelations.Add(recipeRelation);
//                }
//            }
//        }

//        modelBuilder.Entity<User>().HasData(users);
//        modelBuilder.Entity<Admin>().HasData(admins);
//        modelBuilder.Entity<Doctor>().HasData(doctors);
//        modelBuilder.Entity<Patient>().HasData(patients);
//        modelBuilder.Entity<Diary>().HasData(diaries);
//        modelBuilder.Entity<DiaryNote>().HasData(diaryNotes);
//        modelBuilder.Entity<Recipe>().HasData(recipes);
//        modelBuilder.Entity<RecipeRelation>().HasData(recipeRelations);
//        modelBuilder.Entity<FamilyRole>().HasData(familyRoles);
    }
}