namespace ObjectMerger
{
	public static class MapExtension
	{
		public static void Merge<T, S>(T target, S source) {
			var md = new MergeDirector();
			md.Map(target, source);
		}
	}
}
