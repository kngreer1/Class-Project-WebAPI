using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Greer_P2.Models;

namespace Greer_P2.Controllers
{
    public class CustomersByStateController : ApiController
    {
        private Project_4Entities db = new Project_4Entities();

        [Route("api/customer")]
        public List<TO_State> GetAllStates()
        {
            List<TO_State> states = new List<TO_State>();

            foreach(tblState state in db.tblStates)
            {
                TO_State stateObject = new TO_State();
                stateObject.fldStateCode = state.fldStateCode;
                stateObject.fldStateName = state.fldStateName;

                states.Add(stateObject);
            }
            var sortedList = states
                                .OrderBy(m => m.fldStateName)
                                .ToList();
            return sortedList;        
        }
        [Route("api/customer/{stateCode}")]
        public List<TO_Customer> GetCustomersByState(string stateCode)
        {
            List<TO_Customer> customers = new List<TO_Customer>();

            foreach(tblCustomer customer in db.tblCustomers)
            {
                TO_Customer customerObject = new TO_Customer();
                customerObject.fldAddress = customer.fldAddress;
                customerObject.fldCity = customer.fldCity;
                customerObject.fldEmail = customer.fldEmail;
                customerObject.fldFirstName = customer.fldFirstName;
                customerObject.fldLastName = customer.fldLastName;
                customerObject.fldPhoneNumber = customer.fldPhoneNumber;
                customerObject.fldState = customer.fldState;
                customerObject.fldZipCode = customer.fldZipCode;

                customers.Add(customerObject);
            }
            var selectedCustomerObject = customers
                                         .Where(m => m.fldState == stateCode)
                                         .OrderBy(m => m.fldFirstName)
                                         .ToList();

            return selectedCustomerObject;

        }
    }
}
