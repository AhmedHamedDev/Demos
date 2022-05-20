using ITPack.Domain.Entities;
using ITPack.Domain.Events;
using ITPack.Domain.Exceptions;
using ITPack.Domain.Factories;
using ITPack.Domain.Policies;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PackIt.Tests.Domain
{
    public class PackingListTests
    {

        [Fact]
        public void AddItem_Throws_PackingItemAlreadyExistsException_When_There_Is_Already_Item_With_The_Same_Name()
        {
            //ARRANGE
            var packingList = GetPackingList();
            packingList.ClearEvents();
            packingList.AddItem(new ITPack.Domain.ValueObjects.PackingItem("one", 1));

            //ACT
            var exception = Record.Exception(() => packingList.AddItem(new ITPack.Domain.ValueObjects.PackingItem("one", 1)));

            //ASSERT
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<PackingItemAlreadyExistsException>();
        }

        [Fact]
        public void AddItem_Adds_PackingItemAdded_Domain_Event_On_Success()
        {
            var packingList = GetPackingList();

            var exception = Record.Exception(() => packingList.AddItem(new ITPack.Domain.ValueObjects.PackingItem("one", 1)));

            exception.ShouldBeNull();
            packingList.Events.Count().ShouldBe(1);

            var @event = packingList.Events.FirstOrDefault() as PackingItemAdded;

            @event.ShouldNotBeNull();
            @event.PackingItem.Name.ShouldBe("one");
        }

        private PackingList GetPackingList()
        {
            var packingList = _factory.Create(Guid.NewGuid(), "MyList",
                new ITPack.Domain.ValueObjects.Localization("cairo", "Egypt"));
            return packingList;
        }


        #region Arrange

        private readonly IPackingListFactory _factory;
        public PackingListTests()
        {
            _factory = new PackingListFactory(Enumerable.Empty<IPackingItemsPolicy>());
        }

        #endregion
    }


}
