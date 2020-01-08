using NUnit.Framework;

namespace ObjectMerger.UnitTests
{
	[TestFixture]
	public class MapExtensionTestFixture
	{
		[Test]
		public void MergeProperties_ShoudMergeTarget() {
			var source = new { testProp = 1, testField = "_" };
			var target = new { testProp = 200, testField = "test" };

			MapExtension.Merge(source, target);
			Assert.IsTrue(source.Equals(target));
		}

		[Test]
		public void MergeProperties_ShoudMergeSource() {
			var source = new { testProp = 1, testField = "_" };
			var target = new { testProp = 200, testField = "test"};

			MapExtension.Merge(target, source);
			Assert.IsTrue(source.Equals(target));
		}
	}
}
