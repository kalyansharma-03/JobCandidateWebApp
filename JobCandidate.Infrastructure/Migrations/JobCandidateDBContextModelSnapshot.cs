﻿// <auto-generated />
using System;
using System.Diagnostics.CodeAnalysis;
using JobCandidate.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JobCandidate.Infrastructure.Migrations
{
    [ExcludeFromCodeCoverage]
    [DbContext(typeof(JobCandidateDBContext))]
    partial class JobCandidateDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("JobCandidate.Domain.Entities.EJobCandidateDetails", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FreeTextComment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GithubProfileUrl")
                        .HasColumnType("text");

                    b.Property<TimeSpan?>("IntervalEndTime")
                        .HasColumnType("interval");

                    b.Property<TimeSpan?>("IntervalStartTime")
                        .HasColumnType("interval");

                    b.Property<string>("LinkedInProfileUrl")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Email");

                    b.ToTable("JobCandidateDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
