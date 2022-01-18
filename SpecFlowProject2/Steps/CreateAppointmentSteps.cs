using NUnit.Framework;
using SpecFlowProject2.Drivers;
using SpecFlowProject2.Pages;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.Steps
{
    [Parallelizable(ParallelScope.Self)]
    [Binding]
    public class CreateAppointmentSteps
    {
        Driver driver;
        private readonly LoginPage loginPage;
        private readonly SchedulingPage schedulingPage;
      
        public CreateAppointmentSteps(Driver driver)
        {
            this.driver = driver;
            loginPage =new LoginPage(driver);
            schedulingPage = new SchedulingPage(driver);
        }

        [Given(@"I open scheduler page")]
        public void GivenIOpenSchedulerPage()
        {
            schedulingPage.openSchedulerPage();
        }

        [Given(@"scheduler page is opened")]
        public void GivenSchedulerPageIsOpened()
        {
            schedulingPage.verifyShedulingPageIsOpened();
        }

        [Given(@"I create appointment with (.*) type")]
        [When(@"I create appointment with (.*) type")]
        public void WhenICreateAppointmentWithType(string typeOfAppoitment)
        {
            schedulingPage.appointmentObject(typeOfAppoitment);
            schedulingPage.createBillableAppointment(typeOfAppoitment);
        }

        [Given(@"appointment type should be created")]
        [Then(@"appointment type should be created")]
        public void ThenAppointmentTypeShouldBeCreated()
        {
            schedulingPage.verifyAppointmentIsCreated();
        }

        [When(@"I edit the appointment with (.*) type")]
        public void WhenIEditTheAppointmentWithType(string typeOfAppoitment)
        {
            schedulingPage.OpenAppointment(typeOfAppoitment);
            schedulingPage.editAppointment();            
        }

        [Then(@"Changes should be saved")]
        public void ThenChangesShouldBeSaved()
        {
            schedulingPage.verifyAppointmentIsEdited();
        }

        [When(@"I delete the appointment with (.*) type")]
        public void WhenIDeleteTheAppointmentWithType(string typeOfAppoitment)
        {
            schedulingPage.OpenAppointment(typeOfAppoitment);
            schedulingPage.deleteAppointment();
        }

        [Then(@"Appointment should not be displayed")]
        public void ThenAppointmentShouldNotBeDisplayed()
        {
            ScenarioContext.Current.Pending();
        }



    }
}
