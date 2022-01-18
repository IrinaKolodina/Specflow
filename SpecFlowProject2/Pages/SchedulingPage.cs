using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject2.Drivers;
using SpecFlowProject2.Hooks;
using System;
using System.Linq;
using System.Globalization;
using System.Threading;

namespace SpecFlowProject2.Pages
{
    public class SchedulingPage: BasePage
    {
        private Driver driver;
        private static Appointment billableAppt;
        private static Appointment nonBillableAppt;
        private static Appointment travelAppt;
        private static Appointment appt;

        public SchedulingPage(Driver driver): base(driver)
        {
            this.driver = driver;
        }

        #region Elements
        public Element dateCalendar = new Element(By.XPath("//kendo-datepicker[@formcontrolname='displayDate']"));

        public Element table = new Element(By.XPath("//*[@id='week']/div/div[@class ='calendar_default_scroll']//div[@class = 'calendar_default_cell_inner']"));

        public Element spinner = new Element(By.XPath("//div[@ng-show='isLoading']"));

        public Element scheduling = new Element(By.XPath("//div[contains(text(),'SCHEDULING')]"));

        public Element save = new Element(By.XPath("//button[contains(text(),'Save')]""));

        public Element saveAnyway = new Element(By.XPath("//div[contains(text(), 'Save Anyway')]"));

        public Element warning = new Element(By.XPath("//div[@class='ngDialogTitle' and contains(text(), 'Appointment Warnings')]"));

        public Element okButton = new Element(By.XPath("//button[contains(text(), 'Ok')]"));

        public Element close = new Element(By.XPath("//button[contains(text(), 'Close')]"));

        public Element mileage = new Element(By.XPath("//input[contains(@formcontrolname, 'mileage')]"));

        public Element openOccurence = new Element(By.XPath("//a/span[.='Open occurrence']"));

        public Element apptType = new Element(By.XPath("//input[@placeholder='Please select type']"));

        public Element startTime = new Element(By.XPath("//kendo-combobox[@formcontrolname='displayStartTime']//input"));

        public Element endTime = new Element(By.XPath("//kendo-combobox[@formcontrolname='displayEndTime']//input"));

        public Element staffMember = new Element(By.XPath("//kendo-combobox[@formcontrolname = 'staffId']//input"));

        public Element client = new Element(By.XPath("//kendo-combobox[@formcontrolname = 'clientId']//input"));

        public Element service = new Element(By.XPath("//kendo-combobox[@id = 'service-combobox']//input"));

        public Element paycode = new Element(By.XPath("//kendo-combobox[@formcontrolname = 'paycodeId']//input"));

        public Element placeOfService = new Element(By.XPath("//input[@placeholder = 'Choose Location']"));

        public Element location = new Element(By.XPath("//input[@placeholder = 'Choose Location']"));

        public Element tag = new Element(By.XPath("//input[@placeholder = 'Add tag']"));

        public Element delete = new Element(By.XPath("//button[contains(text() = 'Delete')]"));
        #endregion

        public void verifyShedulingPageIsOpened()
        {
            table.WaitForElement(driver);
            Assert.True(table.AsIWebElement(driver).Displayed);
        }

        public void verifyAppointmentIsCreated()
        {
            Thread.Sleep(5000);
            IWebElement app;
            if (billableAppt != null)
            {
                app = driver.webDriver.FindElement(By.XPath(billableAppt.GetApptXPath()));
                Assert.True(app.FindElement(By.XPath("./parent::div")).GetCssValue("background-color").Contains("rgba(180, 215, 161, 1)"));
            }
            if (nonBillableAppt != null)
            {
                app = driver.webDriver.FindElement(By.XPath(nonBillableAppt.GetApptXPath()));
                Assert.True(app.FindElement(By.XPath("./parent::div")).GetCssValue("background-color").Contains("rgba(189, 221, 244, 1)"));
            }
            else if (travelAppt != null)
            {
                app = driver.webDriver.FindElement(By.XPath(travelAppt.GetApptXPath()));
                Assert.True(app.FindElement(By.XPath("./parent::div")).GetCssValue("background-color").Contains("rgba(237, 223, 134, 1)"));
            }
                     
        }

        public void verifyAppointmentIsEdited()
        {
            table.WaitForElement(driver);
            IWebElement app;
            if (billableAppt!=null) app = driver.webDriver.FindElement(By.XPath(billableAppt.GetApptXPath()));
            else if (nonBillableAppt != null) app = driver.webDriver.FindElement(By.XPath(nonBillableAppt.GetApptXPath()));
            else if (travelAppt != null) app = driver.webDriver.FindElement(By.XPath(travelAppt.GetApptXPath()));
            else throw new Exception();
            Assert.True(app.Text.Contains(appt.service.Split(',').First()));
        }

        public void verifyAppointmentIsDeleted()
        {
            table.WaitForElement(driver);
            if (billableAppt != null) Assert.True(!driver.webDriver.FindElement(By.XPath(nonBillableAppt.GetApptXPath())).Displayed);
            else if (nonBillableAppt != null) Assert.True(!driver.webDriver.FindElement(By.XPath(nonBillableAppt.GetApptXPath())).Displayed);
            else if (travelAppt != null) Assert.True(!driver.webDriver.FindElement(By.XPath(travelAppt.GetApptXPath())).Displayed);
            else throw new Exception();            
        }

        public void openSchedulerPage()
        {
            scheduling.WaitForElement(driver);
            scheduling.Click(driver);
        }

        public void OpenAppointment(string type)
        {
            Element webElement;
            switch (type)
            {
                case "Billable":
                    {
                        webElement = new Element(By.XPath(billableAppt.GetApptXPath()));                     
                        break;
                    }
                case "Non-Billable":
                    {
                        webElement = new Element(By.XPath(nonBillableAppt.GetApptXPath()));
                        break;
                    }
                case "Travel":
                    {
                        webElement = new Element(By.XPath(travelAppt.GetApptXPath()));
                        break;
                    }
                default:
                    {
                        throw new ArgumentException(message: $"Unexpected enum value:", paramName: nameof(appt.type));
                    }
            }
            webElement.Click(driver);
            openOccurence.WaitForElement(driver);
            openOccurence.JsClick(driver);
        }

        public void editAppointment()
        {
            Thread.Sleep(4000);
            appt.service = "Behavior Therapy";
            Thread.Sleep(4000);
            service.TypeText(driver, appt.service);
            Thread.Sleep(4000);
            save.Click();
            Thread.Sleep(4000);
            if (saveAnyway.AsIWebElement(driver).Displayed)
            {
                saveAnyway.JsClick(driver);
            }
            Thread.Sleep(2000);
            okButton.JsClick(driver);
            close.WaitForElement(driver);
            close.Click(driver);
        }

        public void deleteAppointment()
        {
            delete.Click();
            Thread.Sleep(2000);
            okButton.JsClick(driver);
        }

        public void createBillableAppointment(string type)
        {
            switch (type)
            {
                case "Billable":
                    {
                        createAppointment(billableAppt);
                        break;
                    }
                case "Non-Billable":
                    {
                        createAppointment(nonBillableAppt);
                        break;
                    }
                case "Travel":
                    {
                        createAppointment(travelAppt);
                        break;
                    }
                default:
                    {
                        throw new ArgumentException(message: $"Unexpected enum value:", paramName: nameof(appt.type));
                    }
            }
        }

        public void createAppointment(Appointment appt) 
        {
            table.WaitForElement(driver);
            table.Click(driver);
            Thread.Sleep(3000);

            switch (appt.type) 
            {
                case Appointment.Type.Billable: 
                    apptType.AsIWebElement(driver).SendKeys("Billable");
                    break;
                case Appointment.Type.NonBillable:
                    apptType.AsIWebElement(driver).SendKeys("Non-Billable");
                    break;
                case Appointment.Type.Travel:
                    apptType.AsIWebElement(driver).SendKeys("Travel");
                    break;
            }

            dateCalendar.TypeText(driver, appt.date.ToString("MM/dd/yyy", CultureInfo.InvariantCulture));
            
            Thread.Sleep(3000);
            endTime.TypeText(driver, appt.endTime.ToString("hh:mm tt", CultureInfo.InvariantCulture));

            startTime.TypeText(driver, appt.startTime.ToString("hh:mm tt", CultureInfo.InvariantCulture));
       
            staffMember.TypeText(driver, appt.staff);
            client.TypeText(driver, appt.client);
            Thread.Sleep(2000);
            service.TypeText(driver, appt.service);
            paycode.TypeText(driver, appt.payCode);

            if (!string.IsNullOrEmpty(appt.placeOfService) && appt.type != Appointment.Type.Travel)
                placeOfService.TypeText(driver, appt.placeOfService);
            if (!string.IsNullOrEmpty(appt.location))
      location.TypeText(driver, appt.location);
            if (!string.IsNullOrEmpty(appt.tag))
                tag.TypeText(driver, appt.tag);
            if (!string.IsNullOrEmpty(appt.mileage))
                mileage.TypeText(driver, appt.mileage);
            save.Click();
           Thread.Sleep(2000);
            if (saveAnyway.AsIWebElement(driver).Displayed) 
            {
                saveAnyway.JsClick(driver);
            }
            Thread.Sleep(2000);
            okButton.JsClick(driver);
            close.WaitForElement(driver);
            close.Click(driver);
        }



        public void appointmentObject(string apptType)
        {
            var ts = new TimeSpan(DateTime.Now.Hour, 0, 0);
            var tempdt = DateTime.Now.Date + ts;
            var date = DateTime.Now;

            appt = new Appointment(
                Appointment.Type.Billable,
                date.AddDays(-1),
                tempdt,
                tempdt.AddHours(1),
                "badhires3 badhires3",
                "Lady Gaga",
                "Service A, 97155, No Authorization Needed",
                "FT",
                "03 - School");

            switch (apptType)
            {
                case "Billable": 
                    {
                        billableAppt = new Appointment(appt);
                        billableAppt.startTime = appt.startTime.AddHours(-2);
                        billableAppt.endTime = appt.endTime.AddHours(-2);
                        break;
                    }
                case "Non-Billable": 
                    {
                        nonBillableAppt = new Appointment(appt);
                        nonBillableAppt.type = Appointment.Type.NonBillable;
                        nonBillableAppt.startTime = appt.startTime.AddHours(2);
                        nonBillableAppt.endTime = appt.endTime.AddHours(2);
                        nonBillableAppt.tag = "Non Bill Tag A";
                        break;
                    }
                case "Travel":
                    {
                        travelAppt = new Appointment(appt);
                        travelAppt.type = Appointment.Type.Travel;
                        travelAppt.date = appt.date.AddDays(1);
                        travelAppt.mileage = "1";
                        break;
                    }
                default:
                    {
                        throw new ArgumentException(message: $"Unexpected enum value:", paramName: nameof(appt.type));
                    }
            }
            
        }
    }
}
