﻿// <auto-generated />
using apm.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Storage.Internal;
using System;

namespace apm.Migrations
{
    [DbContext(typeof(ApmContext))]
    [Migration("20180319132051_M01")]
    partial class M01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("apm.Models.Point", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<float>("lat");

                    b.Property<float>("lng");

                    b.Property<int>("pm01_0");

                    b.Property<int>("pm02_5");

                    b.Property<int>("pm10_0");

                    b.HasKey("id");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("apm.Models.Statistic", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("pm01_0");

                    b.Property<int>("pm02_5");

                    b.Property<int>("pm10_0");

                    b.HasKey("id");

                    b.ToTable("Statistics");
                });
#pragma warning restore 612, 618
        }
    }
}