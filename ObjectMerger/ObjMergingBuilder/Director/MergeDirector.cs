namespace ObjectMerger
{
	class MergeDirector
	{
		IMapBuilder _fieldBuilder;
		public IMapBuilder FieldBuilder => _fieldBuilder ?? (_fieldBuilder = new FieldMapBuilder());

		IMapBuilder _propertyBuilder;
		public IMapBuilder PropertyBuilder => _propertyBuilder ?? (_propertyBuilder = new PropertyMapBuilder());

		public T Map<T, S>(T target, S source) {
			var buildedFields = FieldBuilder.GetMappingResult(target, source);
			return PropertyBuilder.GetMappingResult(buildedFields, source);
		}
	}
}
