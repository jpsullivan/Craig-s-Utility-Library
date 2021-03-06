﻿/*
Copyright (c) 2012 <a href="http://www.gutgames.com">James Craig</a>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MoonUnit;
using MoonUnit.Attributes;
using Utilities.DataTypes;
using System.Data;
using Utilities.Events.EventArgs;
using Utilities.Random;

namespace UnitTests.DataTypes
{
    public class RingBuffer
    {
        [Test]
        public void RandomTest()
        {
            RingBuffer<int> TestObject = new RingBuffer<int>(10);
            Utilities.Random.Random Rand = new Utilities.Random.Random();
            int Value = 0;
            for (int x = 0; x < 10; ++x)
            {
                Value = Rand.Next();
                TestObject.Add(Value);
                Assert.Equal(1, TestObject.Count);
                Assert.Equal(Value, TestObject.Remove());
            }
            Assert.Equal(0, TestObject.Count);
            System.Collections.Generic.List<int> Values=new System.Collections.Generic.List<int>();
            for (int x = 0; x < 10; ++x)
            {
                Values.Add(Rand.Next());
            }
            TestObject.Add(Values);
            Assert.Equal(Values.ToArray(), TestObject.ToArray());

            for (int x = 0; x < 10; ++x)
            {
                Assert.Throws<IndexOutOfRangeException>(() => TestObject.Add(Rand.Next()));
                Assert.Equal(10, TestObject.Count);
            }
        }
    }
}
