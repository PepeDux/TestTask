﻿// <auto-generated />
using LibraryAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryAPI.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20241128090454_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("LibraryShared.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("YearPublished")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Лев Толстой",
                            Genre = "Роман",
                            Title = "Война и мир",
                            YearPublished = 1869
                        },
                        new
                        {
                            Id = 2,
                            Author = "Фёдор Достоевский",
                            Genre = "Роман",
                            Title = "Преступление и наказание",
                            YearPublished = 1866
                        },
                        new
                        {
                            Id = 3,
                            Author = "Михаил Булгаков",
                            Genre = "Роман",
                            Title = "Мастер и Маргарита",
                            YearPublished = 1940
                        },
                        new
                        {
                            Id = 4,
                            Author = "Александр Пушкин",
                            Genre = "Поэма",
                            Title = "Евгений Онегин",
                            YearPublished = 1833
                        },
                        new
                        {
                            Id = 5,
                            Author = "Иван Тургенев",
                            Genre = "Роман",
                            Title = "Отцы и дети",
                            YearPublished = 1862
                        },
                        new
                        {
                            Id = 6,
                            Author = "Лев Толстой",
                            Genre = "Роман",
                            Title = "Анна Каренина",
                            YearPublished = 1877
                        },
                        new
                        {
                            Id = 7,
                            Author = "Михаил Шолохов",
                            Genre = "Роман",
                            Title = "Тихий Дон",
                            YearPublished = 1940
                        },
                        new
                        {
                            Id = 8,
                            Author = "Борис Пастернак",
                            Genre = "Роман",
                            Title = "Доктор Живаго",
                            YearPublished = 1957
                        },
                        new
                        {
                            Id = 9,
                            Author = "Михаил Лермонтов",
                            Genre = "Роман",
                            Title = "Герой нашего времени",
                            YearPublished = 1840
                        },
                        new
                        {
                            Id = 10,
                            Author = "Андрей Платонов",
                            Genre = "Роман",
                            Title = "Чевенгур",
                            YearPublished = 1929
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
