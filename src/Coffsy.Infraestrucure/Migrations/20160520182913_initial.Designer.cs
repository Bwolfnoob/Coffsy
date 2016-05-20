using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Coffsy.vPet.Infraestructure.data.Context;

namespace Coffsy.Infraestrucure.Migrations
{
    [DbContext(typeof(CoffsyContext))]
    [Migration("20160520182913_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Coffsy.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("City");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("District");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Obs");

                    b.Property<string>("Street");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Coffsy.Domain.Entities.Carrier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressId");

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("WebSite");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Coffsy.Domain.Entities.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<int?>("CarrierId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<int>("Rate");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Coffsy.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Coffsy.Domain.Entities.Carrier", b =>
                {
                    b.HasOne("Coffsy.Domain.Entities.Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("Coffsy.Domain.Entities.Rating", b =>
                {
                    b.HasOne("Coffsy.Domain.Entities.Carrier")
                        .WithMany()
                        .HasForeignKey("CarrierId");

                    b.HasOne("Coffsy.Domain.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
