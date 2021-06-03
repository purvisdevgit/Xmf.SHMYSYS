using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//Please add references
namespace Xmf.SHMYSYS.DAL
{
	/// <summary>
	/// 数据访问类:tbPower
	/// </summary>
	public partial class tbPower
	{
		public tbPower()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string GUID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tbPower");
			strSql.Append(" where GUID=@GUID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@GUID", OleDbType.VarChar,255)			};
			parameters[0].Value = GUID;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Xmf.SHMYSYS.Model.tbPower model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tbPower(");
			strSql.Append("GUID,ROLE,CATALOG,ISUSE)");
			strSql.Append(" values (");
			strSql.Append("@GUID,@ROLE,@CATALOG,@ISUSE)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@GUID", OleDbType.VarChar,255),
					new OleDbParameter("@ROLE", OleDbType.VarChar,255),
					new OleDbParameter("@CATALOG", OleDbType.VarChar,255),
					new OleDbParameter("@ISUSE", OleDbType.Integer,4)};
			parameters[0].Value = model.GUID;
			parameters[1].Value = model.ROLE;
			parameters[2].Value = model.CATALOG;
			parameters[3].Value = model.ISUSE;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Xmf.SHMYSYS.Model.tbPower model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tbPower set ");
			strSql.Append("ROLE=@ROLE,");
			strSql.Append("CATALOG=@CATALOG,");
			strSql.Append("ISUSE=@ISUSE");
			strSql.Append(" where GUID=@GUID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@ROLE", OleDbType.VarChar,255),
					new OleDbParameter("@CATALOG", OleDbType.VarChar,255),
					new OleDbParameter("@ISUSE", OleDbType.Integer,4),
					new OleDbParameter("@GUID", OleDbType.VarChar,255)};
			parameters[0].Value = model.ROLE;
			parameters[1].Value = model.CATALOG;
			parameters[2].Value = model.ISUSE;
			parameters[3].Value = model.GUID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string GUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbPower ");
			strSql.Append(" where GUID=@GUID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@GUID", OleDbType.VarChar,255)			};
			parameters[0].Value = GUID;

			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string GUIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tbPower ");
			strSql.Append(" where GUID in ("+GUIDlist + ")  ");
			int rows=DbHelperOleDb.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Xmf.SHMYSYS.Model.tbPower GetModel(string GUID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select GUID,ROLE,CATALOG,ISUSE from tbPower ");
			strSql.Append(" where GUID=@GUID ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@GUID", OleDbType.VarChar,255)			};
			parameters[0].Value = GUID;

			Xmf.SHMYSYS.Model.tbPower model=new Xmf.SHMYSYS.Model.tbPower();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Xmf.SHMYSYS.Model.tbPower DataRowToModel(DataRow row)
		{
			Xmf.SHMYSYS.Model.tbPower model=new Xmf.SHMYSYS.Model.tbPower();
			if (row != null)
			{
				if(row["GUID"]!=null)
				{
					model.GUID=row["GUID"].ToString();
				}
				if(row["ROLE"]!=null)
				{
					model.ROLE=row["ROLE"].ToString();
				}
				if(row["CATALOG"]!=null)
				{
					model.CATALOG=row["CATALOG"].ToString();
				}
				if(row["ISUSE"]!=null && row["ISUSE"].ToString()!="")
				{
					model.ISUSE=int.Parse(row["ISUSE"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select GUID,ROLE,CATALOG,ISUSE ");
			strSql.Append(" FROM tbPower ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tbPower ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.GUID desc");
			}
			strSql.Append(")AS Row, T.*  from tbPower T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OleDbParameter[] parameters = {
					new OleDbParameter("@tblName", OleDbType.VarChar, 255),
					new OleDbParameter("@fldName", OleDbType.VarChar, 255),
					new OleDbParameter("@PageSize", OleDbType.Integer),
					new OleDbParameter("@PageIndex", OleDbType.Integer),
					new OleDbParameter("@IsReCount", OleDbType.Boolean),
					new OleDbParameter("@OrderType", OleDbType.Boolean),
					new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
					};
			parameters[0].Value = "tbPower";
			parameters[1].Value = "GUID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

