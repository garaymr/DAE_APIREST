using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppDAEREST.Models;

namespace AppDAEREST.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {

        }//Constructor

        protected async override void OnConfiguring(DbContextOptionsBuilder PaOptionsBuilder)
        {
            try{

            }catch (Exception e)
            {

            }
        }

        //Modelos
        #region Inventarios
        //Gestión de inventarios
        public DbSet<zt_inventarios_acumulados> zt_inventarios_acumulados { get; set; }
        public DbSet<zt_inventarios_conteos> zt_inventarios_conteos { get; set; }
        #endregion

        //Proyecto
        public DbSet<rh_cat_personas> rh_cat_personas { get; set; }
        public DbSet<cat_usuarios> cat_usuarios { get; set; }
        public DbSet<rh_cat_dir_web> rh_cat_dir_web { get; set; }
        public DbSet<seg_expira_claves> seg_expira_claves { get; set; }

        //Para la inserción de datos
        protected async override void OnModelCreating(ModelBuilder modelBuilder)
        {
            try
            {
                #region Inventarios
                //Creación de llaves primarias
                modelBuilder.Entity<zt_inventarios_conteos>()
                    .HasKey(c => new { c.NumConteo, c.IdInventario, c.IdAlmacen, c.IdSKU,  c.IdUnidadMedida, c.IdUbicacion});

                modelBuilder.Entity<zt_inventarios_conteos>().HasIndex(x => x.NumConteo).IsUnique(false);
                modelBuilder.Entity<zt_inventarios_conteos>().HasIndex(x => x.IdInventario).IsUnique(false);
                modelBuilder.Entity<zt_inventarios_conteos>().HasIndex(x => x.IdAlmacen).IsUnique(false);
                modelBuilder.Entity<zt_inventarios_conteos>().HasIndex(x => x.IdSKU).IsUnique(false);
                modelBuilder.Entity<zt_inventarios_conteos>().HasIndex(x => x.IdUnidadMedida).IsUnique(false);
                modelBuilder.Entity<zt_inventarios_conteos>().HasIndex(x => x.IdUbicacion).IsUnique(false);

                modelBuilder.Entity<zt_inventarios_acumulados>()
                    .HasKey(c => new { c.IdInventario, c.IdSKU, c.IdUnidadMedida });

                //Creación de llaves foráneas

                #endregion
                #region Proyecto
                //Persona
                modelBuilder.Entity<rh_cat_personas>()
                    .HasKey(c => new { c.IdPersona });

                //Usuario
                modelBuilder.Entity<cat_usuarios>()
                    .HasKey(c => new { c.IdUsuario });

                modelBuilder.Entity<cat_usuarios>()
                .HasOne(s => s.rh_cat_personas).
                WithMany().HasForeignKey(s => new { s.IdPersona });


                //Seg expira
                modelBuilder.Entity<seg_expira_claves>()
                    .HasKey(c => new { c.IdClave, c.IdUsuario });

                modelBuilder.Entity<seg_expira_claves>()
                .HasOne(s => s.cat_usuarios).
                WithMany().HasForeignKey(s => new { s.IdUsuario });
                //Dir web
                modelBuilder.Entity<rh_cat_dir_web>()
                    .HasKey(c => new { c.IdDirWeb });

                modelBuilder.Entity<rh_cat_dir_web>()
                .HasOne(s => s.cat_usuarios).
                WithMany().HasForeignKey(s => new { s.ClaveReferencia });


                #endregion


            }
            catch (Exception e){

            }//catch()
        }//onModelCreating
    }//class
}//namespace
