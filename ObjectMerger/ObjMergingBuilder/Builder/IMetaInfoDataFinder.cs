using System;
using System.Collections.Generic;

namespace ObjectMerger
{
	interface IMetaInfoDataFinder<MetaInfo>
	{
		IEnumerable<MetaInfo> GetObjectDataInfos(Type t);
	}
}
