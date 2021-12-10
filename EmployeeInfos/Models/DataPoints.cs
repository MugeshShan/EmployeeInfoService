using System;
using System.Runtime.Serialization;

namespace EmployeeInfos.Models
{
	/// <summary>
	/// Class for Data Point for Chart
	/// </summary>
    [DataContract]
	public class DataPoints
    {
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="label"></param>
		/// <param name="y"></param>
		public DataPoints(string label, double y)
		{
			this.Label = label;
			this.Y = y;
		}

		/// <summary>
		/// Value for X - axis
		/// </summary>
		[DataMember(Name = "label")]
		public string Label = "";

		/// <summary>
		/// Value for Y - axis
		/// </summary>
		[DataMember(Name = "y")]
		public Nullable<double> Y = null;
	}
}
