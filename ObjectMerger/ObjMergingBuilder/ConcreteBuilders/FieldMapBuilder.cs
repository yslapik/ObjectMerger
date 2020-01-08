using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ObjectMerger
{
	class FieldMapBuilder : IMapBuilder, IMetaInfoDataFinder<FieldInfo>
	{
		public T Merge<T, S>(T target, S source) {
			var targetProperties = GetObjectDataInfos(typeof(T));
			var sourceProperties = GetObjectDataInfos(typeof(S));
			foreach (var tprop in targetProperties) {
				var sprop = sourceProperties.SingleOrDefault(sp => sp.Name == tprop.Name);
				if (sprop == null) {
					continue;
				}
				var value = sprop.GetValue(source);
				if (value != null) {
					tprop.SetValue(target, value);
				}
			}
			return target;
		}

		public T GetMappingResult<T, S>(T target, S source) {
			return Merge(target, source);
		}

		public IEnumerable<FieldInfo> GetObjectDataInfos(Type t) {
			return t.GetFields();
		}
	}
}
