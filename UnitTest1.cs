using Collections;
using NUnit.Framework;
using System.Linq;

namespace Test_Collections
{
    public class Tests
    {


        [Test]
        public void Test_Collection_EmptyConstructor()
        {
            // Arrange
            var nums = new Collection<int>();

            // Assert
            Assert.That(nums.ToString(), Is.EqualTo("[]"));
        }
        [Test]
        public void Test_Collection_ConstructorSingleItem()
        {
            var nums = new Collection<int>(5);
            Assert.That(nums.ToString(), Is.EqualTo("[5]"));
        }
        [Test]
        public void Test_Collection_ConstructorMultipleItems()
        {
            var nums = new Collection<int>(5, 10, 15);
            Assert.That(nums.ToString(), Is.EqualTo("[5, 10, 15]"));
        }
        [Test]
        public void Test_Collections_Add()
        {
            // Arrange
            var nums = new Collection<int>();

            // Act
            nums.Add(5);
            nums.Add(6);

            // Assert
            Assert.That(nums.ToString(), Is.EqualTo("[5, 6]"));
        }
        [Test]
        public void Test_Collection_AddRangeWithGrow()
        {
            var nums = new Collection<int>();
            int oldCapacity = nums.Capacity;
            var newNums = Enumerable.Range(1000, 2000).ToArray();
            nums.AddRange(newNums);
            string expectedNums = "[" + string.Join(", ", newNums) + "]";
            Assert.That(nums.ToString(), Is.EqualTo(expectedNums));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(oldCapacity));
            Assert.That(nums.Capacity, Is.GreaterThanOrEqualTo(nums.Count));
        }
        [Test]
        [Timeout(1000)]
        public void Test_Collection_1MillionItems()
        {
            const int itemsCount = 1000000;
            var nums = new Collection<int>();
            nums.AddRange(Enumerable.Range(1, itemsCount).ToArray());
            Assert.That(nums.Count == itemsCount);
            Assert.That(nums.Capacity >= nums.Count);
            for (int i = itemsCount - 1; i >= 0; i--)
                nums.RemoveAt(i);
            Assert.That(nums.ToString() == "[]");
            Assert.That(nums.Capacity >= nums.Count);
        }





    }
}