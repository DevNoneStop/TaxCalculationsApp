using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using TaxCalculatorWeb.Models;

namespace TaxCalculatorWeb.Controllers
{
    public class EmployeeController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7048/api"); //The base uri for our API running from our EmployeeTaxCal.API running locally.

        private readonly HttpClient _httpClient;

        public EmployeeController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress; //Assigning the baseaddress into our httpClient
        }

        [HttpGet]
        public IActionResult Index() //Get all employees from the DB via the API.
        {
            List<EmployeeViewModel> empList = new List<EmployeeViewModel>();
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Employee/GetEmployees").Result;

            if(response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;//get string data from the api
                empList = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(data);//Deserialze the data results into json format
            }
            return View(empList);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public  IActionResult Create(EmployeeViewModel model) //Creating a new employee entry for calculation.
        {

            double Income = model.Income;
            string postalCode = model.PostalCode;
            double totaltax = 0;

            try
            {
                TaxCalculator taxCalculator = new TaxCalculator();

                if(model != null) { 
                    if(Income > 0 && postalCode != null) //progressive calculation
                    {
                       totaltax = taxCalculator.GetTotalTaxedPerAmountPerPostalCode(Income, postalCode);
                    }
                    model.TaxCalculated = totaltax; //Assign calculated Tax to the variable in the model.
                    model.CreatedDate = DateTime.Now;

                    string data = JsonConvert.SerializeObject(model);
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                    HttpResponseMessage response =  _httpClient.PostAsync(_httpClient.BaseAddress + "/Employee/Create", content).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["successMessage"] = "Employee Created"; //success message
                        return RedirectToAction("Index");
                    }
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message; //Error message
                return View();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int Id) //Edit an employee
        {
            try
            {
                EmployeeViewModel emp = new EmployeeViewModel();
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Employee/GetById/" + Id).Result; //getting employee by id.

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;//get string data from the api                   
                    emp = JsonConvert.DeserializeObject<EmployeeViewModel>(data); //Deserialze the data results into json format
                }
                return View(emp);
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message; //Error message
                return View();
            }
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json"); 
                HttpResponseMessage response = _httpClient.PutAsync(_httpClient.BaseAddress + "/Employee/update", content).Result; //Updating employee details.

                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Employee details updated"; //success message
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message; //Error message
                return View();
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int Id) //Deleting the entry
        {
            try
            {
                EmployeeViewModel emp = new EmployeeViewModel();
                HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "/Employee/GetById/" + Id).Result;

                if (response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result; //get string data from the api
                    emp = JsonConvert.DeserializeObject<EmployeeViewModel>(data);//Deserialze the data results into json format
                }
                return View(emp);
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message; //Error message
                return View();
            }
        }


    }
}
