#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace System.Demo.DataAccess
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BD_GC_DEMO")]
	public partial class _DBMLDataMaestrosDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public _DBMLDataMaestrosDataContext() : 
				base(global::System.Demo.DataAccess.Properties.Settings.Default.BD_GC_DEMOConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public _DBMLDataMaestrosDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public _DBMLDataMaestrosDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public _DBMLDataMaestrosDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public _DBMLDataMaestrosDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Maestros.demo_mvc_D_Configuracion")]
		public int demo_mvc_D_Configuracion([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> prm_codEmpresa, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> prm_codConfiguracion, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string prm_segUsuarioEdita)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), prm_codEmpresa, prm_codConfiguracion, prm_segUsuarioEdita);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Maestros.demo_mvc_I_Configuracion")]
		public int demo_mvc_I_Configuracion([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] ref System.Nullable<int> prm_codConfiguracion, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> prm_codEmpresa, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string prm_codKeyConfig, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(15)")] string prm_codTabla, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> prm_numNivel, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Char(4)")] string prm_indOrden, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string prm_indTipoValor, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(200)")] string prm_desValor, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(200)")] string prm_desNombre, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(500)")] string prm_gloDescripcion, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> prm_indGenerico, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string prm_desGrupo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> prm_indActivo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string prm_segUsuarioCrea, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string prm_segMaquina)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), prm_codConfiguracion, prm_codEmpresa, prm_codKeyConfig, prm_codTabla, prm_numNivel, prm_indOrden, prm_indTipoValor, prm_desValor, prm_desNombre, prm_gloDescripcion, prm_indGenerico, prm_desGrupo, prm_indActivo, prm_segUsuarioCrea, prm_segMaquina);
			prm_codConfiguracion = ((System.Nullable<int>)(result.GetParameterValue(0)));
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Maestros.demo_mvc_S_Configuracion")]
		public ISingleResult<demo_mvc_S_ConfiguracionResult> demo_mvc_S_Configuracion([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> prm_codEmpresa, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> prm_codConfiguracion, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string prm_codKeyConfig, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string prm_desNombre, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> prm_indActivo)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), prm_codEmpresa, prm_codConfiguracion, prm_codKeyConfig, prm_desNombre, prm_indActivo);
			return ((ISingleResult<demo_mvc_S_ConfiguracionResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Maestros.demo_mvc_S_Configuracion_Paged")]
		public ISingleResult<demo_mvc_S_Configuracion_PagedResult> demo_mvc_S_Configuracion_Paged([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> prm_NumPagina, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> prm_TamPagina, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string prm_OrdenPor, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(4)")] string prm_OrdenTipo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> prm_codEmpresa, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string prm_desNombre, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string prm_codKeyConfig, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(15)")] string prm_codTabla, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string prm_desValor, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> prm_indActivo)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), prm_NumPagina, prm_TamPagina, prm_OrdenPor, prm_OrdenTipo, prm_codEmpresa, prm_desNombre, prm_codKeyConfig, prm_codTabla, prm_desValor, prm_indActivo);
			return ((ISingleResult<demo_mvc_S_Configuracion_PagedResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Maestros.demo_mvc_U_Configuracion")]
		public int demo_mvc_U_Configuracion([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> prm_codEmpresa, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> prm_codConfiguracion, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string prm_codKeyConfig, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(15)")] string prm_codTabla, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> prm_numNivel, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Char(4)")] string prm_indOrden, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(50)")] string prm_indTipoValor, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(200)")] string prm_desValor, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(200)")] string prm_desNombre, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(500)")] string prm_gloDescripcion, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> prm_indGenerico, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(10)")] string prm_desGrupo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> prm_indActivo, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string prm_segUsuarioEdita)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), prm_codEmpresa, prm_codConfiguracion, prm_codKeyConfig, prm_codTabla, prm_numNivel, prm_indOrden, prm_indTipoValor, prm_desValor, prm_desNombre, prm_gloDescripcion, prm_indGenerico, prm_desGrupo, prm_indActivo, prm_segUsuarioEdita);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Maestros.demo_mvc_U_ConfiguracionConfig")]
		public int demo_mvc_U_ConfiguracionConfig([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> prm_codEmpresa, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string prm_codKeyConfig, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(200)")] string prm_desValor, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string prm_segUsuarioEdita, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(30)")] string prm_segMaquina)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), prm_codEmpresa, prm_codKeyConfig, prm_desValor, prm_segUsuarioEdita, prm_segMaquina);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Maestros.demo_mvc_S_Tabla")]
		public ISingleResult<demo_mvc_S_TablaResult> demo_mvc_S_Tabla([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(5)")] string prm_codTabla, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(40)")] string prm_desNombre, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> prm_indActivo)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), prm_codTabla, prm_desNombre, prm_indActivo);
			return ((ISingleResult<demo_mvc_S_TablaResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="Maestros.demo_mvc_S_Registro_Combo")]
		public ISingleResult<demo_mvc_S_Registro_ComboResult> demo_mvc_S_Registro_Combo([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Char(5)")] string prm_codTabla, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(17)")] string prm_codRegistro, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> prm_numNivel, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> prm_indActivo)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), prm_codTabla, prm_codRegistro, prm_numNivel, prm_indActivo);
			return ((ISingleResult<demo_mvc_S_Registro_ComboResult>)(result.ReturnValue));
		}
	}
	
	public partial class demo_mvc_S_ConfiguracionResult
	{
		
		private int _codConfiguracion;
		
		private string _codKeyConfig;
		
		private string _codTabla;
		
		private System.Nullable<int> _numNivel;
		
		private string _indOrden;
		
		private string _indTipoValor;
		
		private string _desValor;
		
		private string _desNombre;
		
		private string _gloDescripcion;
		
		private bool _indGenerico;
		
		private string _desGrupo;
		
		private bool _indActivo;
		
		private string _segUsuarioCrea;
		
		private string _segUsuarioEdita;
		
		private System.DateTime _segFechaCrea;
		
		private System.Nullable<System.DateTime> _segFechaEdita;
		
		private string _segMaquina;
		
		public demo_mvc_S_ConfiguracionResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codConfiguracion", DbType="Int NOT NULL")]
		public int codConfiguracion
		{
			get
			{
				return this._codConfiguracion;
			}
			set
			{
				if ((this._codConfiguracion != value))
				{
					this._codConfiguracion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codKeyConfig", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string codKeyConfig
		{
			get
			{
				return this._codKeyConfig;
			}
			set
			{
				if ((this._codKeyConfig != value))
				{
					this._codKeyConfig = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codTabla", DbType="Char(15)")]
		public string codTabla
		{
			get
			{
				return this._codTabla;
			}
			set
			{
				if ((this._codTabla != value))
				{
					this._codTabla = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_numNivel", DbType="Int")]
		public System.Nullable<int> numNivel
		{
			get
			{
				return this._numNivel;
			}
			set
			{
				if ((this._numNivel != value))
				{
					this._numNivel = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indOrden", DbType="Char(4) NOT NULL", CanBeNull=false)]
		public string indOrden
		{
			get
			{
				return this._indOrden;
			}
			set
			{
				if ((this._indOrden != value))
				{
					this._indOrden = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indTipoValor", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string indTipoValor
		{
			get
			{
				return this._indTipoValor;
			}
			set
			{
				if ((this._indTipoValor != value))
				{
					this._indTipoValor = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desValor", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string desValor
		{
			get
			{
				return this._desValor;
			}
			set
			{
				if ((this._desValor != value))
				{
					this._desValor = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desNombre", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string desNombre
		{
			get
			{
				return this._desNombre;
			}
			set
			{
				if ((this._desNombre != value))
				{
					this._desNombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gloDescripcion", DbType="VarChar(500)")]
		public string gloDescripcion
		{
			get
			{
				return this._gloDescripcion;
			}
			set
			{
				if ((this._gloDescripcion != value))
				{
					this._gloDescripcion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indGenerico", DbType="Bit NOT NULL")]
		public bool indGenerico
		{
			get
			{
				return this._indGenerico;
			}
			set
			{
				if ((this._indGenerico != value))
				{
					this._indGenerico = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desGrupo", DbType="VarChar(20)")]
		public string desGrupo
		{
			get
			{
				return this._desGrupo;
			}
			set
			{
				if ((this._desGrupo != value))
				{
					this._desGrupo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indActivo", DbType="Bit NOT NULL")]
		public bool indActivo
		{
			get
			{
				return this._indActivo;
			}
			set
			{
				if ((this._indActivo != value))
				{
					this._indActivo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segUsuarioCrea", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string segUsuarioCrea
		{
			get
			{
				return this._segUsuarioCrea;
			}
			set
			{
				if ((this._segUsuarioCrea != value))
				{
					this._segUsuarioCrea = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segUsuarioEdita", DbType="VarChar(50)")]
		public string segUsuarioEdita
		{
			get
			{
				return this._segUsuarioEdita;
			}
			set
			{
				if ((this._segUsuarioEdita != value))
				{
					this._segUsuarioEdita = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segFechaCrea", DbType="DateTime NOT NULL")]
		public System.DateTime segFechaCrea
		{
			get
			{
				return this._segFechaCrea;
			}
			set
			{
				if ((this._segFechaCrea != value))
				{
					this._segFechaCrea = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segFechaEdita", DbType="DateTime")]
		public System.Nullable<System.DateTime> segFechaEdita
		{
			get
			{
				return this._segFechaEdita;
			}
			set
			{
				if ((this._segFechaEdita != value))
				{
					this._segFechaEdita = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segMaquina", DbType="VarChar(40) NOT NULL", CanBeNull=false)]
		public string segMaquina
		{
			get
			{
				return this._segMaquina;
			}
			set
			{
				if ((this._segMaquina != value))
				{
					this._segMaquina = value;
				}
			}
		}
	}
	
	public partial class demo_mvc_S_Configuracion_PagedResult
	{
		
		private int _codConfiguracion;
		
		private string _codKeyConfig;
		
		private string _codTabla;
		
		private System.Nullable<int> _numNivel;
		
		private string _indOrden;
		
		private string _indTipoValor;
		
		private string _desValor;
		
		private string _desNombre;
		
		private string _gloDescripcion;
		
		private bool _indGenerico;
		
		private string _desGrupo;
		
		private bool _indActivo;
		
		private string _segUsuarioCrea;
		
		private string _segUsuarioEdita;
		
		private System.DateTime _segFechaCrea;
		
		private System.Nullable<System.DateTime> _segFechaEdita;
		
		private string _segMaquina;
		
		private System.Nullable<int> _TOTALROWS;
		
		private System.Nullable<long> _ROWNUM;
		
		public demo_mvc_S_Configuracion_PagedResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codConfiguracion", DbType="Int NOT NULL")]
		public int codConfiguracion
		{
			get
			{
				return this._codConfiguracion;
			}
			set
			{
				if ((this._codConfiguracion != value))
				{
					this._codConfiguracion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codKeyConfig", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string codKeyConfig
		{
			get
			{
				return this._codKeyConfig;
			}
			set
			{
				if ((this._codKeyConfig != value))
				{
					this._codKeyConfig = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codTabla", DbType="Char(15)")]
		public string codTabla
		{
			get
			{
				return this._codTabla;
			}
			set
			{
				if ((this._codTabla != value))
				{
					this._codTabla = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_numNivel", DbType="Int")]
		public System.Nullable<int> numNivel
		{
			get
			{
				return this._numNivel;
			}
			set
			{
				if ((this._numNivel != value))
				{
					this._numNivel = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indOrden", DbType="Char(4) NOT NULL", CanBeNull=false)]
		public string indOrden
		{
			get
			{
				return this._indOrden;
			}
			set
			{
				if ((this._indOrden != value))
				{
					this._indOrden = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indTipoValor", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string indTipoValor
		{
			get
			{
				return this._indTipoValor;
			}
			set
			{
				if ((this._indTipoValor != value))
				{
					this._indTipoValor = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desValor", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string desValor
		{
			get
			{
				return this._desValor;
			}
			set
			{
				if ((this._desValor != value))
				{
					this._desValor = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desNombre", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string desNombre
		{
			get
			{
				return this._desNombre;
			}
			set
			{
				if ((this._desNombre != value))
				{
					this._desNombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gloDescripcion", DbType="VarChar(500)")]
		public string gloDescripcion
		{
			get
			{
				return this._gloDescripcion;
			}
			set
			{
				if ((this._gloDescripcion != value))
				{
					this._gloDescripcion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indGenerico", DbType="Bit NOT NULL")]
		public bool indGenerico
		{
			get
			{
				return this._indGenerico;
			}
			set
			{
				if ((this._indGenerico != value))
				{
					this._indGenerico = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desGrupo", DbType="VarChar(20)")]
		public string desGrupo
		{
			get
			{
				return this._desGrupo;
			}
			set
			{
				if ((this._desGrupo != value))
				{
					this._desGrupo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indActivo", DbType="Bit NOT NULL")]
		public bool indActivo
		{
			get
			{
				return this._indActivo;
			}
			set
			{
				if ((this._indActivo != value))
				{
					this._indActivo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segUsuarioCrea", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string segUsuarioCrea
		{
			get
			{
				return this._segUsuarioCrea;
			}
			set
			{
				if ((this._segUsuarioCrea != value))
				{
					this._segUsuarioCrea = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segUsuarioEdita", DbType="VarChar(50)")]
		public string segUsuarioEdita
		{
			get
			{
				return this._segUsuarioEdita;
			}
			set
			{
				if ((this._segUsuarioEdita != value))
				{
					this._segUsuarioEdita = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segFechaCrea", DbType="DateTime NOT NULL")]
		public System.DateTime segFechaCrea
		{
			get
			{
				return this._segFechaCrea;
			}
			set
			{
				if ((this._segFechaCrea != value))
				{
					this._segFechaCrea = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segFechaEdita", DbType="DateTime")]
		public System.Nullable<System.DateTime> segFechaEdita
		{
			get
			{
				return this._segFechaEdita;
			}
			set
			{
				if ((this._segFechaEdita != value))
				{
					this._segFechaEdita = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segMaquina", DbType="VarChar(40) NOT NULL", CanBeNull=false)]
		public string segMaquina
		{
			get
			{
				return this._segMaquina;
			}
			set
			{
				if ((this._segMaquina != value))
				{
					this._segMaquina = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TOTALROWS", DbType="Int")]
		public System.Nullable<int> TOTALROWS
		{
			get
			{
				return this._TOTALROWS;
			}
			set
			{
				if ((this._TOTALROWS != value))
				{
					this._TOTALROWS = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ROWNUM", DbType="BigInt")]
		public System.Nullable<long> ROWNUM
		{
			get
			{
				return this._ROWNUM;
			}
			set
			{
				if ((this._ROWNUM != value))
				{
					this._ROWNUM = value;
				}
			}
		}
	}
	
	public partial class demo_mvc_S_TablaResult
	{
		
		private string _codTabla;
		
		private string _desNombre;
		
		private string _gloDescripcion;
		
		private int _numLongitudNivel;
		
		private bool _indNivel;
		
		private char _TipoArgumento;
		
		private char _TipoGeneracion;
		
		private bool _indActivo;
		
		private string _segUsuCrea;
		
		private string _segUsuEdita;
		
		private System.DateTime _segFechaCrea;
		
		private System.Nullable<System.DateTime> _segFechaEdita;
		
		private string _segMaquinaOrigen;
		
		public demo_mvc_S_TablaResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codTabla", DbType="Char(5) NOT NULL", CanBeNull=false)]
		public string codTabla
		{
			get
			{
				return this._codTabla;
			}
			set
			{
				if ((this._codTabla != value))
				{
					this._codTabla = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desNombre", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string desNombre
		{
			get
			{
				return this._desNombre;
			}
			set
			{
				if ((this._desNombre != value))
				{
					this._desNombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gloDescripcion", DbType="NVarChar(300) NOT NULL", CanBeNull=false)]
		public string gloDescripcion
		{
			get
			{
				return this._gloDescripcion;
			}
			set
			{
				if ((this._gloDescripcion != value))
				{
					this._gloDescripcion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_numLongitudNivel", DbType="Int NOT NULL")]
		public int numLongitudNivel
		{
			get
			{
				return this._numLongitudNivel;
			}
			set
			{
				if ((this._numLongitudNivel != value))
				{
					this._numLongitudNivel = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indNivel", DbType="Bit NOT NULL")]
		public bool indNivel
		{
			get
			{
				return this._indNivel;
			}
			set
			{
				if ((this._indNivel != value))
				{
					this._indNivel = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TipoArgumento", DbType="Char(1) NOT NULL")]
		public char TipoArgumento
		{
			get
			{
				return this._TipoArgumento;
			}
			set
			{
				if ((this._TipoArgumento != value))
				{
					this._TipoArgumento = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TipoGeneracion", DbType="Char(1) NOT NULL")]
		public char TipoGeneracion
		{
			get
			{
				return this._TipoGeneracion;
			}
			set
			{
				if ((this._TipoGeneracion != value))
				{
					this._TipoGeneracion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indActivo", DbType="Bit NOT NULL")]
		public bool indActivo
		{
			get
			{
				return this._indActivo;
			}
			set
			{
				if ((this._indActivo != value))
				{
					this._indActivo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segUsuCrea", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string segUsuCrea
		{
			get
			{
				return this._segUsuCrea;
			}
			set
			{
				if ((this._segUsuCrea != value))
				{
					this._segUsuCrea = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segUsuEdita", DbType="VarChar(50)")]
		public string segUsuEdita
		{
			get
			{
				return this._segUsuEdita;
			}
			set
			{
				if ((this._segUsuEdita != value))
				{
					this._segUsuEdita = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segFechaCrea", DbType="DateTime NOT NULL")]
		public System.DateTime segFechaCrea
		{
			get
			{
				return this._segFechaCrea;
			}
			set
			{
				if ((this._segFechaCrea != value))
				{
					this._segFechaCrea = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segFechaEdita", DbType="DateTime")]
		public System.Nullable<System.DateTime> segFechaEdita
		{
			get
			{
				return this._segFechaEdita;
			}
			set
			{
				if ((this._segFechaEdita != value))
				{
					this._segFechaEdita = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segMaquinaOrigen", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string segMaquinaOrigen
		{
			get
			{
				return this._segMaquinaOrigen;
			}
			set
			{
				if ((this._segMaquinaOrigen != value))
				{
					this._segMaquinaOrigen = value;
				}
			}
		}
	}
	
	public partial class demo_mvc_S_Registro_ComboResult
	{
		
		private string _codTabla;
		
		private string _codRegistro;
		
		private int _numNivel;
		
		private string _desNombre;
		
		private string _gloDescripcion;
		
		private decimal _desValorDecimal;
		
		private string _desValorCadena;
		
		private bool _desValorLogico;
		
		private int _desValorEntero;
		
		private System.Nullable<System.DateTime> _desValorFecha;
		
		private bool _indActivo;
		
		private string _codValorSunat;
		
		private string _codigoTMP;
		
		private int _numLongitudNivel;
		
		private System.Nullable<System.DateTime> _segFechaEdita;
		
		private string _segUsuarioEdita;
		
		private string _segMaquinaEdita;
		
		public demo_mvc_S_Registro_ComboResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codTabla", DbType="Char(5) NOT NULL", CanBeNull=false)]
		public string codTabla
		{
			get
			{
				return this._codTabla;
			}
			set
			{
				if ((this._codTabla != value))
				{
					this._codTabla = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codRegistro", DbType="VarChar(17) NOT NULL", CanBeNull=false)]
		public string codRegistro
		{
			get
			{
				return this._codRegistro;
			}
			set
			{
				if ((this._codRegistro != value))
				{
					this._codRegistro = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_numNivel", DbType="Int NOT NULL")]
		public int numNivel
		{
			get
			{
				return this._numNivel;
			}
			set
			{
				if ((this._numNivel != value))
				{
					this._numNivel = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desNombre", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string desNombre
		{
			get
			{
				return this._desNombre;
			}
			set
			{
				if ((this._desNombre != value))
				{
					this._desNombre = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gloDescripcion", DbType="NVarChar(300) NOT NULL", CanBeNull=false)]
		public string gloDescripcion
		{
			get
			{
				return this._gloDescripcion;
			}
			set
			{
				if ((this._gloDescripcion != value))
				{
					this._gloDescripcion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desValorDecimal", DbType="Decimal(15,5) NOT NULL")]
		public decimal desValorDecimal
		{
			get
			{
				return this._desValorDecimal;
			}
			set
			{
				if ((this._desValorDecimal != value))
				{
					this._desValorDecimal = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desValorCadena", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string desValorCadena
		{
			get
			{
				return this._desValorCadena;
			}
			set
			{
				if ((this._desValorCadena != value))
				{
					this._desValorCadena = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desValorLogico", DbType="Bit NOT NULL")]
		public bool desValorLogico
		{
			get
			{
				return this._desValorLogico;
			}
			set
			{
				if ((this._desValorLogico != value))
				{
					this._desValorLogico = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desValorEntero", DbType="Int NOT NULL")]
		public int desValorEntero
		{
			get
			{
				return this._desValorEntero;
			}
			set
			{
				if ((this._desValorEntero != value))
				{
					this._desValorEntero = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_desValorFecha", DbType="DateTime")]
		public System.Nullable<System.DateTime> desValorFecha
		{
			get
			{
				return this._desValorFecha;
			}
			set
			{
				if ((this._desValorFecha != value))
				{
					this._desValorFecha = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_indActivo", DbType="Bit NOT NULL")]
		public bool indActivo
		{
			get
			{
				return this._indActivo;
			}
			set
			{
				if ((this._indActivo != value))
				{
					this._indActivo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codValorSunat", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string codValorSunat
		{
			get
			{
				return this._codValorSunat;
			}
			set
			{
				if ((this._codValorSunat != value))
				{
					this._codValorSunat = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codigoTMP", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string codigoTMP
		{
			get
			{
				return this._codigoTMP;
			}
			set
			{
				if ((this._codigoTMP != value))
				{
					this._codigoTMP = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_numLongitudNivel", DbType="Int NOT NULL")]
		public int numLongitudNivel
		{
			get
			{
				return this._numLongitudNivel;
			}
			set
			{
				if ((this._numLongitudNivel != value))
				{
					this._numLongitudNivel = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segFechaEdita", DbType="DateTime")]
		public System.Nullable<System.DateTime> segFechaEdita
		{
			get
			{
				return this._segFechaEdita;
			}
			set
			{
				if ((this._segFechaEdita != value))
				{
					this._segFechaEdita = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segUsuarioEdita", DbType="VarChar(50)")]
		public string segUsuarioEdita
		{
			get
			{
				return this._segUsuarioEdita;
			}
			set
			{
				if ((this._segUsuarioEdita != value))
				{
					this._segUsuarioEdita = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_segMaquinaEdita", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string segMaquinaEdita
		{
			get
			{
				return this._segMaquinaEdita;
			}
			set
			{
				if ((this._segMaquinaEdita != value))
				{
					this._segMaquinaEdita = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
