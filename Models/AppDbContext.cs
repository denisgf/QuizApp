using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Type> Types { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Question>().HasMany(q => q.IncorrectAnswers).WithOne(a => a.Question);

            //modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "" });

            // Seed Difficulty

            modelBuilder.Entity<Question>().Property(p => p.IncorrectAnswers).HasConversion(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<string>>(v));

            var valueComparer = new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());

            modelBuilder
                .Entity<Question>()
                .Property(e => e.IncorrectAnswers)
                .Metadata
                .SetValueComparer(valueComparer);            

            modelBuilder.Entity<Difficulty>().HasData(new Difficulty { DifficultyId = 1, DifficultyName = "Easy", Description = "easy" });
            modelBuilder.Entity<Difficulty>().HasData(new Difficulty { DifficultyId = 2, DifficultyName = "Medium", Description = "medium" });
            modelBuilder.Entity<Difficulty>().HasData(new Difficulty { DifficultyId = 3, DifficultyName = "Hard", Description = "hard" });

            modelBuilder.Entity<Type>().HasData(new Type { TypeId = 1, TypeName = "Multiple Choice", Description = "multiple" });
            modelBuilder.Entity<Type>().HasData(new Type { TypeId = 2, TypeName = "True / False", Description = "boolean" });
        }

    }
}
