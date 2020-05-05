using System;
using Xunit;

namespace Collections.Tests
{
    public class Deque_AddShould
    {
        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void AddFirst_IntegerTypes_AddValues(params int[] nums)
        {
            var deque = new Deque<int>();

            int expectedSize = 0;
            Assert.Equal(expectedSize, deque.GetSize());

            foreach (int num in nums)
            {
                deque.AddFirst(num);
                Assert.Equal(num, deque.PeekFirst());

                expectedSize++;
                Assert.Equal(expectedSize, deque.GetSize());
            }

            int i = 0;
            Array.Reverse(nums);
            foreach (int x in deque)
            {
                Assert.Equal(nums[i], x);
                i++;
            }
        }

        [Theory]
        [InlineData("foo")]
        [InlineData("bar", "foo")]
        [InlineData("bar", "tan", "foo", "arc")]
        public void AddFirst_StringTypes_AddValues(params string[] strings)
        {
            var deque = new Deque<string>();

            int expectedSize = 0;
            Assert.Equal(expectedSize, deque.GetSize());

            foreach (string str in strings)
            {
                deque.AddFirst(str);
                Assert.Equal(str, deque.PeekFirst());

                expectedSize++;
                Assert.Equal(expectedSize, deque.GetSize());
            }

            int i = 0;
            Array.Reverse(strings);
            foreach (string x in deque)
            {
                Assert.Equal(strings[i], x);
                i++;
            }
        }

        [Theory]
        [InlineData(5)]
        [InlineData(-1, 0)]
        [InlineData(9, -5, 2, 7, 1)]
        public void AddLast_IntegerTypes_AddValues(params int[] nums)
        {
            var deque = new Deque<int>();

            int expectedSize = 0;
            Assert.Equal(expectedSize, deque.GetSize());

            foreach (int num in nums)
            {
                deque.AddLast(num);
                Assert.Equal(num, deque.PeekLast());

                expectedSize++;
                Assert.Equal(expectedSize, deque.GetSize());
            }

            int i = 0;
            foreach (int x in deque)
            {
                Assert.Equal(nums[i], x);
                i++;
            }
        }

        [Theory]
        [InlineData("foo")]
        [InlineData("bar", "foo")]
        [InlineData("bar", "tan", "foo", "arc")]
        public void AddLast_StringTypes_AddValues(params string[] strings)
        {
            var deque = new Deque<string>();

            int expectedSize = 0;
            Assert.Equal(expectedSize, deque.GetSize());

            foreach (string str in strings)
            {
                deque.AddLast(str);
                Assert.Equal(str, deque.PeekLast());

                expectedSize++;
                Assert.Equal(expectedSize, deque.GetSize());
            }

            int i = 0;
            foreach (string x in deque)
            {
                Assert.Equal(strings[i], x);
                i++;
            }
        }
    }
}