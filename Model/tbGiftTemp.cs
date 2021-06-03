using System;
namespace Xmf.SHMYSYS.Model
{
	/// <summary>
	/// tbGift:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tbGiftTemp
	{
		public tbGiftTemp()
		{ }
		#region Model
		private string _guid;
		private string _userguid;
		private string _giftguid;
		private int? _applynum;
		private string _applyname;
		private DateTime? _applydate;
		private int? _isuse;
		private string _giftname;
		/// <summary>
		/// 
		/// </summary>
		public string GIFTNAME
		{
			set { _giftname = value; }
			get { return _giftname; }
		}
		private string _image;
		/// <summary>
		/// 
		/// </summary>
		public string IMAGE
		{
			set { _image = value; }
			get { return _image; }
		}
		private string _detail;
		/// <summary>
		/// 
		/// </summary>
		public string DETAIL
		{
			set { _detail = value; }
			get { return _detail; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string GUID
		{
			set { _guid = value; }
			get { return _guid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string USERGUID
		{
			set { _userguid = value; }
			get { return _userguid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string GIFTGUID
		{
			set { _giftguid = value; }
			get { return _giftguid; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? APPLYNUM
		{
			set { _applynum = value; }
			get { return _applynum; }
		}
		/// <summary>
		/// 
		/// </summary>
		public string APPLYNAME
		{
			set { _applyname = value; }
			get { return _applyname; }
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? APPLYDATE
		{
			set { _applydate = value; }
			get { return _applydate; }
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ISUSE
		{
			set { _isuse = value; }
			get { return _isuse; }
		}
		#endregion Model

	}
}

