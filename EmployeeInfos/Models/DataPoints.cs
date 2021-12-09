using System;
using System.Runtime.Serialization;

namespace EmployeeInfos.Models
{
    [DataContract]
	public class DataPoints
    {
		public DataPoints(string label, double y)
		{
			this.Label = label;
			this.Y = y;
		}

		[DataMember(Name = "label")]
		public string Label = "";

		[DataMember(Name = "y")]
		public Nullable<double> Y = null;
	}
}
