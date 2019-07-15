using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PingDong.CleanArchitect.Core.Testing.UnitTests
{
    public class ClassTest
    {
        [Fact]
        public void CorrectClass()
        {
            var tester = new ClassTester<Correct>();
            
            Assert.True(tester.VerifyPropertiesAssignedFromConstructor());
        }
        [Fact]
        public void Class_MissingProperty()
        {
            var tester = new ClassTester<MissingProperty>();
            
            Assert.False(tester.VerifyPropertiesAssignedFromConstructor());
        }
        [Fact]
        public void Class_WrongAssign()
        {
            var tester = new ClassTester<WrongAssign>();
            
            Assert.False(tester.VerifyPropertiesAssignedFromConstructor());
        }

        
        public class Correct
        {
            public Guid Id { get; }
            public string Name { get; }

            public Correct(Guid id, string name)
            {
                Id = id;
                Name = name;
            }
        }
        public class MissingProperty
        {
            public Guid Id { get; }
            public string Name { get; }

            public MissingProperty(Guid id, string name)
            {
                Id = id;
            }
        }
        public class WrongAssign
        {
            public string Id { get; }
            public string Name { get; }

            public WrongAssign(string id, string name)
            {
                Name = id;
                Id = name;
            }
        }
    }
}
