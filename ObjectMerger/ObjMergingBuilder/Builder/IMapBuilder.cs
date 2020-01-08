namespace ObjectMerger
{
	interface IMapBuilder
	{
		T Merge<T, S>(T target, S source);
		T GetMappingResult<T, S>(T target, S source);
	}
}
