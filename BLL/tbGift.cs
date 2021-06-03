﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Xmf.SHMYSYS.Model;
namespace Xmf.SHMYSYS.BLL
{
	/// <summary>
	/// tbGift
	/// </summary>
	public partial class tbGift
	{
		private readonly Xmf.SHMYSYS.DAL.tbGift dal=new Xmf.SHMYSYS.DAL.tbGift();
		public tbGift()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string GUID)
		{
			return dal.Exists(GUID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Xmf.SHMYSYS.Model.tbGift model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Xmf.SHMYSYS.Model.tbGift model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string GUID)
		{
			
			return dal.Delete(GUID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string GUIDlist )
		{
			return dal.DeleteList(GUIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Xmf.SHMYSYS.Model.tbGift GetModel(string GUID)
		{
			
			return dal.GetModel(GUID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Xmf.SHMYSYS.Model.tbGift GetModelByCache(string GUID)
		{
			
			string CacheKey = "tbGiftModel-" + GUID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(GUID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Xmf.SHMYSYS.Model.tbGift)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Xmf.SHMYSYS.Model.tbGift> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Xmf.SHMYSYS.Model.tbGift> DataTableToList(DataTable dt)
		{
			List<Xmf.SHMYSYS.Model.tbGift> modelList = new List<Xmf.SHMYSYS.Model.tbGift>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Xmf.SHMYSYS.Model.tbGift model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

