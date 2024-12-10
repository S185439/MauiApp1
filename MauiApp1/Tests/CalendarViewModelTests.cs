using Xunit;
using MauiApp1.ViewModels;
using System.Linq;

namespace MauiApp1.Tests
{
    public class CalendarViewModelTests
    {
        [Fact]
        public void AddEventCommand_ShouldAddEvent()
        {
            // Arrange
            var viewModel = new CalendarViewModel();
            viewModel.EventTitle = "Test Event";
            viewModel.SelectedDate = DateTime.Today;
            var initialEventCount = viewModel.Events.ContainsKey(viewModel.SelectedDate) ? viewModel.Events[viewModel.SelectedDate].Count : 0;

            // Act
            viewModel.AddEventCommand.Execute(null);

            // Assert
            Assert.True(viewModel.Events.ContainsKey(viewModel.SelectedDate));
            Assert.Equal(initialEventCount + 1, viewModel.Events[viewModel.SelectedDate].Count);
        }
    }
}
