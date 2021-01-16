﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuizApp.Models;

namespace QuizApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210112050551_ModifyCorrectAnswerToString")]
    partial class ModifyCorrectAnswerToString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10");

            modelBuilder.Entity("QuizApp.Models.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnswerStatement")
                        .HasColumnType("TEXT");

                    b.HasKey("AnswerId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("QuizApp.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("QuizApp.Models.Difficulty", b =>
                {
                    b.Property<int>("DifficultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("DifficultyName")
                        .HasColumnType("TEXT");

                    b.HasKey("DifficultyId");

                    b.ToTable("Difficulties");

                    b.HasData(
                        new
                        {
                            DifficultyId = 1,
                            Description = "easy",
                            DifficultyName = "Easy"
                        },
                        new
                        {
                            DifficultyId = 2,
                            Description = "medium",
                            DifficultyName = "Medium"
                        },
                        new
                        {
                            DifficultyId = 3,
                            Description = "hard",
                            DifficultyName = "Hard"
                        });
                });

            modelBuilder.Entity("QuizApp.Models.Question", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CorrectAnswer")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DifficultyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IncorrectAnswers")
                        .HasColumnType("TEXT");

                    b.Property<string>("QuestionStatement")
                        .HasColumnType("TEXT");

                    b.Property<int?>("QuizId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("QuestionId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("QuizId");

                    b.HasIndex("TypeId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuizApp.Models.Quiz", b =>
                {
                    b.Property<int>("QuizId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("QuizId");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("QuizApp.Models.Type", b =>
                {
                    b.Property<int>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeName")
                        .HasColumnType("TEXT");

                    b.HasKey("TypeId");

                    b.ToTable("Types");

                    b.HasData(
                        new
                        {
                            TypeId = 1,
                            Description = "multiple",
                            TypeName = "Multiple Choice"
                        },
                        new
                        {
                            TypeId = 2,
                            Description = "boolean",
                            TypeName = "True / False"
                        });
                });

            modelBuilder.Entity("QuizApp.Models.Question", b =>
                {
                    b.HasOne("QuizApp.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("QuizApp.Models.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId");

                    b.HasOne("QuizApp.Models.Quiz", null)
                        .WithMany("Questions")
                        .HasForeignKey("QuizId");

                    b.HasOne("QuizApp.Models.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });
#pragma warning restore 612, 618
        }
    }
}