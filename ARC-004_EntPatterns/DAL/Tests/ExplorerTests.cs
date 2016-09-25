using System;
using System.Collections.Generic;
using Domain;
using FluentAssertions;
using Infrastructure.Adapters;
using Infrastructure.Adapters.Base;
using NUnit.Framework;
using StructureMap;

namespace Tests {
    [TestFixture]
    public class ExplorerTests : TestsBase {
        [Test]
        public void CanFindAllWriteAdapters() {
            // Assert
            ObjectFactory.Container.GetAllInstances<IWriteAdapter>()
                .Should().Contain(i => i.GetType() == typeof (InvoiceAdapter));
        }

        [Test]
        public void CanFindAllReadAdapters() {
            // Arrange
            var adapters = new List<Type> {
                                              typeof (Invoice),
                                              typeof (Customer),
                                              typeof (Ware),
                                          };

            // Assert
            adapters.ForEach(i => {
                                 var instance = ObjectFactory.Container
                                     .ForGenericType(typeof (IReadAdapter<>))
                                     .WithParameters(i);
                                 instance.Should().NotBeNull();
                             });
        }
    }
}