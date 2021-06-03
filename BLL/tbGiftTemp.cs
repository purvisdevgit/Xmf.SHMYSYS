using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Xmf.SHMYSYS.Model;
namespace Xmf.SHMYSYS.BLL
{
	/// <summary>
	/// tbGiftTemp
	/// </summary>
	public partial class tbGiftTemp
	{
		private readonly Xmf.SHMYSYS.DAL.tbGiftTemp dal = new Xmf.SHMYSYS.DAL.tbGiftTemp();
		public tbGiftTemp()
		{ }
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string GUID, string USERGUID, string GIFTGUID, int APPLYNUM, string APPLYNAME, DateTime APPLYDATE, int ISUSE)
		{
			return dal.Exists(GUID, USERGUID, GIFTGUID, APPLYNUM, APPLYNAME, APPLYDATE, ISUSE);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Xmf.SHMYSYS.Model.tbGiftTemp model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Xmf.SHMYSYS.Model.tbGiftTemp model)
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
		/// 得到一个对象实体
		/// </summary>
		public Xmf.SHMYSYS.Model.tbGiftTemp GetModel(string GUID, string USERGUID, string GIFTGUID, int APPLYNUM, string APPLYNAME, DateTime APPLYDATE, int ISUSE)
		{

			return dal.GetModel(GUID, USERGUID, GIFTGUID, APPLYNUM, APPLYNAME, APPLYDATE, ISUSE);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Xmf.SHMYSYS.Model.tbGiftTemp GetModelByCache(string GUID, string USERGUID, string GIFTGUID, int APPLYNUM, string APPLYNAME, DateTime APPLYDATE, int ISUSE)
		{

			string CacheKey = "tbGiftTempModel-" + GUID + USERGUID + GIFTGUID + APPLYNUM + APPLYNAME + APPLYDATE + ISUSE;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(GUID, USERGUID, GIFTGUID, APPLYNUM, APPLYNAME, APPLYDATE, ISUSE);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch { }
			}
			return (Xmf.SHMYSYS.Model.tbGiftTemp)objModel;
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
		public List<Xmf.SHMYSYS.Model.tbGiftTemp> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Xmf.SHMYSYS.Model.tbGiftTemp> DataTableToList(DataTable dt)
		{
			List<Xmf.SHMYSYS.Model.tbGiftTemp> modelList = new List<Xmf.SHMYSYS.Model.tbGiftTemp>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Xmf.SHMYSYS.Model.tbGiftTemp model;
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
			return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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

