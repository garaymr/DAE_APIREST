using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDAEREST.Models
{
    public class zt_inventarios_acumulados
    {
        public int IdInventario { get; set; }
        //public zt_inventarios zt_inventarios { get; set; }
        [StringLength(20)]
        public string IdSKU { get; set; }
        //public zt_cat_productos zt_cat_productos { get; set; }
        //[StringLength(50)]
        //public string DesSKU { get; set; }
        [StringLength(10)]
        public string IdUnidadMedida { get; set; }
        //public zt_cat_unidad_medidas zt_cat_unidad_medidas { get; set; }
        public Nullable<double> CantidadTeorica { get; set; }
        public Nullable<double> CantidadTeoricaCJA { get; set; }
        public Nullable<double> CantidadFisica { get; set; }
        public Nullable<double> CantidadFisicaCJA { get; set; }
        public Nullable<double> Diferencia { get; set; }
        public Nullable<double> DiferenciaCJA { get; set; }
        public DateTime FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
        [StringLength(1)]
        public string Reconteo { get; set; }   
    }
    public class zt_inventarios_conteos
    {
        public int IdInventario { get; set; }
        //public zt_inventarios zt_inventarios { get; set; }
        [StringLength(20)]
        public string IdSKU { get; set; }
        [StringLength(10)]
        public string IdUnidadMedida { get; set; }
        [StringLength(20)]
        public string IdAlmacen { get; set; }
        //public zt_cat_almacenes zt_cat_almacenes { get; set; }
        [StringLength(20)]
        public string IdUbicacion { get; set; }
        public int NumConteo { get; set; }
        //public zt_cat_productos zt_cat_productos { get; set; }
        //public zt_cat_unidad_medidas zt_cat_unidad_medidas { get; set; }
        [StringLength(20)]
        public string CodigoBarras { get; set; }
        //public zt_cat_ubicaciones zt_cat_ubicaciones { get; set; }
        public Nullable<double> CantidadFisica { get; set; }
        public Nullable<double> CantidadPZA { get; set; }
        [StringLength(30)]
        public string Lote { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }
    public class zt_inv_conteos_acumulados
    {
        public int IdInventario { get; set; }
        [StringLength(20)]
        public string IdAlmacen { get; set; }
        [StringLength(20)]
        public string IdUbicacion { get; set; }
        [StringLength(20)]
        public string IdUnidadMedida { get; set; }
        [StringLength(20)]
        public string IdSKU { get; set; }
        public int NumConteo { get; set; }
        public Nullable<double> CantidadTeorica { get; set; }
        public Nullable<double> CantidadTeoricaCJA { get; set; }
        public Nullable<double> Diferencia { get; set; }
        public Nullable<double> DiferenciaCJA { get; set; }
        public Nullable<double> CantidadFisica { get; set; }
        public Nullable<double> CantidadFisicaPZA { get; set; }
    }
    public class zt_inv_conteos_acumulados2
    {
        public int IdInventario { get; set; }
        [StringLength(20)]
        public string IdAlmacen { get; set; }
        [StringLength(20)]
        public string IdUbicacion { get; set; }
        [StringLength(20)]
        public string IdUnidadMedida { get; set; }
        [StringLength(20)]
        public string IdSKU { get; set; }
        public int NumConteo { get; set; }
        public Nullable<double> CantidadTeorica { get; set; }
        public Nullable<double> CantidadTeoricaCJA { get; set; }
        public Nullable<double> Diferencia { get; set; }
        public Nullable<double> DiferenciaCJA { get; set; }
        public Nullable<double> CantidadFisica { get; set; }
        public Nullable<double> CantidadFisicaCJA { get; set; }
        public Nullable<double> CantidadPZA { get; set; }
        public string Reconteo { get; set; }
        public string Activo { get; set; }
        public string Borrado { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        public string UsuarioMod { get; set; }
        public string CodigoBarras { get; set; }
        public string Lote { get; set; }
    }

    //-------------------------------------------------------------Clases para proyecto------------------------------

    //rh_cat_personas
    public class rh_cat_personas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPersona { get; set; }//PKD:\AppEvaWebSrv\AppEvaWebSrv\Models\Eva\FicModPersonas.cs
        //public Nullable<Int16> IdInstituto { get; set; } //FK
        //public cat_institutos cat_institutos { get; set; }
        [StringLength(20)]
        public string NumControl { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(60)]
        public string ApPaterno { get; set; }
        [StringLength(60)]
        public string ApMaterno { get; set; }
        [StringLength(15)]
        public string RFC { get; set; }
        [StringLength(25)]
        public string CURP { get; set; }
        public Nullable<DateTime> FechaNac { get; set; }
        [StringLength(1)]
        public string TipoPersona { get; set; }
        [StringLength(1)]
        public string Sexo { get; set; }
        [StringLength(255)]
        public string RutaFoto { get; set; }
        [StringLength(20)]
        public string Alias { get; set; }
        public Nullable<Int16> IdTipoGenOcupacion { get; set; }//FK
        public Nullable<Int16> IdGenOcupacion { get; set; }//FK
        public Nullable<Int16> IdTipoGenEstadoCivil { get; set; }//FK
        public Nullable<Int16> IdGenEstadoCivil { get; set; }//FK
        //public cat_tipos_generales cat_tipos_generales { get; set; }
        //public cat_generales cat_generales { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//Ok

    //seg_expira_claves
    public class seg_expira_claves
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdClave { get; set; }//PK
        public int IdUsuario { get; set; }//PK FK
        public cat_usuarios cat_usuarios { get; set; }
        public Nullable<DateTime> FechaExpiraIni { get; set; }
        public Nullable<DateTime> FechaExpiraFin { get; set; }
        [StringLength(1)]
        public string Actual { get; set; }
        [StringLength(20)]
        public string Clave { get; set; }
        [StringLength(1)]
        public string ClaveAutoSys { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//Ok

    //cat_usuarios
    public class cat_usuarios
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUsuario { get; set; }//PK
        public int IdPersona { get; set; }//FK
        public rh_cat_personas rh_cat_personas { get; set; }
        [StringLength(20)]
        public string Usuario { get; set; }
        [StringLength(1)]
        public string Expira { get; set; }
        [StringLength(1)]
        public string Conectado { get; set; }
        public Nullable<DateTime> FechaAlta { get; set; }
        public Nullable<Int16> NumIntentos { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        //[StringLength(20)]
        //public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }

    }//Ok

    //rh_cat_dir_web
    public class rh_cat_dir_web
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdDirWeb { get; set; }//PK
        [StringLength(50)]
        public string DesDirWeb { get; set; }
        [StringLength(255)]
        public string DireccionWeb { get; set; }
        [StringLength(1)]
        public string Principal { get; set; }
        public Nullable<Int16> IdTipoGenDirWeb { get; set; }//FK
        //public cat_tipos_generales cat_tipos_generales { get; set; }
        public Nullable<Int16> IdGenDirWeb { get; set; }//FK
        //public cat_generales cat_generales { get; set; }
        [StringLength(50)]
        public int ClaveReferencia { get; set; }
        public cat_usuarios cat_usuarios { get; set; }
        [StringLength(50)]
        public string Referencia { get; set; }
        public Nullable<DateTime> FechaReg { get; set; }
        public Nullable<DateTime> FechaUltMod { get; set; }
        [StringLength(20)]
        public string UsuarioReg { get; set; }
        [StringLength(20)]
        public string UsuarioMod { get; set; }
        [StringLength(1)]
        public string Activo { get; set; }
        [StringLength(1)]
        public string Borrado { get; set; }
    }//Ok

    public class zt_usuario_persona
    {
        public int IdPersona { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; }
        [StringLength(20)]
        public string Usuario { get; set; }
        [StringLength(50)]
        public string Correo { get; set; }
        public int IdUsuario { get; set; }
        [StringLength(1)]
        public string Auto { get; set; }
    }

}
