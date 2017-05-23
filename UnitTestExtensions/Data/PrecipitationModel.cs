using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UnitTestExtensions.Data {
	#region PrecipitationModel

	public class PrecipitationModel {
		public Resultinfo ResultInfo { get; set; }
		public Feature[] Feature { get; set; }
	}

	public class Resultinfo {
		public int Count { get; set; }
		public int Total { get; set; }
		public int Start { get; set; }
		public int Status { get; set; }
		public float Latency { get; set; }
		public string Description { get; set; }
		public string Copyright { get; set; }
	}

	#region Feature

	public class Feature {
		public string Id { get; set; }
		public string Name { get; set; }
		public Geometry Geometry { get; set; }
		public Property Property { get; set; }
	}

	public class Geometry {
		public string Type { get; set; }
		public string Coordinates { get; set; }
	}

	#region Property

	public class Property {
		public int WeatherAreaCode { get; set; }
		public WeatherList WeatherList { get; set; }
	}

	public class WeatherList {
		public Weather[] Weather { get; set; }
	}

	public class Weather {
		public string Type { get; set; }
		public string Date { get; set; }
		public float Rainfall { get; set; }
	}

	#endregion

	#endregion

	#endregion

	#region PrecipitationXmlModel

	/// <remarks/>
	[XmlType(AnonymousType = true, Namespace = "http://olp.yahooapis.jp/ydf/1.0")]
	[XmlRoot(Namespace = "http://olp.yahooapis.jp/ydf/1.0", IsNullable = false)]
	public partial class PrecipitationXmlModel {
		public YDFResultInfo ResultInfo { get; set; }
		public YDFFeature Feature { get; set; }
		[XmlAttribute]
		public byte firstResultPosition { get; set; }
		[XmlAttribute]
		public byte totalResultsAvailable { get; set; }
		[XmlAttribute()]
		public byte totalResultsReturned { get; set; }
	}

	/// <remarks/>
	[XmlType(AnonymousType = true, Namespace = "http://olp.yahooapis.jp/ydf/1.0")]
	public partial class YDFResultInfo {
		public byte Count { get; set; }
		public byte Total { get; set; }
		public byte Start { get; set; }
		public byte Status { get; set; }
		public decimal Latency { get; set; }
		public object Description { get; set; }
		public string Copyright { get; set; }
	}

	/// <remarks/>
	[XmlType(AnonymousType = true, Namespace = "http://olp.yahooapis.jp/ydf/1.0")]
	public partial class YDFFeature {
		public string Id { get; set; }
		public string Name { get; set; }
		public YDFFeatureGeometry Geometry { get; set; }
		public YDFFeatureProperty Property { get; set; }
	}

	/// <remarks/>
	[XmlType(AnonymousType = true, Namespace = "http://olp.yahooapis.jp/ydf/1.0")]
	public partial class YDFFeatureGeometry {
		public string Type { get; set; }
		public string Coordinates { get; set; }
	}

	/// <remarks/>
	[XmlType(AnonymousType = true, Namespace = "http://olp.yahooapis.jp/ydf/1.0")]
	public partial class YDFFeatureProperty {
		public ushort WeatherAreaCode { get; set; }
		[System.Xml.Serialization.XmlArrayItemAttribute("Weather", IsNullable = false)]
		public YDFFeaturePropertyWeather[] WeatherList { get; set; }
	}

	/// <remarks/>
	[XmlType(AnonymousType = true, Namespace = "http://olp.yahooapis.jp/ydf/1.0")]
	public partial class YDFFeaturePropertyWeather {
		public string Type { get; set; }
		public ulong Date { get; set; }
		public decimal Rainfall { get; set; }
	}

	#endregion
}
