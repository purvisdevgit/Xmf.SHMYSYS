using System;
namespace Xmf.SHMYSYS.Model
{
	/// <summary>
	/// tbPower:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbPower
	{
		public tbPower()
		{}
		#region Model
		private string _guid;
		private string _role;
		private string _catalog;
		private int? _isuse;
		/// <summary>
		/// 
		/// </summary>
		public string GUID
		{
			set{ _guid=value;}
			get{return _guid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ROLE
		{
			set{ _role=value;}
			get{return _role;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CATALOG
		{
			set{ _catalog=value;}
			get{return _catalog;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ISUSE
		{
			set{ _isuse=value;}
			get{return _isuse;}
		}
		#endregion Model

	}
}

