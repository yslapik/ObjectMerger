using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ObjectMerger
{
	class PropertyMapBuilder : IMapBuilder, IMetaInfoDataFinder<PropertyInfo>
	{
		public T Merge<T, S>(T target, S source) {
			var targetProperties = GetObjectDataInfos(typeof(T));
			var sourceProperties = GetObjectDataInfos(typeof(S));
			foreach (PropertyInfo tprop in targetProperties) {
				var sprop = sourceProperties.SingleOrDefault(sp => sp.Name == tprop.Name && sp.PropertyType == tprop.PropertyType);
				if (sprop == null) {
					continue;
				}
				var value = sprop.GetValue(source, null);
				if (value != null && tprop.CanWrite) {
					tprop.SetValue(target, value, null);
				}
			}
			return target;
		}

		public IEnumerable<PropertyInfo> GetObjectDataInfos(Type t) {
			return t.GetProperties();
		}

		public T GetMappingResult<T, S>(T target, S source) {
			return Merge(target, source);
		}
	}
}
